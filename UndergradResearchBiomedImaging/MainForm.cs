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
using UndergradResearch.Flir;
using UndergradResearch.MotorizedStage;
using UndergradResearch.UI.MenuStrip;
using UndergradResearch.UI.OptionsCategories;
using UndergradResearch.Util;
using UndergradResearch.Util.ExtensionMethods;

//using Windows.Media.Capture;
//using System.Windows.Storage;

namespace UndergradResearch {
	public partial class ControlForm : Form {

		private const string TempVideoFile = @"TempRecording.avi";

		private static SaveFileDialog SaveVideoDialog;
		
		/// <summary>Initializes file dialogs</summary>
		static ControlForm() {
			SaveVideoDialog = new SaveFileDialog();
			SaveVideoDialog.AddExtension = true;
			SaveVideoDialog.Filter = "AVI (*.avi)|*.avi";
			SaveVideoDialog.OverwritePrompt = true;
			SaveVideoDialog.RestoreDirectory = true;
			SaveVideoDialog.Title = "Save Video";
		}

		private readonly CameraOptionsForm cameraOptionsForm;

		private readonly FlirCameraStream stream = new FlirCameraStream();
		private FlirCameraManager cameraManager = new FlirCameraManager();
		private StageController stage = new StageController();
		private FastRecorder videoWriter;

		public ControlForm() {
			InitializeComponent();
			CameraFeed.Image = null; //Clears the test image.

			cameraOptionsForm = new CameraOptionsForm(cameraManager, stream);

			//Generate drop-down menus
			new TestPatternMenu(TestPatternMenuItem, stream);

			//Set listeners for camera stream
			stream.OnNewImage += FlirCameraStream_OnNewImage;
			stream.OnSourceChanged += FlirCameraStream_OnSourceChanged;

			//If a temp file already exists, delete it.
			OnRecordingClosed(null); //Will actually initialize a new video writer for us.
			setEnableStageControls(false);
		}

		private void ControlForm_Load(object sender, EventArgs e) {
			PositionTimer.Enabled = true;
		}

		private void ControlForm_FormClosing(object sender, FormClosingEventArgs e) {
			PositionTimer.Enabled = false;
			cameraOptionsForm.Close();
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

		private void PositionTimer_Tick(object sender, EventArgs e) {
			if (stage != null) {
				MotorizedStage.Commands.StagePosition position;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Position(1), out position)) {
					Label_PositionTheory.Text =  "Theoretical Position: " + position.Theoretical.ToString("N6").PadLeft(9) + " mm";
					Label_PositionEncoder.Text = "Encoder Position:     " + position.Encoder.ToString("N6").PadLeft(9) + " mm";
				} else {
					//TODO can confirm, no stage connected!
					Label_PositionTheory.Text =  "Theoretical Position:  0.000000 mm";
					Label_PositionEncoder.Text = "Encoder Position:      0.000000 mm";
				}
			}
		}

		private void setEnableStageControls(bool isEnabled) {
			setEnableForChildren(Tab_StageControls, isEnabled);
			setEnableForChildren(Tab_StageSettings, isEnabled);
			//setEnableForChildren(StageTabs, isEnabled);
		}

		private void setEnableForChildren(Control container, bool isEnabled) {
			foreach(Control control in container.Controls) {
				if(!(control is GroupBox) || !(control is TabPage)) control.Enabled = isEnabled;
				setEnableForChildren(control, isEnabled);
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
				if (screenshot != null) {
					ScreenshotViewer.Show(screenshot.Bitmap);
				}
			}
		}

		private void Control_SaveScreenshot(object sender, EventArgs e) {
			
		}

