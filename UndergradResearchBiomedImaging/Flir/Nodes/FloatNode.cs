using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir.Nodes {
	public class FloatNode : NumericalNode<IFloat, double>{

		public string Unit {
			get {
				IFloat node = default(IFloat);
				if (base.GetNode(ref node)) return node.Unit;
				else return null;
			}
		}

		protected override double getMinimum(IFloat node) {
			return node.Min;
		}

		protected override double getMaximum(IFloat node) {
			return node.Max;
		}

		public FloatNode(IManagedCamera cam, string nodeName) : base(cam, nodeName) {
			
		}

		protected override double parseNodeValue(IFloat node) {
			return node.Value;
		}

		protected override void setNodeValue(IFloat node, double value) {
			node.Value = Math.Max(node.Min, Math.Min(node.Max, value));
		}

	}
}
