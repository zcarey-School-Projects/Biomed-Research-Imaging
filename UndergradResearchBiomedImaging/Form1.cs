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
			fillMenuStripWithValues<TestPatternEnums>(testImageToolStripMenuItem, TestPatternEnums.NUM_TESTPATTERN, TestPattern_MenuItem_Click, true);
			fillMenuStripWithValues<TestPatternGeneratorSelectorEnums>(testPatternStripMenuItem, TestPatternGeneratorSelectorEnums.NUM_TESTPATTERNGENERATORSELECTOR, TestPatternGenerator_MenuItem_Click, true);

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
				lock (inputLock) {
					FlirCamera cam = cameraManager.GetCamera(0);
					input = new FlirCameraInput(cam);
					input.Play();
				}
			}
			
		}

		#region Auto-fill Menu Item Callbacks
/*
		private delegate bool TrySetValue<TEnum>(TEnum value) where TEnum : struct;
		private void TrySetCameraValue<TEnum>(object sender, TrySetValue<TEnum> setValueFunc) where TEnum : struct{
			if (!(sender is ToolStripMenuItem)) return;
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			TEnum? value = GetEnumValue<TEnum>(item.Text);
			if((value != null) && (input != null) && (input is FlirCameraInput)) {
				FlirCamera cam = ((FlirCameraInput)input).Camera;
				c
			}
		}
		*/
		private void TestPattern_MenuItem_Click(object sender, EventArgs e) {
			if (!(sender is ToolStripMenuItem)) return;
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			TestPatternEnums? value = GetEnumValue<TestPatternEnums>(item.Text);
			if((value != null) && (input != null) && (input is FlirCameraInput)) {
				FlirCamera cam = ((FlirCameraInput)input).Camera;
				cam.TrySetTestPattern((TestPatternEnums)value);
			}
		}

		private void TestPatternGenerator_MenuItem_Click(object sender, EventArgs e) {
			if (!(sender is ToolStripMenuItem)) return;
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			TestPatternGeneratorSelectorEnums? value = GetEnumValue<TestPatternGeneratorSelectorEnums>(item.Text);
			if ((value != null) && (input != null) && (input is FlirCameraInput)) {
				FlirCamera cam = ((FlirCameraInput)input).Camera;
				cam.TrySetTestPatternGeneratorSelector((TestPatternGeneratorSelectorEnums)value);
			}
		}

		#endregion

		#region Auto-Fill Menu Lists

		/// <summary>
		/// Returns all possible enum values.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private static IEnumerable<T> GetValues<T>() {
			return Enum.GetValues(typeof(T)).Cast<T>();
		}

		/// <summary>
		/// Returns the enum value parsed from a string. Returns null if not found.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="str"></param>
		/// <returns></returns>
		private static TEnum? GetEnumValue<TEnum>(string str) where TEnum : struct {
			TEnum val;
			if(Enum.TryParse(str, out val)) {
				return val;
			} else {
				return null;
			}
		}

		/// <summary>
		/// Fills a Menu Strip with all values of an Enum type. 
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="menu">The menu to be filled with items.</param>
		/// <param name="ignoreCase">The enum type to ignore. Pass null for none.</param>
		/// <param name="onItemClick">Callback when an item gets clicked.</param>
		/// <param name="checkItems">If the items should be "checked" when clicked.</param>
		private static void fillMenuStripWithValues<TEnum>(ToolStripMenuItem menu, TEnum? ignoreCase, EventHandler onItemClick, bool checkItems) where TEnum : struct {
			menu.DropDownItems.Clear();
			foreach (TEnum enumVal in GetValues<TEnum>()) {
				if (!enumVal.Equals(ignoreCase)) {
					ToolStripMenuItem item = new ToolStripMenuItem(enumVal.ToString());
					item.Click += onItemClick;
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
			if(sender is ToolStripMenuItem) {
				ToolStripMenuItem menu = (ToolStripMenuItem)sender;
				if (menu.Checked == false) return;
				foreach(ToolStripMenuItem item in menu.GetCurrentParent().Items) {
					if (item != menu) {
						item.Checked = false;
					}
				}
			}
		}

		#endregion

	}
}
