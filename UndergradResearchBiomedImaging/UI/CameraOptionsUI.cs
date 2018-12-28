using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.UI.Options;

namespace UndergradResearchBiomedImaging.UI {
	public class CameraOptionsUI {

		public delegate void CameraConnectionHandler(FlirCamera camera);
		public event CameraConnectionHandler OnCameraConnected;
		public event CameraConnectionHandler OnCameraDisconnected;
		
		public FlirCamera Camera { get; private set; }
		private OptionsPanel panel;

		private GainUI gain;

		public CameraOptionsUI(Panel Panel) {
			this.panel = new OptionsPanel(Panel);
			gain = new GainUI(this, panel);
		}

		public void InvokeCameraConnected(FlirCamera camera) {
			Camera = camera;
			OnCameraConnected?.Invoke(camera);
		}

		public void InvokeCameraDisconnected(FlirCamera camera) {
			OnCameraDisconnected?.Invoke(camera);
		}

	}
}
