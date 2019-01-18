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

//using Windows.Media.Capture;
//using System.Windows.Storage;

namespace UndergradResearchBiomedImaging {
	public partial class ControlForm : Form {

		private readonly FlirCameraStream stream = new FlirCameraStream();
		private FlirCameraManager cameraManager = new FlirCameraManager();
		private CameraOptionsUI cameraOptions;

		public ControlForm() {
			InitializeComponent();

			//Generate drop-down menus
			new TestPatternMenu(TestPatternMenuItem, stream);

			//Generate Camera Options UI
			cameraOptions = new CameraOptionsUI(SettingsPanel, stream, cameraManager.GetSpinnakerLibraryVersion());

			//Set listeners for camera stream
			stream.OnNewImage += FlirCameraStream_OnNewImage;
			stream.OnSourceChanged += FlirCameraStream_OnSourceChanged;
		}

		private void ControlForm_Load(object sender, EventArgs e) {
			stream.SourceCamera = cameraManager.OpenCamera(0); //Attempts to load a camera on start-up
		}

		private void FlirCameraStream_OnNewImage(FlirCameraStream sender, Image<Bgr, byte> Image) {
			CameraFeed.Invoke(new Action(() => { CameraFeed.Image = (Image == null) ? null : Image.Bitmap; }));
			FPSStatusLabel.Text = sender.FPS.ToString("N2").PadLeft(3) + " FPS";
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
			cameraManager.DetectCameras();
			if(cameraManager.NumberOfAvailableCameras() > 0) {
				stream.SourceCamera = cameraManager.OpenCamera(0);
			}
			
		}

		//TODO make reset buttons for options to set to defaults.

	}
}
