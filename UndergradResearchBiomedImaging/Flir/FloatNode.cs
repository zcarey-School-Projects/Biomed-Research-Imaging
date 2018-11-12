using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir {
	public class FloatNode {

		private IManagedCamera camera;
		private string nodeName;

		public FloatNode(IManagedCamera cam, string nodeName) {
			this.camera = cam;
			this.nodeName = nodeName;
		}

		public bool TrySetValue(double value) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				IFloat node = map.GetNode<IFloat>(nodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + nodeName + "'.");
				if (!node.IsWritable) throw new SpinnakerException("The node '" + nodeName + "' is not writable. ");

				node.Value = Math.Max(node.Min, Math.Min(node.Max, value));
				return true;
			}catch(SpinnakerException e) {
				Console.WriteLine("\nCould not set node '{0}' to value '{1}'.", nodeName, value);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

	}
}
