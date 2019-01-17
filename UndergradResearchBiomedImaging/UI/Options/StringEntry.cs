using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.UI.Options {
	public class StringEntry : OptionEntry<TextBox, Flir.Nodes.StringNode, IString, string> {

		public StringEntry(string name, Property<FlirProperties, Flir.Nodes.StringNode> property, FlirCameraStream stream) : base(name, property, stream) {
		}

		protected override void addValueChangedEvent(TextBox entryControl, EventHandler eventHandler) {
			entryControl.TextChanged += eventHandler;
		}

		protected override void checkValueLimits(TextBox entryControl, Flir.Nodes.StringNode node) {
			//No limits to check
		}

		protected override TextBox generateControl(int xPos) {
			TextBox control = new TextBox();
			control.Location = new Point(xPos, 3);

			return control;
		}

		protected override string getCurrentValue(TextBox entryControl) {
			return entryControl.Text;
		}

		protected override void SetControlValue(TextBox entryControl, string newValue) {
			entryControl.Text = newValue;
		}
	}
}
