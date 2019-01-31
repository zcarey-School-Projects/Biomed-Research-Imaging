using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.MotorizedStage;
using UndergradResearchBiomedImaging.UI.MenuStrip;
using UndergradResearchBiomedImaging.UI.OptionsCategories;
using UndergradResearchBiomedImaging.Util;

//using Windows.Media.Capture;
//using System.Windows.Storage;

namespace UndergradResearchBiomedImaging {
	public partial class ControlForm : Form {

		private const string TempVideoFile = @"TempRecording.avi";

		private static SaveFileDialog SaveVideoDialog;
		private static SaveFileDialog SaveScreenshotDialog;//TODO read framerate from camera for video
		private static Dictionary<int, ImageFormat> ImageExtensions = new Dictionary<int, ImageFormat>();
		
		/// <summary>Initializes file dialogs</summary>
		static ControlForm() {
			SaveVideoDialog = new SaveFileDialog();
			SaveVideoDialog.AddExtension = true;
			SaveVideoDialog.Filter = "AVI (*.avi)|*.avi";
			SaveVideoDialog.OverwritePrompt = true;
			SaveVideoDialog.RestoreDirectory = true;
			SaveVideoDialog.Title = "Save Video";

			SaveScreenshotDialog = new SaveFileDialog();
			SaveScreenshotDialog.AddExtension = true;
			SaveScreenshotDialog.OverwritePrompt = true;
			SaveScreenshotDialog.RestoreDirectory = true;
			SaveScreenshotDialog.Title = "Save Screenshot";

			ImageExtensions.Add(0, ImageFormat.Png);
			ImageExtensions.Add(1, ImageFormat.Jpeg);
			ImageExtensions.Add(2, ImageFormat.Gif);
			ImageExtensions.Add(3, ImageFormat.Bmp);
			ImageExtensions.Add(4, ImageFormat.Emf);
			ImageExtensions.Add(5, ImageFormat.Exif);
			ImageExtensions.Add(6, ImageFormat.Icon);
			ImageExtensions.Add(7, ImageFormat.Tiff);
			//Text files (*.txt)|*.txt|All files (*.*)|*.*
			string filter = "";
			for(int i = 0; i < ImageExtensions.Count; i++) {
				ImageFormat format;
				if (ImageExtensions.TryGetValue(i, out format)) {
					filter += format.ToString() + " (*." + format.ToString().ToLower() + ")|*." + format.ToString().ToLower() + "|";
				}
			}

			SaveScreenshotDialog.Filter = filter.TrimEnd('|');
		}

		private readonly CameraOptionsForm cameraOptionsForm;
		private readonly StageOptionsForm stageOptionsForm;

		private readonly FlirCameraStream stream = new FlirCameraStream();
		private FlirCameraManager cameraManager = new FlirCameraManager();
		private StageController stage = new StageController();
		
		private FastRecorder videoWriter;

		public ControlForm() {
			InitializeComponent();
			CameraFeed.Image = null; //Clears the test image.
			ScreenshotViewer.Image = null;

			cameraOptionsForm = new CameraOptionsForm(cameraManager, stream);
			stageOptionsForm = new StageOptionsForm(this, stage);

			//Generate drop-down menus
			new TestPatternMenu(TestPatternMenuItem, stream);

			//Set listeners for camera stream
			stream.OnNewImage += FlirCameraStream_OnNewImage;
			stream.OnSourceChanged += FlirCameraStream_OnSourceChanged;

			//If a temp file already exists, delete it.
			if (File.Exists(TempVideoFile)) {
				File.Delete(TempVideoFile);
			}
			OnRecordingClosed(null); //Will actually initialize a new video writer for us.
		}

		private void ControlForm_Load(object sender, EventArgs e) {
			PositionTimer.Enabled = true;
		}

		private void ControlForm_FormClosing(object sender, FormClosingEventArgs e) {
			PositionTimer.Enabled = false;
			cameraOptionsForm.Close();
			stageOptionsForm.Close();
		}

		#region Events
		private int FpsCount = 0;
		private void FlirCameraStream_OnNewImage(FlirCameraStream sender, Image<Bgr, byte> Image) {
			FpsCount++;
			if(FpsCount >= 4) { //About 15 fps
				FpsCount = 0;
				CameraFeed.Invoke(new Action(() => { CameraFeed.Image = (Image == null) ? null : Image.Bitmap; }));
				FPSStatusLabel.Text = sender.FPS.ToString("N2").PadLeft(3) + " FPS";
			}
		}

