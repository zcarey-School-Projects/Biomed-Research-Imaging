using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.UI.Options;
using UndergradResearchBiomedImaging.UI.OptionsCategories.Options;

namespace UndergradResearchBiomedImaging.UI.OptionsCategories {
	public class CameraOptionsUI {
		/*
				public delegate void CameraConnectionHandler(FlirCamera camera);
				public event CameraConnectionHandler OnCameraConnected;
				public event CameraConnectionHandler OnCameraDisconnected;
				*/
		public FlirProperties FakeProperties { get; } = new FlirProperties("null", null);
		//public FlirCamera Camera { get; private set; }
		public FlirCameraStream Stream { get; private set; }
		private OptionsPanel panel;

		private List<IOptionsUI> options = new List<IOptionsUI>();

		public CameraOptionsUI(Panel Panel, FlirCameraStream stream, string libraryVersion) {
			this.panel = new OptionsPanel(Panel);
			this.Stream = stream;

			options.Add(new CameraInfoUI(this, panel, libraryVersion));
			options.Add(new GainUI(this, panel));
			options.Add(new ExposureUI(this, panel));

			//TODO add events from stream input.on
			//input.OnStreamEnded += onStreamEnded;
		}

		public void Update() {
			panel.Update();
		}
		/*
		private void onSourceChanged(FlirCameraInput sender, FlirCamera NewSource) {
			panel.Update();
		}

		private void onStreamEnded(ImageStream sender) {
			panel.Update();
		}
		*/
	}
}
