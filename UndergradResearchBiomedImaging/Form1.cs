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
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;

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
			initializeMenuStrips();
			streamThread = new Thread(streamThreadCall);
			streamThread.Name = "Stream Thread";
			streamThread.IsBackground = true;
		}

		private void initializeMenuStrips() {
			fillMenuStripWithValues<TestPatternEnums>(nameof(FlirCamera.TestPattern), testImageToolStripMenuItem, TestPatternEnums.NUM_TESTPATTERN, true);
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

		#region Auto-Fill Menu Lists

		/// <summary>
		/// Returns all possible enum values.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private static IEnumerable<TEnum> GetValues<TEnum>() {
			return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
		}
		/*
		/// <summary>
		/// Returns the enum value parsed from a string. Returns null if not found.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="str"></param>
		/// <returns></returns>
		private static TEnum? GetEnumValue<TEnum>(string str) where TEnum : struct {
			TEnum val;
			if (Enum.TryParse(str, out val)) return val;
			else return null;
		}
		*/
		/// <summary>
		/// Fills a Menu Strip with all values of an Enum type. 
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="menu">The menu to be filled with items.</param>
		/// <param name="ignoreCase">The enum type to ignore. Pass null for none.</param>
		/// <param name="onItemClick">Callback when an item gets clicked.</param>
		/// <param name="checkItems">If the items should be "checked" when clicked.</param>
		private void fillMenuStripWithValues<TEnum>(string propertyName, ToolStripMenuItem menu, TEnum? ignoreCase, bool checkItems) where TEnum : struct {
			menu.DropDownItems.Clear();
			foreach (TEnum enumVal in GetValues<TEnum>()) {
				if (!enumVal.Equals(ignoreCase)) {
					EnumEntryStripMenuItem<TEnum> item = new EnumEntryStripMenuItem<TEnum>(this, propertyName, enumVal);
					item.CheckOnClick = checkItems;
					if (checkItems) item.CheckedChanged += uncheckOtherItems;
					menu.DropDownItems.Add(item);
				}
			}

			if (menu.DropDownItems.Count == 0) {
				ToolStripItem none = new ToolStripMenuItem("(none)");
				none.Enabled = false;
				menu.DropDownItems.Add(none);
			}
		}

		/// <summary>
		/// In a list of drop-down items, unchecks all items except the one that was clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void uncheckOtherItems(object sender, EventArgs e) {
			if (sender is ToolStripMenuItem) {
				ToolStripMenuItem menu = (ToolStripMenuItem)sender;
				if (menu.Checked == false) return;
				foreach (ToolStripMenuItem item in menu.GetCurrentParent().Items) {
					if (item != menu) {
						item.Checked = false;
					}
				}
			}
		}

		private class EnumEntryStripMenuItem<TEnum> : ToolStripMenuItem where TEnum : struct{

			private ControlForm form;
			private string propertyName;
			private TEnum value;

			private delegate bool TrySetValue();
			public EnumEntryStripMenuItem(ControlForm form, string propertyName, TEnum value) : base(value.ToString()) {
				this.form = form;
				this.propertyName = propertyName;
				this.value = value;
				Click += onClick;
			}
			
			public void onClick(object sender, EventArgs e) {
				try {
					InputHandler input = form.input;
					if (!(input is FlirCameraInput)) throw new Exception("Could not find FlirCameraInput.");
					FlirCameraInput camInput = (FlirCameraInput)input;
					FlirCamera cam = camInput.Camera;
					if (cam == null) throw new Exception("Null FlirCamera.");
					Type type = cam.GetType();
					if (type == null) throw new Exception("Null type.");
					PropertyInfo property = type.GetProperty(propertyName);
					if (property == null) throw new Exception("Could not find property.");
					if (!property.CanRead) throw new Exception("Could not read property.");
					object value = property.GetValue(cam, null);
					if (value == null) throw new Exception("Property does not have a value.");
					if (!(value is EnumNode<TEnum>)) throw new Exception("Property value is not of the required type.");
					EnumNode<TEnum> node = (EnumNode<TEnum>)value;
					if (!node.TrySetValue(this.value)) {
						Console.WriteLine("Was unable to set enum value.");
					}
				}catch (Exception ex) {
					Console.WriteLine("\nCould not set value: '" + propertyName + "'.");
					Console.WriteLine(ex.Message);
					Console.WriteLine(ex.StackTrace);
					Console.WriteLine();
				}
			}
		}

		#endregion

	}
}
