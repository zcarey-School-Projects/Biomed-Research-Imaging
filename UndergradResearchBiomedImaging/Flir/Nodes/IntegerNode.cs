using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir.Nodes {
	public class IntegerNode : NumericalNode<IInteger, long> {

		public long? Increment {
			get {
				IInteger node = default(IInteger);
				if (base.GetNode(ref node)) return node.Increment;
				else return null;
			}
		}

		protected override long getMinimum(IInteger node) {
			return node.Min;
		}

		protected override long getMaximum(IInteger node) {
			return node.Max;
		}

		public IntegerNode(IManagedCamera cam, string nodeName) : base(cam, nodeName) {

		}

		protected override long parseNodeValue(IInteger node) {
			return node.Value;
		}

		protected override void setNodeValue(IInteger node, long value) {
			node.Value = Math.Max(node.Min, Math.Min(node.Max, value));
		}
	}
}
