using Emgu.CV;
using Emgu.CV.Structure;
using RobotHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

		private readonly FlirCameraStream stream = new FlirCameraStream();
		private FlirCameraManager cameraManager = new FlirCameraManager();
		private CameraOptionsUI cameraOptions;
		private FastRecorder videoWriter; //TODO naming

		public ControlForm() {
			InitializeComponent();

			//Generate drop-down menus
			new TestPatternMenu(TestPatternMenuItem, stream);

			//Generate Camera Options UI
			cameraOptions = new CameraOptionsUI(SettingsPanel, stream, cameraManager.GetSpinnakerLibraryVersion());

			//Set listeners for camera stream
			stream.OnNewImage += FlirCameraStream_OnNewImage;
			stream.OnSourceChanged += FlirCameraStream_OnSourceChanged;
			videoWriter = new FastRecorder(@"temp.avi");
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
			//cameraManager.DetectCameras();
			//if(cameraManager.NumberOfAvailableCameras() > 0) {
				stream.SourceCamera = cameraManager.OpenCamera(0);
			//}
			
		}

		private void Record_Click(object sender, EventArgs e) {
			if (Record.Text == "Record") {
				/*	if (stream == null) return;
					FlirCamera camera = stream.SourceCamera;
					if (camera == null) return;
					//new VideoWriter(Name, fps, size, isColor);
					//new VideoWriter(Name, compressionCode, fps, size, isColor);
					long width = 0;
					long height = 0;
					if(!camera.Properties.Width.TryGetValue(ref width) || !camera.Properties.Height.TryGetValue(ref height)) return;
					lock (this) {
						VideoW = new VideoWriter(@"temp.avi", VideoWriter.Fourcc('M', 'P', '4', '2'), 60, new Size((int)width, (int)height), true);
						if (!VideoW.IsOpened) {
							VideoW.Dispose();
							VideoW = null;
						} else {
							Record.Text = "Stop";
						}
					}*/
				if (videoWriter.Start(stream)) {
					Record.Text = "Stop";
				}
			} else {
				videoWriter.Stop();
				Record.Text = "Record";
				/*lock (this) {
					if((VideoW != null) && (VideoW.IsOpened)) { //TODO can we set the FPS on the fly?
						VideoW.Dispose();
						VideoW = null;
					}
					Record.Text = "Record";
				}*/
			}
		}

		//TODO make reset buttons for options to set to defaults.

	}
}
