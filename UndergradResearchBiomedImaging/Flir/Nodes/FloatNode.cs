using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir.Nodes {
	public class FloatNode : BaseNode<IFloat, double>{

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
