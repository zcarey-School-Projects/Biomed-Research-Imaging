using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir.FlirSettings {
	public class AcquisitionMode : FlirSetting {
		public override string Description { get; protected set; } = "Sets the acquisition mode of the device.";
	}
}
