using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir {
	public class IntegerNode {

		private IManagedCamera camera;
		private string nodeName;

		public IntegerNode(IManagedCamera cam, string nodeName) {
			this.camera = cam;
			this.nodeName = nodeName;
		}

		public bool TrySetValue(long value) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				IInteger node = map.GetNode<IInteger>(nodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + nodeName + "'.");
				if (!node.IsWritable) throw new SpinnakerException("The node '" + nodeName + "' is not writable. ");

				node.Value = Math.Max(node.Min, Math.Min(node.Max, value));
				return true;
			} catch (SpinnakerException e) {
				Console.WriteLine("\nCould not set node '{0}' to value '{1}'.", nodeName, value);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

		public bool TryGetValue(ref long value) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				IInteger node = map.GetNode<IInteger>(nodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + nodeName + "'.");
				if (!node.IsReadable) throw new SpinnakerException("The node '" + nodeName + "' is not readable. ");

				value = node.Value;
				//if (value == null) throw new SpinnakerException("Unable to retrieve the value from node '" + nodeName + "'.");
				return true;
			} catch (SpinnakerException e) {
				Console.WriteLine("\nCould not retrieve value from node '{1}'.", nodeName);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

	}
}
