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
	public class EnumEntry<EnumType> : OptionEntry<ComboBox, EnumNode<EnumType>, IEnum, EnumType> where EnumType : struct {

		private EnumType? ignoreCase;
		private EnumType defaultValue;
		private Dictionary<int, EnumType> listValues = new Dictionary<int, EnumType>();

		public EnumEntry(string name, EnumType DefaultValue, EnumType? IgnoreCase, Property<FlirProperties, EnumNode<EnumType>> property, FlirCameraStream stream) : base(name, property, stream) {
			defaultValue = DefaultValue;
			ignoreCase = IgnoreCase;
		}

		protected override ComboBox generateControl(int xPos) {
			ComboBox listControl = new ComboBox();
			listControl.Location = new Point(xPos, 3);

			foreach (EnumType entry in Enum.GetValues(typeof(EnumType))) {
				if (entry.Equals(ignoreCase)) continue;
				int index = listControl.Items.Add(entry.ToString());
				listValues.Add(index, entry);
			}

			return listControl;
		}

		protected override void addValueChangedEvent(ComboBox entryControl, EventHandler eventHandler) {
			entryControl.SelectedIndexChanged += eventHandler;
		}

		protected override EnumType getCurrentValue(ComboBox entryControl) {
			int index = entryControl.SelectedIndex;
			EnumType value;
			if (listValues.TryGetValue(index, out value)) {
				return value;
			} else {
				return defaultValue;
			}
		}

		protected override void SetControlValue(ComboBox entryControl, EnumType newValue) {
			foreach (KeyValuePair<int, EnumType> pair in listValues) {
				if (pair.Value.Equals(newValue)) {
					entryControl.SelectedIndex = pair.Key;
					return;
				}
			}

			entryControl.Text = newValue.ToString();
		}

		protected override void checkValueLimits(ComboBox entryControl, EnumNode<EnumType> node) {
			//No value limits for enums.
		}
	}
}
