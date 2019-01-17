using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;

namespace UndergradResearchBiomedImaging.UI.MenuStrip {
	public class TestPatternMenu : EnumMenuStrip<TestPatternEnums>{

		public TestPatternMenu(ToolStripMenuItem BaseMenu, FlirCameraStream stream) : base(BaseMenu, stream, TestPatternEnums.NUM_TESTPATTERN, true) {

		}

		protected override bool setProperty(FlirCamera camera, TestPatternEnums value) {
			return camera.Properties.TestPattern.TrySetValue(value);
		}

	}
}
