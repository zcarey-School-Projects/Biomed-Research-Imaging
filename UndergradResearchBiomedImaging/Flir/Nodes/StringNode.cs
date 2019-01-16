using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir.Nodes {
	public class StringNode : BaseNode<IString, string> {

		public StringNode(IManagedCamera cam, string nodeName) : base(cam, nodeName) {

		}

		protected override string parseNodeValue(IString node) {
			return node.Value;
		}

		protected override void setNodeValue(IString node, string value) {
			node.Value = value;
		}
	}
}
