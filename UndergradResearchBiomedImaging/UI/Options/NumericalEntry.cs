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
	public abstract class NumericalEntry<TNode, NodeType, ValueType> : OptionEntry<NumericUpDown, TNode, NodeType, ValueType> where TNode : NumericalNode<NodeType, ValueType> where NodeType : INode where ValueType : struct {

		public NumericalEntry(string name, Property<FlirProperties, TNode> property, FlirCameraInput input) : base(name, property, input) {

		}

		protected override NumericUpDown generateControl(int xPos) {
			NumericUpDown control = new NumericUpDown();
			control.DecimalPlaces = getNumberOfDecimals();
			control.Increment = getIncrement();
			control.Location = new Point(xPos, 3);

			return control;
		}

		protected abstract int getNumberOfDecimals();

		protected abstract decimal getIncrement();

	}
}
