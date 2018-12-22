using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir.Nodes {
	public abstract class BaseNode<NodeType, ValueType> where NodeType : INode{

		private IManagedCamera camera;
		public string NodeName { get; private set; }

		public BaseNode(IManagedCamera camera, string nodeName) {
			this.camera = camera;
			this.NodeName = nodeName;
		}

		protected abstract void setNodeValue(NodeType node, ValueType value);

		public bool TrySetValue(ValueType value) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				NodeType node = map.GetNode<NodeType>(NodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + NodeName + "'.");
				if (!node.IsWritable) throw new SpinnakerException("The node '" + NodeName + "' is not writable. ");

				setNodeValue(node, value);
				return true;
			} catch(SpinnakerException ex) {
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
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				NodeType node = map.GetNode<NodeType>(NodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + NodeName + "'.");
				if (!node.IsReadable) throw new SpinnakerException("The node '" + NodeName + "' is not readable. ");

				value = parseNodeValue(node);
				if (value == null) throw new SpinnakerException("Unable to retrieve the value from node '" + NodeName + "'.");
				return true;
			} catch (SpinnakerException e) {
				Console.WriteLine("\nCould not retrieve value from node '{1}'.", NodeName);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

	}
}
