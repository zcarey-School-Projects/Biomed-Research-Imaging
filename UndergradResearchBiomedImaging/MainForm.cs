using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.UI.MenuStrip;
using UndergradResearchBiomedImaging.UI.OptionsCategories;
using UndergradResearchBiomedImaging.Util;

//using Windows.Media.Capture;
//using System.Windows.Storage;

namespace UndergradResearchBiomedImaging {
	public partial class ControlForm : Form {

		private const string TempVideoFile = @"TempRecording.avi";

		private readonly CameraOptionsForm cameraOptionsForm;

		private readonly FlirCameraStream stream = new FlirCameraStream();
		private FlirCameraManager cameraManager = new FlirCameraManager();
		
		private FastRecorder videoWriter;

		public ControlForm() {
			InitializeComponent();
			CameraFeed.Image = null; //Clears the test image.
			ScreenshotViewer.Image = null;

			cameraOptionsForm = new CameraOptionsForm(cameraManager, stream);

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
			//stream.SourceCamera = cameraManager.OpenCamera(0); //Attempts to load a camera on start-up
		}

		private void ControlForm_FormClosing(object sender, FormClosingEventArgs e) {
			cameraOptionsForm.Close();
		}

		int count = 0;
		private void FlirCameraStream_OnNewImage(FlirCameraStream sender, Image<Bgr, byte> Image) {
			count++;
			if(count >= 4) { //About 15 fps
				count = 0;
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

		private void Control_ConnectToCamera(object sender, EventArgs e) {
			stream.SourceCamera = cameraManager.OpenCamera(0);
		}

		private void Control_Record(object sender, EventArgs e) {
			if (Record.Text == "Record") {
				if (videoWriter.Start(stream)) {
					Record.Text = "Stop";
				}
			} else {
				Record.Text = "Record";
				if (videoWriter.Stop()) {
					//Stopped successfully.
					//TODO make cleaner
					if (!File.Exists(TempVideoFile)) return;
					SaveFileDialog dialog = new SaveFileDialog();
					dialog.AddExtension = true;
					dialog.Filter = "AVI (*.avi)|*.avi";
					dialog.OverwritePrompt = true;
					dialog.RestoreDirectory = true;
					dialog.Title = "Save Video";
					if(dialog.ShowDialog() == DialogResult.OK) {
						if (File.Exists(dialog.FileName)) {
							File.Delete(dialog.FileName);
						}
						File.Copy(TempVideoFile, dialog.FileName);
					}
				}
			}
		}

		private void OnRecordingChanged(FastRecorder recorder, bool IsRecording) {
			//Whenever a recording starts or stops...
			if (IsRecording) {
				RecordingBorder.BackColor = Color.Red;
				//SettingsPanel.BackColor = Panel.DefaultBackColor;
			} else {
				RecordingBorder.BackColor = Color.FromArgb(0, 0, 0, 0);
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

		private void Menu_CameraOptions_Click(object sender, EventArgs e) {
			cameraOptionsForm.Show();
		}

		private void Control_TakeScreenshot(object sender, EventArgs e) {
			/*lock (inputLock) {
				if (input != null) {
					input.UserPromptSaveScreenshot();
				}
			}*/
			//TODO screenshot
		}

		private void Control_SaveScreenshot(object sender, EventArgs e) {
			//TODO save screenshot
		}
	}
}
