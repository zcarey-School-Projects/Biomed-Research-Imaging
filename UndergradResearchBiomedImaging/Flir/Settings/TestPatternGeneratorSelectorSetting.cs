using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpinnakerNET;

namespace UndergradResearchBiomedImaging.Flir.Settings {
	public class TestPatternGeneratorSelectorSetting : FlirSetting {

		public override string Description { get; protected set; } = "N/A";
		public override string Command { get; protected set; } = "TestPatternGeneratorSelector";
		public override string DisplayName { get; protected set; } = "Test Pattern Generator Selector";

		public TestPatternGeneratorSelectorSetting(FlirCamera camera) : base(camera) {
		}

		public bool TryWriteValue(TestPatternGeneratorSelectorEnums selector) {
			return trySetNodeValue(selector.ToString());
		}

	}
}
