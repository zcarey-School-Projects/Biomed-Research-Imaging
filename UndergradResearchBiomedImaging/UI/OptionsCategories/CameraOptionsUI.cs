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
		public FlirProperties FakeProperties { get; } = new FlirProperties(null);
		public FlirCamera Camera { get; private set; }
		public FlirCameraInput Input { get; private set; }
		private OptionsPanel panel;

		private List<IOptionsUI> options = new List<IOptionsUI>();

		public CameraOptionsUI(Panel Panel, FlirCameraInput input) {
			this.panel = new OptionsPanel(Panel);
			this.Input = input;

			options.Add(new GainUI(this, panel));

			input.OnSourceChanged += onSourceChanged;
			input.OnStreamEnded += onStreamEnded;
		}

		private void onSourceChanged(ImageStream sender, StreamType newSource) {
			panel.Update();
		}

		private void onStreamEnded(ImageStream sender) {
			panel.Update();
		}

	}
}
