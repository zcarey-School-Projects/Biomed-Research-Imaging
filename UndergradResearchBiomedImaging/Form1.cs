using Emgu.CV;
using Emgu.CV.Structure;
using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Flir.Nodes;
using UndergradResearchBiomedImaging.UI;
using UndergradResearchBiomedImaging.UI.MenuStrip;
using UndergradResearchBiomedImaging.UI.Options;
using UndergradResearchBiomedImaging.UI.OptionsCategories;
using UndergradResearchBiomedImaging.Util;
using static UndergradResearchBiomedImaging.Util.ImageStream;

//using Windows.Media.Capture;
//using System.Windows.Storage;

namespace UndergradResearchBiomedImaging {
	public partial class ControlForm : Form {

		private static readonly object inputLock = new object();
		private ImageStream input;
		private FlirCameraManager cameraManager = new FlirCameraManager();
		private CameraOptionsUI cameraOptions;
		private bool initialized = false;

		//private static SaveFileDialog saveDialog;
		
		/*static ControlForm() {
			saveDialog = new SaveFileDialog();
			saveDialog.AddExtension = true;
			saveDialog.RestoreDirectory = true;
			saveDialog.Title = "Save Screenshot";
			saveDialog.Filter = "";
		}*/

		public ControlForm() {
			lock (this) {
				InitializeComponent();
				initializeMenuStrips();

				input = new ImageStream();
				input.OnNewImage += OnNewImage;
				input.OnStreamEnded += OnStreamEnded;

				cameraOptions = new CameraOptionsUI(SettingsPanel, input);
				initialized = true;
			}
		}

		private void initializeMenuStrips() {
			TestMenuStrip.DropDownItems.Add(new TestPatternMenuStrip(input));
		}

		private void ControlForm_Load(object sender, EventArgs e) {
			
		}

		private void ControlForm_FormClosing(object sender, FormClosingEventArgs e) {
			lock (this) {
				initialized = false;
				input.Stop();
			}
		}

		private void OnNewImage(ImageStream sender, Bitmap image) {
			lock (this) {
				if (!initialized) return;
				Action setCameraFeed = new Action(() => { CameraFeed.Image = image; });
				Action setFPSLabel = new Action(() => { FPSStatusLabel.Text = sender.FPS.ToString("N2"); });
				if (CameraFeed.InvokeRequired) CameraFeed.BeginInvoke(setCameraFeed);
				else setCameraFeed();
				setFPSLabel(); //TODO Is this needed?
				//this.BeginInvoke(new Action(() => { CameraFeed.Image = image; }));
				//this.BeginInvoke(new Action(() => { FPSStatusLabel.Text = FPS.ToString("N2"); }));
			}
		}

		private void OnStreamEnded(ImageStream sender) {
			if (!initialized) return;
			//TODO beginInvoke is bad practice
			this.BeginInvoke(new Action(() => { CameraFeed.Image = null; }));
			this.BeginInvoke(new Action(() => { FPSStatusLabel.Text = "0"; }));
		}

		private void ScreenshotMenuItem_Click(object sender, EventArgs e) {
			lock (inputLock) {
				if (input != null) {
					input.PromptUserSaveScreenshot();
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
					input.SelectCamera(cam);
					input.Play();
				}
			}
			
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
			input.PromptUserLoadFile();
			input.Play();
		}

		private void NumericStagePosition_ValueChanged(object sender, EventArgs e) {
			
		}

	}
}