		private void Control_ConnectToStage(object sender, EventArgs e) {
			if (stage.TryAutoConnect()) {
				DisplayStageErrors();

				//Show buttons
				setEnableStageControls(true);
				UpdateAllStageValues();

				bool homed;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Home(1, true), out homed)) {
					DisplayStageErrors();
					if (homed == false) {
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
			IStageCommand jog = new MotorizedStage.Commands.Jog(1, Numeric_JogVelocityPercent.Value);
			if (stage.TrySendCommand(jog)) {
				DisplayStageErrors();
			}
		}

		private void Control_JogNegative(object sender, EventArgs e) {
			IStageCommand jog = new MotorizedStage.Commands.Jog(1, -Numeric_JogVelocityPercent.Value);
			if (stage.TrySendCommand(jog)) {
				DisplayStageErrors();
			}
		}

		private void Btn_StopJog_Click(object sender, EventArgs e) {
			IStageCommand jog = new MotorizedStage.Commands.Jog(1);
			if (stage.TrySendCommand(jog)) {
				DisplayStageErrors();
			}
		}

		#endregion

		private void Btn_Home_Click(object sender, EventArgs e) {
			HomingStatus status = stage.FindHome();
			if (status == HomingStatus.Error) {
				MessageBox.Show("An error has occured.");
			} else if (status == HomingStatus.Initiated) {
				MessageBox.Show("Homing started.");
			} else if (status == HomingStatus.InProgress) {
				MessageBox.Show("Already homing.");
			}
		}

		private void Btn_ViewErrors_Click(object sender, EventArgs e) {
			bool ErrorsOccured;
			if (DisplayStageErrors(out ErrorsOccured)) {
				if (!ErrorsOccured) {
					MessageBox.Show("No errors have occured.");
				}
			} else {
				MessageBox.Show("Error communicating with stage.");
			}
		}

		private void Numeric_TravelVelocity_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_TravelVelocity.Value, MotorizedStage.Commands.TravelVelocity.MinimumValue, MotorizedStage.Commands.TravelVelocity.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.TravelVelocity(1, value))) {
				decimal read;
				if (stage.TrySendCommand(new MotorizedStage.Commands.TravelVelocity(1, true), out read)) {
					Numeric_TravelVelocity.ChangeValueWithoutEvent(read, Numeric_TravelVelocity_ValueChanged);
					Numeric_JogVelocityPercent_ValueChanged(null, null);
					return;
				}
			}

			Numeric_JogVelocityPercent_ValueChanged(null, null);
			stageError();
		}

		private void stageError() {
			MessageBox.Show("An error has occured.");
		}

		private decimal constrain(decimal value, decimal min, decimal max) {
			return Math.Max(min, Math.Min(max, value));
		}

		public bool UpdateAllStageValues() {
			bool successful = true;

			decimal maxVelocity;
			Numeric_TravelVelocity.Maximum = (successful &= stage.TrySendCommand(new MotorizedStage.Commands.MaxVelocity(1), out maxVelocity)) ? maxVelocity : MotorizedStage.Commands.TravelVelocity.MaximumValue;
			decimal currentVelocity;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.TravelVelocity(1, true), out currentVelocity)) Numeric_TravelVelocity.ChangeValueWithoutEvent(currentVelocity, Numeric_TravelVelocity_ValueChanged);

			decimal maxAcceleration;
			bool readAccel = stage.TrySendCommand(new MotorizedStage.Commands.MaxAcceleration(1, true), out maxAcceleration);
			Numeric_Acceleration.Maximum = (successful &= readAccel) ? maxAcceleration : MotorizedStage.Commands.Acceleration.MaximumValue;
			decimal currentAcceleration;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.Acceleration(1, true), out currentAcceleration)) Numeric_Acceleration.ChangeValueWithoutEvent(currentAcceleration, Numeric_Acceleration_ValueChanged);

			Numeric_Deceleration.Maximum = (successful &= readAccel) ? maxAcceleration : MotorizedStage.Commands.Deceleration.MaximumValue;
			decimal currentDeceleration;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.Deceleration(1, true), out currentDeceleration)) Numeric_Deceleration.ChangeValueWithoutEvent(currentDeceleration, Numeric_Deceleration_ValueChanged);

			Numeric_JogVelocityActual.Maximum = Numeric_TravelVelocity.Value;
			Numeric_JogVelocityPercent_ValueChanged(null, null); //Sets the "JogVelocityActual" value.
			//Numeric_JogVelocityActual.Value = Numeric_TravelVelocity.Value * Numeric_JogVelocityPercent.Value / 100.0M;

			Numeric_JogAcceleration.Maximum = (readAccel) ? maxAcceleration : MotorizedStage.Commands.JogAcceleration.MaximumValue;
			decimal jogAccel;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.JogAcceleration(1, true), out jogAccel)) Numeric_JogAcceleration.ChangeValueWithoutEvent(jogAccel, Numeric_JogAcceleration_ValueChanged);

			return successful;
		}

		private void Numeric_JogVelocityActual_ValueChanged(object sender, EventArgs e) {
			decimal percentage = Numeric_JogVelocityActual.Value / Numeric_TravelVelocity.Value * 100.0M;
			Numeric_JogVelocityPercent.Value = constrain(percentage, Numeric_JogVelocityPercent.Minimum, Numeric_JogVelocityPercent.Maximum);//TODO contrain can take in the numeric up/down
		}

		private void Numeric_JogVelocityPercent_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_JogVelocityPercent.Value, MotorizedStage.Commands.Jog.MinimumValue, MotorizedStage.Commands.Jog.MaximumValue);
			Numeric_JogVelocityPercent.ChangeValueWithoutEvent(value, Numeric_JogVelocityPercent_ValueChanged);
			Numeric_JogVelocityActual.ChangeValueWithoutEvent(Numeric_TravelVelocity.Value * value / 100, Numeric_JogVelocityActual_ValueChanged);
		}

		private void Numeric_Acceleration_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_Acceleration.Value, MotorizedStage.Commands.Acceleration.MinimumValue, MotorizedStage.Commands.Acceleration.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.Acceleration(1, value))) {
				decimal read;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Acceleration(1, true), out read)) {
					Numeric_Acceleration.ChangeValueWithoutEvent(read, Numeric_Acceleration_ValueChanged);
					return;
				}
			}

			stageError();
		}

		private void Numeric_Deceleration_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_Deceleration.Value, MotorizedStage.Commands.Deceleration.MinimumValue, MotorizedStage.Commands.Deceleration.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.Deceleration(1, value))) {
				decimal read;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Deceleration(1, true), out read)) {
					Numeric_Deceleration.ChangeValueWithoutEvent(read, Numeric_Deceleration_ValueChanged);
					return;
				}
			}

			stageError();
		}

		private void Numeric_JogAcceleration_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_JogAcceleration.Value, MotorizedStage.Commands.JogAcceleration.MinimumValue, MotorizedStage.Commands.JogAcceleration.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.JogAcceleration(1, value))) {
				decimal read;
				if (stage.TrySendCommand(new MotorizedStage.Commands.JogAcceleration(1, true), out read)) {
					Numeric_JogAcceleration.ChangeValueWithoutEvent(read, Numeric_JogAcceleration_ValueChanged);
					return;
				}
			}

			stageError();
		}
	}
}
