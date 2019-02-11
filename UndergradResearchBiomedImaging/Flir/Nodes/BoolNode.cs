using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.Flir.Nodes {
	public class BoolNode : BaseNode<IBool, bool> {
		public BoolNode(IManagedCamera camera, string nodeName) : base(camera, nodeName) {
		}

		protected override bool parseNodeValue(IBool node) {
			return node.Value;
		}

		protected override void setNodeValue(IBool node, bool value) {
			node.Value = value;
		}
	}
}
