using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.UI.Options;

namespace UndergradResearchBiomedImaging.UI.OptionsCategories.Options {
	public abstract class IOptionsUI {

		private List<IOptionEntry> entries;

		public IOptionsUI(CameraOptionsUI options, OptionsPanel panel) {
			entries = generateEntries(options);
			if (entries == null) entries = new List<IOptionEntry>();

			foreach(IOptionEntry entry in entries) {
				entry.Parent = panel;
			}
		}

		protected abstract List<IOptionEntry> generateEntries(CameraOptionsUI options);

		public void UpdateAll() {
			foreach(IOptionEntry entry in entries) {
				entry.Update();
			}
		}

	}
}