		private void FlirCameraStream_OnSourceChanged(FlirCameraStream sender, FlirCamera Source) {
			if (Source == null) {
				CameraFeed.Invoke(new Action(() => { CameraFeed.Image = null; }));
				FPSStatusLabel.Text = ((int)0).ToString("N2").PadLeft(3) + " FPS";
			}
		}

		private void OnRecordingChanged(FastRecorder recorder, bool IsRecording) {
			//Whenever a recording starts or stops...
			if (IsRecording) {
				RecordingBorder.BackColor = Color.Red;
			} else {
				RecordingBorder.BackColor = Color.FromArgb(0, 0, 0, 0); //Panel.DefaultBackColor;
			}
		}

		private void OnRecordingClosed(FastRecorder recorder) {
			//When the recording is forced closed...
			OnRecordingChanged(recorder, false);
			if (videoWriter != null) {
				videoWriter.OnRecordingChanged -= OnRecordingChanged;
				videoWriter.OnRecordingForcedClosed -= OnRecordingClosed;
			}
			videoWriter = new FastRecorder(TempVideoFile); //Create a new video writer.
			videoWriter.OnRecordingChanged += OnRecordingChanged;
			videoWriter.OnRecordingForcedClosed += OnRecordingClosed;
		}
		#endregion

		#region Misc
		private void Menu_CameraOptions_Click(object sender, EventArgs e) {
			cameraOptionsForm.Show();
		}

		private void Menu_StageOptions_Click(object sender, EventArgs e) {
			stageOptionsForm.Show();
		}

