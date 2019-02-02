using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.Util.ExtensionMethods {
	public static class ControlEventExtensions {

		public static void ChangeValueWithoutEvent(this NumericUpDown Control, decimal NewValue, EventHandler method) {
			Control.ValueChanged -= method;
			Control.Value = NewValue;
			Control.ValueChanged += method;
		}

	}
}
