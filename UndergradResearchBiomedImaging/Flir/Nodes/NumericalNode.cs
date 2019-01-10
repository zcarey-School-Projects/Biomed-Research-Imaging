using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir.Nodes {
	public abstract class NumericalNode<NodeType, ValueType> : BaseNode<NodeType, ValueType> where NodeType : INode where ValueType : struct{

		public ValueType? Minimum {
			get {
				NodeType node = default(NodeType);
				if (GetNode(ref node)) return getMinimum(node);
				else return null;
			}
		}

		protected abstract ValueType getMinimum(NodeType node);

		public ValueType? Maximum {
			get {
				NodeType node = default(NodeType);
				if (GetNode(ref node)) return getMaximum(node);
				else return null;
			}
		}

		protected abstract ValueType getMaximum(NodeType node);

		public NumericalNode(IManagedCamera cam, string nodeName) : base(cam, nodeName) {

		}

	}
}