		private void PositionTimer_Tick(object sender, EventArgs e) {
			if (stage != null) {
				decimal position;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Position(1), out position)) {
					Label_CurrentPosition.Text = position.ToString("N6").PadLeft(9) + " mm";
				} else {
					//TODO can confirm, no stage connected!
					Label_CurrentPosition.Text = " 0.000000 mm";
				}
			}
		}

		/// <summary>Reads and displays stage any errors via Message boxes. Returns false if an error occured.
		/// ErrorsOccured = false if was able to read, but there were no errors.</summary>
		public void DisplayStageErrors() {
			bool errorsOccured;
			if (!DisplayStageErrors(out errorsOccured)) {
				MessageBox.Show("Error communicating with stage.");
			}
		}

		/// <summary>Reads and displays stage any errors via Message boxes. Returns false if an error occured.
		/// ErrorsOccured = false if was able to read, but there were no errors.</summary>
		public bool DisplayStageErrors(out bool ErrorsOccured) {
			ErrorsOccured = true;
			IStageCommand statusCommand = new MotorizedStage.Commands.Status(1);
			MotorizedStage.Commands.StageStatus status;
			if (!stage.TrySendCommand(statusCommand, out status)) return false;
			if (!status.ErrorHasOccured) {
				ErrorsOccured = false; //No error has occured, so there is no need to check any further.
				return true;
			}
			
			IStageCommand errorCommand = new MotorizedStage.Commands.ReadAndClearErrors(1);
			StageError[] errors;
			if (!stage.TrySendCommand(errorCommand, out errors)) return false;
			foreach (StageError error in errors) {
				MessageBox.Show("ERROR: " + error.Name + "; " + error.ShortDescription);
			}

			return true;
		}

		#endregion

		#region Control Methods
		private void Control_ConnectToCamera(object sender, EventArgs e) {
			stream.SourceCamera = cameraManager.OpenCamera(0);
		}

		private void Control_Record(object sender, EventArgs e) {
			if (Btn_Record.Text == "Record") {
				if (videoWriter.Start(stream)) {
					Btn_Record.Text = "Stop";
				}
			} else {
				Btn_Record.Text = "Record";
				if (videoWriter.Stop()) {
					//Stopped successfully.
					if (!File.Exists(TempVideoFile)) return;
					if (SaveVideoDialog.ShowDialog() == DialogResult.OK) {
						if (File.Exists(SaveVideoDialog.FileName)) {
							File.Delete(SaveVideoDialog.FileName);
						}
						File.Copy(TempVideoFile, SaveVideoDialog.FileName);
					}
				}
			}
		}

		private void Control_TakeScreenshot(object sender, EventArgs e) {
			if (stream != null) {
				Image<Bgr, byte> screenshot = stream.Image;
				ScreenshotViewer.Image = ((screenshot == null) ? null : screenshot.Bitmap);
			}
		}

		private void Control_SaveScreenshot(object sender, EventArgs e) {
			Image screenshot = ScreenshotViewer.Image;
			if(screenshot != null) {
				if(SaveScreenshotDialog.ShowDialog() == DialogResult.OK) {
					ImageFormat format;
					if (ImageExtensions.TryGetValue(SaveScreenshotDialog.FilterIndex, out format)) {
						try {
							screenshot.Save(SaveScreenshotDialog.FileName, format);
						}catch(Exception ex) {
							Console.WriteLine("Error writing file: " + ex.Message);
							MessageBox.Show("Error saving file.");
						}
					} else { 
						MessageBox.Show("Error finding format.");
					}
				}
			}
		}

		private void Control_ConnectToStage(object sender, EventArgs e) {
			if (stage.TryAutoConnect()) {
				DisplayStageErrors();
				bool homed;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Home(1, true), out homed)) {
					DisplayStageErrors();
					if (homed == false) {
						stageOptionsForm.UpdateAllValues();
						//Hasn't been homed, ask user if they wish to home.
						if (MessageBox.Show("Stage has not been homed yet, would you like to home it now?", "Stage Not Homed", MessageBoxButtons.YesNo) == DialogResult.Yes) {
							if (stage.FindHome() == HomingStatus.Initiated) {
								MessageBox.Show("Homed successfully!");
							} else {
								MessageBox.Show("Something went wrong.");
							}
							return; //No matter what happenes, the user already knowns it was connected, so dont prompt again.
						}
					}
				}

				MessageBox.Show("Connected!");
			} else {
				MessageBox.Show("Unable to connect.");
			}
		}

		private void Control_MoveRelativeNegative(object sender, EventArgs e) { //TODO when moving, check that is is in bounds, if not clip them so we can move.
			IStageCommand relativeMove = new MotorizedStage.Commands.MoveRelative(1, -Numeric_Relative.Value);
			if (stage.TrySendCommand(relativeMove)) {
				DisplayStageErrors();
			}
		}

		private void Control_MoveRelativePositive(object sender, EventArgs e) {
			IStageCommand relativeMove = new MotorizedStage.Commands.MoveRelative(1, Numeric_Relative.Value);
			if (stage.TrySendCommand(relativeMove)) {
				DisplayStageErrors();
			}
		}

		private void Control_MoveAbsolute(object sender, EventArgs e) {
			IStageCommand absoluteMove = new MotorizedStage.Commands.MoveAbsolute(1, Numeric_Absolute.Value);
			if (stage.TrySendCommand(absoluteMove)) {
				DisplayStageErrors();
			}
		}

		private void Control_WalkPositive(object sender, MouseEventArgs e) {
			IStageCommand walk = new MotorizedStage.Commands.Jog(1, 100); //TODO implement adjustable speed.
			if (stage.TrySendCommand(walk)) {
				DisplayStageErrors();
			}
		}

		private void Control_WalkNegative(object sender, MouseEventArgs e) {
			IStageCommand walk = new MotorizedStage.Commands.Jog(1, -100); //TODO implement adjustable speed.
			if (stage.TrySendCommand(walk)) {
				DisplayStageErrors();
			}
		}

		private void Control_StopWalk(object sender, MouseEventArgs e) {
			IStageCommand walk = new MotorizedStage.Commands.Jog(1);
			if (stage.TrySendCommand(walk)) {
				DisplayStageErrors();
			}
		}

		private void Control_JogPositive(object sender, EventArgs e) {
			IStageCommand jog = new MotorizedStage.Commands.Jog(1, 100); //TODO implement adjustagle speed
			if (stage.TrySendCommand(jog)) {
				DisplayStageErrors();
			}
		}

		private void Control_JogNegative(object sender, EventArgs e) {
			IStageCommand jog = new MotorizedStage.Commands.Jog(1, -100); //TODO implement adjustable speed
			if (stage.TrySendCommand(jog)) {
				DisplayStageErrors();
			}
		}

		#endregion

	}
}
