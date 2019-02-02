using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging {
	public partial class ScreenshotViewer : Form {

		private static SaveFileDialog SaveScreenshotDialog;
		private static Dictionary<int, ImageFormat> ImageExtensions = new Dictionary<int, ImageFormat>();

		static ScreenshotViewer() {
			SaveScreenshotDialog = new SaveFileDialog();
			SaveScreenshotDialog.AddExtension = true;
			SaveScreenshotDialog.OverwritePrompt = true;
			SaveScreenshotDialog.RestoreDirectory = true;
			SaveScreenshotDialog.Title = "Save Screenshot";

			ImageExtensions.Add(0, ImageFormat.Png);
			ImageExtensions.Add(1, ImageFormat.Jpeg);
			ImageExtensions.Add(2, ImageFormat.Gif);
			ImageExtensions.Add(3, ImageFormat.Bmp);
			ImageExtensions.Add(4, ImageFormat.Emf);
			ImageExtensions.Add(5, ImageFormat.Exif);
			ImageExtensions.Add(6, ImageFormat.Icon);
			ImageExtensions.Add(7, ImageFormat.Tiff);
			//Text files (*.txt)|*.txt|All files (*.*)|*.*
			string filter = "";
			for (int i = 0; i < ImageExtensions.Count; i++) {
				ImageFormat format;
				if (ImageExtensions.TryGetValue(i, out format)) {
					filter += format.ToString() + " (*." + format.ToString().ToLower() + ")|*." + format.ToString().ToLower() + "|";
				}
			}

			SaveScreenshotDialog.Filter = filter.TrimEnd('|');
		}

		private ScreenshotViewer(Image image) {
			InitializeComponent();
			PictureBox_Screenshot.Image = image;
			DialogResult = DialogResult.Cancel;
		}

		private void Btn_Save_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Image screenshot = PictureBox_Screenshot.Image;
			if (screenshot != null) {
				if (SaveScreenshotDialog.ShowDialog() == DialogResult.OK) {
					ImageFormat format;
					if (ImageExtensions.TryGetValue(SaveScreenshotDialog.FilterIndex, out format)) {
						try {
							screenshot.Save(SaveScreenshotDialog.FileName, format);
						} catch (Exception ex) {
							Console.WriteLine("Error writing file: " + ex.Message);
							MessageBox.Show("Error saving file.");
						}
					} else {
						MessageBox.Show("Error finding format.");
					}
				}
			}
		}

		private void Btn_Cancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		/// <summary>Returns abort, canceled, or OK.</summary>
		public static DialogResult Show(Image image) {
			if (image == null) return DialogResult.Abort;
			ScreenshotViewer viewer = new ScreenshotViewer(image);
			viewer.ShowDialog();
			return viewer.DialogResult;
		}
	}
}
