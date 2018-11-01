using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpinnakerNET;
using SpinnakerNET.GenApi;

namespace UndergradResearchBiomedImaging.Flir.Settings {
	public class PixelFormatSetting : FlirSetting {

		public override string Description { get; protected set; } = "Format of the pixel data.";
		public override string Command { get; protected set; } = "PixelFormat";
		public override string DisplayName { get; protected set; } = "Pixel Format";

		public PixelFormatSetting(FlirCamera camera) : base(camera) {
		}

		public bool TryWriteValue(PixelFormatEnums format) {
			return base.trySetNodeValue(format.ToString());
		}
	}
}
