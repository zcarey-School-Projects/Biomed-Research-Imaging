using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearch.Flir;
using UndergradResearch.Flir.Nodes;
using UndergradResearch.Util;

namespace UndergradResearch.UI.Options {
	public class FloatEntry : NumericalEntry<FloatNode, IFloat, double> {

		private Label unitLabel;

		public FloatEntry(string name, Property<FlirProperties, FloatNode> property, FlirCameraStream stream) : base(name, property, stream) {

		}

		protected override NumericUpDown generateControl(int xPos) {
			NumericUpDown control = new NumericUpDown();
			control.DecimalPlaces = 2;
			control.Location = new Point(xPos, 3);

			unitLabel = new Label();
			unitLabel.Location = new Point(xPos + control.Width, 5);
			unitLabel.ResetText();

			control.ParentChanged += (object sender, EventArgs args) => { unitLabel.Parent = control.Parent; };
			control.LocationChanged += (object sender, EventArgs args) => { unitLabel.Location = new Point(control.Location.X + control.Width, control.Location.Y + 2); };

			return control;
		}

		protected override void addValueChangedEvent(NumericUpDown control, EventHandler eventHandler) {
			control.ValueChanged += eventHandler;
		}

		protected override double getCurrentValue(NumericUpDown control) {
			return decimal.ToDouble(control.Value);
		}
		//TODO make disconnect button.
		protected override void SetControlValue(NumericUpDown control, double newValue) {
			decimal value = (decimal)newValue;
			try {
				control.Value = (decimal)newValue;
			}catch(ArgumentOutOfRangeException e) {
				Console.WriteLine("WARNING: Float value outside of range: {0}, [{1}, {2}], given {3}.", EntryName, control.Minimum, control.Maximum, value);
				control.Value = Math.Max(control.Minimum, Math.Min(control.Maximum, value));
			}
		}

		protected override void checkValueLimits(NumericUpDown control, FloatNode node) {
			if (node.Minimum == null) {
				double lowest = double.MinValue;
				control.Minimum = (decimal)lowest;
			} else {
				control.Minimum = (decimal)((double)node.Minimum);
			}

			if (node.Maximum == null) {
				double highest = double.MaxValue;
				control.Maximum = (decimal)highest;
			} else {
				control.Maximum = (decimal)((double)node.Maximum);
			}

			unitLabel.Text = node.Unit;
		}

		protected override int getNumberOfDecimals() {
			return 2;
		}

		protected override decimal getIncrement() {
			int decimals = getNumberOfDecimals();
			decimal inc = decimal.One;
			while ((decimals--) > 0) {
				inc /= 10;
			}

			return inc;
		}
	}
}
