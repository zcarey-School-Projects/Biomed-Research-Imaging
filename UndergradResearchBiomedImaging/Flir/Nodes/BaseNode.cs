using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.Flir.Nodes {
	public abstract class BaseNode<NodeType, ValueType> where NodeType : INode {

		private IManagedCamera camera;
		public string NodeName { get; private set; }

		public BaseNode(IManagedCamera camera, string nodeName) {
			this.camera = camera;
			this.NodeName = nodeName;
		}

		protected abstract void setNodeValue(NodeType node, ValueType value);

		public bool TrySetValue(ValueType value) {
			try {
				NodeType node = default(NodeType);
				if (!GetNode(ref node)) throw new SpinnakerException("Unable to find node '" + NodeName + "'.");
				if (!node.IsWritable) throw new SpinnakerException("The node '" + NodeName + "' is not writable. ");

				setNodeValue(node, value);
				return true;
			} catch (SpinnakerException ex) {
				Console.WriteLine("\nCould not set node '{0}' to value '{1}'.", NodeName, value);
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

		protected abstract ValueType parseNodeValue(NodeType node);

		public bool TryGetValue(ref ValueType value) {
			try {
				NodeType node = default(NodeType);
				if (!GetNode(ref node)) throw new SpinnakerException("Unable to find node '" + NodeName + "'.");
				if (!node.IsReadable) throw new SpinnakerException("The node '" + NodeName + "' is not writable. ");

				value = parseNodeValue(node);
				if (value == null) throw new SpinnakerException("Unable to retrieve the value from node '" + NodeName + "'.");
				return true;
			} catch (SpinnakerException e) {
				Console.WriteLine("\nCould not retrieve value from node '{0}'.", NodeName);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

		/// <summary>Throws Spinnaker Exception</summary>
		/// <returns>The property node.</returns>
		protected bool GetNode(ref NodeType newNode) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				newNode = map.GetNode<NodeType>(NodeName);
				if (newNode == null) return false;
				return true;
			} catch (SpinnakerException ex) {
				Console.Error.WriteLine("Unable to retrieve node: " + ex.Message);
				return false;
			}
		}

		public bool IsAvailable() {
			NodeType node = default(NodeType);
			return GetNode(ref node);
		}

		public bool IsReadable() {
			NodeType node = default(NodeType);
			if (GetNode(ref node)) {
				return ((NodeType)node).IsReadable;
			} else {
				return false;
			}
		}

		public bool IsWritable() {
			NodeType node = default(NodeType);
			if (GetNode(ref node)) {
				return ((NodeType)node).IsWritable;
			} else {
				return false;
			}
		}

	}
}
