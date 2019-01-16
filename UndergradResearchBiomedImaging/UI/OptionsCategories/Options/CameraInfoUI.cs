using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearchBiomedImaging.UI.Options;

namespace UndergradResearchBiomedImaging.UI.OptionsCategories.Options {
	public class CameraInfoUI : IOptionsUI {

		public CameraInfoUI(CameraOptionsUI options, OptionsPanel panel) : base(panel) {

		}

		protected override List<IOptionEntry> generateEntries(CameraOptionsUI options) {
			options.FakeProperties.DeviceVendorName;
			options.FakeProperties.DeviceModelName;
		}

	}
}
