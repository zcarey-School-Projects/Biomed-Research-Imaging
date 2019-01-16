using Emgu.CV;
using Emgu.CV.Structure;
using RobotHelpers;
using RobotHelpers.InputHandling;
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
using UndergradResearchBiomedImaging.UI.OptionsCategories;

//using Windows.Media.Capture;
//using System.Windows.Storage;

namespace UndergradResearchBiomedImaging {
	public partial class ControlForm : Form {

		private static readonly object inputLock = new object();
		private readonly FlirCameraInput input = new FlirCameraInput();
		private Thread streamThread;
		private FPSCounter fpsCounter = new FPSCounter();
		private FlirCameraManager cameraManager = new FlirCameraManager();
		private CameraOptionsUI cameraOptions;

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

			cameraOptions = new CameraOptionsUI(SettingsPanel, input);
		}

		private void ControlForm_Load(object sender, EventArgs e) {
			streamThread.Start();
			//TODO populatePropertiesList(null, null);
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
				//string version = cameraManager.GetSpinnakerLibraryVersion();
				//CameraInfo info = cameraManager.GetCameraInformation(0);
				//populatePropertiesList(version, info);
				lock (inputLock) {
					input.SetCamera(cameraManager.OpenCamera(0));
					input.Play();
					cameraOptions.Update();
				}
			}
			
		}
		/*
		private void populatePropertiesList(string version, CameraInfo info) {
			CameraProperties.Clear();
			CameraProperties.Columns.Add("Property", CameraProperties.Width / 2, HorizontalAlignment.Left);
			CameraProperties.Columns.Add("Value", CameraProperties.Width / 2, HorizontalAlignment.Left);

			ListViewItem propItem = CameraProperties.Items.Add("Library Version");
			propItem.SubItems.Add((version != null) ? version : "N/A");
			
			if(info != null) {
				propItem = CameraProperties.Items.Add("Vendor");
				propItem.SubItems.Add(info.VendorName);

				propItem = CameraProperties.Items.Add("Device Model");
				propItem.SubItems.Add(info.DeviceModel);

				foreach(InfoNode node in info.DeviceInformation) {
					propItem = CameraProperties.Items.Add(node.DisplayName);
					propItem.SubItems.Add(node.Value);
				}
			}

		}
		*/
		private void CameraProperties_Resize(object sender, EventArgs e) {
			foreach(ColumnHeader col in CameraProperties.Columns) {
				col.Width = CameraProperties.Width / CameraProperties.Columns.Count;
			}
		}

	}
}
