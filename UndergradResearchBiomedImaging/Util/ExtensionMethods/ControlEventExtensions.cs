using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearch.Util.ExtensionMethods {
	public static class ControlEventExtensions {

		public static void ChangeValueWithoutEvent(this NumericUpDown Control, decimal NewValue, EventHandler method) {
			Control.ValueChanged -= method;
			try {
				Control.Value = NewValue;
			}catch(ArgumentOutOfRangeException e) {
				Console.WriteLine("WARNING: Value out of range: {0} [{1}, {2}], tried to set to {3}.", Control.Name, Control.Minimum, Control.Maximum, NewValue);
				Control.Value = Math.Max(Control.Minimum, Math.Min(Control.Maximum, NewValue));
			}
			Control.ValueChanged += method;
		}

	}
}
