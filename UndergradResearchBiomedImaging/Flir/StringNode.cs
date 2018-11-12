using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir {
	public class StringNode {

		private IManagedCamera camera;
		private string nodeName;

		public StringNode(IManagedCamera cam, string nodeName) {
			this.camera = cam;
			this.nodeName = nodeName;
		}

		public bool TrySetValue(string value) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				IString node = map.GetNode<IString>(nodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + nodeName + "'.");
				if (!node.IsWritable) throw new SpinnakerException("The node '" + nodeName + "' is not writable. ");

				node.Value = value;
				return true;
			} catch (SpinnakerException e) {
				Console.WriteLine("\nCould not set node '{0}' to value '{1}'.", nodeName, value);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

		public bool TryGetValue(ref string value) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				IString node = map.GetNode<IString>(nodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + nodeName + "'.");
				if (!node.IsReadable) throw new SpinnakerException("The node '" + nodeName + "' is not readable. ");

				value = node.Value;
				if (value == null) throw new SpinnakerException("The value for node '" + nodeName + "' was null.");

				return true;
			} catch(SpinnakerException e) {
				Console.WriteLine("\nCould not set node '{0}' to value '{1}'.", nodeName, value);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

	}
}
