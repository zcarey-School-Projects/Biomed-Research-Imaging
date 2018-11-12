using Emgu.CV;
using Emgu.CV.Structure;
using RobotHelpers;
using RobotHelpers.InputHandling;
using SpinnakerNET;
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

//using Windows.Media.Capture;
//using System.Windows.Storage;

namespace UndergradResearchBiomedImaging {
	public partial class ControlForm : Form {

		private static readonly object inputLock = new object();
		private InputHandler input;
		private Thread streamThread;
		private FPSCounter fpsCounter = new FPSCounter();
		private FlirCameraManager cameraManager = new FlirCameraManager();

		//private static SaveFileDialog saveDialog;
		
		/*static ControlForm() {
			saveDialog = new SaveFileDialog();
			saveDialog.AddExtension = true;
			saveDialog.RestoreDirectory = true;
			saveDialog.Title = "Save Screenshot";
			saveDialog.Filter = "";
		}*/

		public ControlForm() {
			InitializeComponent();
			streamThread = new Thread(streamThreadCall);
			streamThread.Name = "Stream Thread";
			streamThread.IsBackground = true;
		}

		private void ControlForm_Load(object sender, EventArgs e) {
			streamThread.Start();
		}

		private void streamThreadCall() {
			while (true) {
				lock (inputLock) {
					if ((input != null) && (input.IsFrameAvailable())) {
						Image<Bgr, byte> rawImage = input.GetFrame();
						fpsCounter.Tick();
						CameraFeed.InvokeIfRequired(pictureBox => { pictureBox.Image = ((rawImage != null) ? rawImage : new Image<Bgr, byte>(1, 1))/*.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Cubic)*/.Bitmap; });
					} else {
						fpsCounter.Reset();
					}
				}

				FPSStatusLabel.InvokeIfRequired(this, label => { label.Text = fpsCounter.FPS.ToString("N2"); });
				Thread.Sleep(1);
			}
		}

		private void ScreenshotMenuItem_Click(object sender, EventArgs e) {
			lock (inputLock) {
				if (input != null) {
					input.UserPromptSaveScreenshot();
				}
			}
		}

		private void CameraFeed_Resize(object sender, EventArgs e) {
			
		}

		private void ConnectBtn_Click(object sender, EventArgs e) {
			cameraManager.DetectCameras();
			if(cameraManager.NumberOfAvailableCameras() > 0) {
				string version = cameraManager.GetSpinnakerLibraryVersion();
				CameraInfo info = cameraManager.GetCameraInformation(0);
				lock (inputLock) {
					FlirCamera cam = cameraManager.OpenCamera(0);
					input = new FlirCameraInput(cam);
					input.Play();
				}
			}
			
		}

		
	}
}
