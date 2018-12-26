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

namespace UndergradResearchBiomedImaging.UI {

	//TODO for autofilled properties, use isReadable and isWritable for grayed out(not writable) or "-"(not readable)
	public class GainUI {

		public const int Height = 118;

		private NumericUpDown GainControl;
		private ComboBox AutoGainControl;
		private NumericUpDown UpperGainControl;
		private NumericUpDown LowerGainControl;

		public GainUI(Panel controlPanel, int yStart) {
			OptionsPanel panel = new OptionsPanel(controlPanel);

			OptionsCategory GainCategory = new OptionsCategory("Gain");
			GainCategory.Parent = panel;

			FloatEntry GainEntry = new FloatEntry("Gain");
			GainEntry.Parent = GainCategory;

			FloatEntry Test = new FloatEntry("Test");
			Test.Parent = GainCategory; //TODO bevel sizes

			//Gain
			/*Label GainLabel = new Label();
			GainLabel.Text = "Gain: ";
			GainLabel.Location = new Point(3, yStart + 5);
			GainLabel.Parent = controlPanel;

			GainControl.Location = new Point(115, yStart + 3);
			GainGainControl = new NumericUpDown();
			Control.DecimalPlaces = 2;
			GainControl.Minimum = 10; //TODO
			GainControl.Maximum = 0; //TODO
			//GainControl.Value = 0.5M; //TODO
			GainControl.Parent = controlPanel;
			GainControl.BringToFront();


			//Auto Gain
			Label AutoLabel = new Label();
			AutoLabel.Text = "Auto Gain: ";
			AutoLabel.Location = new Point(3, yStart + 34);
			AutoLabel.Parent = controlPanel;

			AutoGainControl = new ComboBox();
			AutoGainControl.Location = new Point(114, yStart + 31);
			AutoGainControl.Text = GainAutoEnums.Off.ToString();
			foreach (GainAutoEnums type in Enum.GetValues(typeof(GainAutoEnums))) {
				if (type == GainAutoEnums.NUM_GAINAUTO) continue;
				AutoGainControl.Items.Add(type.ToString());
			}
			AutoGainControl.Parent = controlPanel;
			AutoGainControl.BringToFront();


			//Upper Gain
			Label UpperGainLabel = new Label();
			UpperGainLabel.Text = "    - Upper Limit";
			UpperGainLabel.Location = new Point(3, yStart + 63);
			UpperGainLabel.Parent = controlPanel;

			UpperGainControl = new NumericUpDown();
			UpperGainControl.Location = new Point(114, yStart + 63);
			UpperGainControl.DecimalPlaces = 2;
			UpperGainControl.Minimum = 10; //TODO
			UpperGainControl.Maximum = 0; //TODO
			//UpperGainControl.Value = 0.5M; //TODO
			UpperGainControl.Parent = controlPanel;
			UpperGainControl.BringToFront();
			

			//Lower Gain
			Label LowerGainLabel = new Label();
			LowerGainLabel.Text = "    - Lower Limit";
			LowerGainLabel.Location = new Point(3, yStart + 93);
			LowerGainLabel.Parent = controlPanel;

			LowerGainControl = new NumericUpDown();
			LowerGainControl.Location = new Point(114, yStart + 91);
			LowerGainControl.DecimalPlaces = 2;
			LowerGainControl.Minimum = 10; //TODO
			LowerGainControl.Maximum = 0; //TODO
			//LowerGainControl.Value = 0.5M; //TODO
			LowerGainControl.Parent = controlPanel;
			LowerGainControl.BringToFront();

			//Bevel
			Label Bevel = new Label();
			Bevel.Location = new Point(3, yStart + 116);
			Bevel.Width = controlPanel.Width - 6;
			Bevel.AutoSize = false;
			Bevel.Height = 2;
			Bevel.BorderStyle = BorderStyle.Fixed3D;
			Bevel.Parent = controlPanel;
			Bevel.BringToFront();

			Disable();*/
		}

		public void Disable() {
			GainControl.Enabled = false;
			GainControl.ResetText(); //TODO?

			AutoGainControl.Enabled = false;
			AutoGainControl.ResetText();

			UpperGainControl.Enabled = false;
			UpperGainControl.ResetText(); //TODO?

			LowerGainControl.Enabled = false;
			LowerGainControl.ResetText(); //TODO?
		}

		/*FloatNode n1 = camera.Properties.Gain;
			EnumNode<GainAutoEnums> n2 = camera.Properties.GainAuto; //Off, once, continuous
			FloatNode n4 = camera.Properties.AutoGainUpperLimit;
			FloatNode n5 = camera.Properties.AutoGainLowerLimit;
			*/
	}
}
