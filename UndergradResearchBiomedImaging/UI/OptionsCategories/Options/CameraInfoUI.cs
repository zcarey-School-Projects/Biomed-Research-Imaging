using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Flir.Nodes;
using UndergradResearchBiomedImaging.UI.Options;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.UI.OptionsCategories.Options {
	public class CameraInfoUI : IOptionsUI {

		public CameraInfoUI(CameraOptionsUI options, OptionsPanel panel, string libraryVersion) : base(options, panel, libraryVersion) { //TODO version is hacky

		}

		protected override List<IOptionEntry> generateEntries(CameraOptionsUI options, string libraryVersion) {
			List<IOptionEntry> entries = new List<IOptionEntry>();

			OptionsCategory InfoCategory = new OptionsCategory("Info");
			entries.Add(InfoCategory);

			ConstantValueEntry LibraryVersionEntry = new ConstantValueEntry("Library Version", libraryVersion);
			LibraryVersionEntry.Parent = InfoCategory;

			StringEntry VendorNameEntry = new StringEntry("Vendor Name", new Property<FlirProperties, StringNode>(nameof(options.FakeProperties.DeviceVendorName)), options.Input);
			VendorNameEntry.Parent = InfoCategory;

			StringEntry ModelName = new StringEntry("Model Name", new Property<FlirProperties, StringNode>(nameof(options.FakeProperties.DeviceModelName)), options.Input);
			ModelName.Parent = InfoCategory;

			return entries;
		}

	}
}
