using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Flir.Nodes;
using UndergradResearchBiomedImaging.UI.Options;

namespace UndergradResearchBiomedImaging.UI.OptionsCategories {

	//TODO for autofilled properties, use isReadable and isWritable for grayed out(not writable) or "-"(not readable)
	public class GainUI {

		FlirCamera camera;

		FloatEntry GainEntry;
		EnumEntry<GainAutoEnums> AutoGainEntry;
		FloatEntry UpperGainEntry;
		FloatEntry LowerGainEntry;

		public GainUI(CameraOptionsUI ui, OptionsPanel panel) {
			OptionsCategory GainCategory = new OptionsCategory("Gain");
			GainCategory.Parent = panel;

			GainEntry = new FloatEntry("Gain");
			GainEntry.Parent = GainCategory;

			AutoGainEntry = new EnumEntry<GainAutoEnums>("Auto Gain", GainAutoEnums.NUM_GAINAUTO);
			AutoGainEntry.Parent = GainCategory;

			UpperGainEntry = new FloatEntry("  - Upper Limit");
			UpperGainEntry.Parent = GainCategory;

			LowerGainEntry = new FloatEntry("  - Lower Limit");
			LowerGainEntry.Parent = GainCategory;

			//Disable();

			ui.OnCameraDisconnected += (FlirCamera cam) => { Disable(); };
		}

		public void Disable() {
			GainEntry.Enabled = false;
			GainEntry.ClearTest();

			AutoGainEntry.Enabled = false;
			AutoGainEntry.ClearTest();

			UpperGainEntry.Enabled = false;
			UpperGainEntry.ClearTest();

			LowerGainEntry.Enabled = false;
			LowerGainEntry.ClearTest();
		}

		/*FloatNode n1 = camera.Properties.Gain;
			EnumNode<GainAutoEnums> n2 = camera.Properties.GainAuto; //Off, once, continuous
			FloatNode n4 = camera.Properties.AutoGainUpperLimit;
			FloatNode n5 = camera.Properties.AutoGainLowerLimit;
			*/
	}
}
