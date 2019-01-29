using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.UI.OptionsCategories;

namespace UndergradResearchBiomedImaging {
	public partial class CameraOptionsForm : Form {

		private CameraOptionsUI cameraOptions;

		public CameraOptionsForm(FlirCameraManager cameraManager, FlirCameraStream stream) {
			InitializeComponent();
			cameraOptions = new CameraOptionsUI(SettingsPanel, stream, cameraManager.GetSpinnakerLibraryVersion());
			stream.OnSourceChanged += CameraStream_OnSourceChanged;
		}

		private void CameraOptionsForm_Load(object sender, EventArgs e) {
			//TODO make reset buttons for options to set to defaults.
		}

		private void CameraOptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		private void CameraStream_OnSourceChanged(FlirCameraStream sender, FlirCamera source) {
			cameraOptions.Update();
		}

	}
}
