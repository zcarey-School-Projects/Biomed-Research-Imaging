using Emgu.CV;
using Emgu.CV.Structure;
using RobotHelpers;
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

		private readonly FlirCameraStream stream = new FlirCameraStream();
		private FlirCameraManager cameraManager = new FlirCameraManager();
		private CameraOptionsUI cameraOptions;
		private FastRecorder videoWriter;

		public ControlForm() {
			InitializeComponent();
			CameraFeed.Image = null; //Clears the test image.

			//Generate drop-down menus
			new TestPatternMenu(TestPatternMenuItem, stream);

			//Generate Camera Options UI
			cameraOptions = new CameraOptionsUI(SettingsPanel, stream, cameraManager.GetSpinnakerLibraryVersion());

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

			cameraOptions.Update();
		}

		private void ScreenshotMenuItem_Click(object sender, EventArgs e) {
			/*lock (inputLock) {
				if (input != null) {
					input.UserPromptSaveScreenshot();
				}
			}*/
			//TODO screenshot
		}

		private void ConnectBtn_Click(object sender, EventArgs e) {
			stream.SourceCamera = cameraManager.OpenCamera(0);
		}

		private void Record_Click(object sender, EventArgs e) {
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

		//TODO make reset buttons for options to set to defaults.
		//TODO camera feed gets covered up?
	}
}
