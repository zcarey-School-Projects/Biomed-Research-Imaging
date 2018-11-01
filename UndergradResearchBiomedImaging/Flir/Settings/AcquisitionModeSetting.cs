using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpinnakerNET;

namespace UndergradResearchBiomedImaging.Flir.Settings {
	public class AcquisitionModeSetting : FlirSetting {

		public override string Description { get; protected set; } = "Sets the acquisition mode of the device.";
		public override string Command { get; protected set; } = "AcquisitionMode";
		public override string DisplayName { get; protected set; } = "Acquisition Mode";

		public AcquisitionModeSetting(FlirCamera camera) : base(camera) {
		}

		public bool TryWriteValue(AcquisitionModeEnums mode) {
			return trySetNodeValue(mode.ToString());
		}

	}
}
