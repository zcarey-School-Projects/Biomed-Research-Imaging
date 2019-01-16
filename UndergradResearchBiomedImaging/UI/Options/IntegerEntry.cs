using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Flir.Nodes;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.UI.Options {
	public class IntegerEntry : NumericalEntry<IntegerNode, IInteger, long> {

		public IntegerEntry(string name, Property<FlirProperties, IntegerNode> property, FlirCameraInput input) : base(name, property, input) {

		}

		protected override NumericUpDown generateControl(int xPos) {
			NumericUpDown control = new NumericUpDown();
			control.Location = new Point(xPos, 3);

			return control;
		}

		protected override void addValueChangedEvent(NumericUpDown entryControl, EventHandler eventHandler) {
			entryControl.ValueChanged += eventHandler;
		}

		protected override long getCurrentValue(NumericUpDown entryControl) {
			return decimal.ToInt64(entryControl.Value);
		}

		protected override void SetControlValue(NumericUpDown entryControl, long newValue) {
			entryControl.Value = (decimal)newValue;
		}

		protected override void checkValueLimits(NumericUpDown entryControl, IntegerNode node) {
			if (node.Minimum == null) {
				long lowest = long.MinValue;
				entryControl.Minimum = (decimal)lowest;
			} else {
				entryControl.Minimum = (decimal)((long)node.Minimum);
			}

			if (node.Maximum == null) {
				long highest = long.MaxValue;
				entryControl.Maximum = (decimal)highest;
			} else {
				entryControl.Maximum = (decimal)((long)node.Maximum);
			}

			long? inc = node.Increment;
			if (inc != null) {
				entryControl.Increment = (long)inc;
			}
		}

		protected override int getNumberOfDecimals() {
			return 0;
		}

		protected override decimal getIncrement() {
			return 1;
		}
	}
}
