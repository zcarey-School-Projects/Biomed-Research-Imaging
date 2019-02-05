using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearch.UI.Options;

namespace UndergradResearch.UI.OptionsCategories {
	public abstract class IOptionsUI {

		private List<IOptionEntry> entries;

		public IOptionsUI(CameraOptionsUI options, OptionsPanel panel, string libraryVersion) {
			entries = generateEntries(options, libraryVersion);
			if (entries == null) entries = new List<IOptionEntry>();

			foreach (IOptionEntry entry in entries) {
				entry.Parent = panel;
			}
		}

		protected abstract List<IOptionEntry> generateEntries(CameraOptionsUI options, string libraryVersion);

		public void UpdateAll() {
			foreach (IOptionEntry entry in entries) {
				entry.Update();
			}
		}

	}
}
