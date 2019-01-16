using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearchBiomedImaging.Flir.Nodes;

namespace UndergradResearchBiomedImaging.Flir {

	public class FlirProperties {

		public EnumNode<PixelFormatEnums> PixelFormat { get; private set; }
		public EnumNode<AcquisitionModeEnums> AcquisitionMode { get; private set; }

		public FlirProperties(IManagedCamera camera) {
			PixelFormat = new EnumNode<PixelFormatEnums>(camera, "PixelFormat");
			AcquisitionMode = new EnumNode<AcquisitionModeEnums>(camera, "AcquisitionMode");
		}

	}
}
