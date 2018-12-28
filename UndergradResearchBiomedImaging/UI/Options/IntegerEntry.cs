using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.UI.Options {
	public class IntegerEntry : OptionEntry<NumericUpDown> {

		public IntegerEntry(string name) : base(name) {

		}

		protected override NumericUpDown generateControl(int xPos) {
			NumericUpDown control = new NumericUpDown();
			/*control.Maximum = 0;
			control.Minimum = 0;
			control.Value = 0;*/
			control.Location = new Point(xPos, 3);

			return control;
		}

	}
}
