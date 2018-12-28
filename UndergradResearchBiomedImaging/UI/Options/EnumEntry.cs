using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.UI.Options {
	public class EnumEntry<EnumType> : OptionEntry<ComboBox> where EnumType : struct{

		public delegate void SelectionChangedHandler(EnumType? NewValue);
		public event SelectionChangedHandler OnSelectionChanged;

		private EnumType? ignoreCase;
		private Dictionary<int, EnumType> listValues = new Dictionary<int, EnumType>();
		private ComboBox listControl;

		public EnumEntry(string name, EnumType? IgnoreCase) : base(name) {
			ignoreCase = IgnoreCase;
		}

		protected override ComboBox generateControl(int xPos) {
			listControl = new ComboBox();
			listControl.Location = new Point(xPos, 3);
			
			foreach(EnumType entry in Enum.GetValues(typeof(EnumType))) {
				if (entry.Equals(ignoreCase))  continue;
				int index = listControl.Items.Add(entry.ToString());
				listValues.Add(index, entry);
			}

			listControl.SelectedIndexChanged += OnSelectionIndexChanged;

			return listControl;
		}

		private void OnSelectionIndexChanged(object sender, EventArgs args) {
			EnumType val;
			if(listValues.TryGetValue(listControl.SelectedIndex, out val)) {
				OnSelectionChanged?.Invoke(val);
			} else {
				OnSelectionChanged?.Invoke(null);
			}
		}

	}
}
