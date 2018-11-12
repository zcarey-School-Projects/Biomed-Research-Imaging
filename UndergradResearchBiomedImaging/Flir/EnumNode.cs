using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Flir {
	public class EnumNode<TEnum> where TEnum : struct {

		private IManagedCamera camera;
		private string nodeName;

		public EnumNode(IManagedCamera cam, string nodeName) {
			this.camera = cam;
			this.nodeName = nodeName;
		}

		public bool TrySetValue(TEnum nodeValue) {
			try {
				if (camera == null) throw new SpinnakerException("Camera is null.");

				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new SpinnakerException("Could not retrieve node map.");

				IEnum node = map.GetNode<IEnum>(nodeName);
				if (node == null) throw new SpinnakerException("Unable to find node '" + nodeName + "'.");
				if (!node.IsWritable) throw new SpinnakerException("The node '" + nodeName + "' is not writable. ");

				IEnumEntry entry = node.GetEntryByName(nodeValue.ToString());
				if (entry == null) throw new SpinnakerException("Could not find entry '" + nodeValue.ToString() + "' for the node '" + nodeName + "'.");
				if (!entry.IsReadable) throw new SpinnakerException("The entry '" + nodeValue.ToString() + "' for the node '" + nodeName + "' is not readable.");

				node.Value = entry.Value;
				return true;
			} catch (SpinnakerException e) {
				Console.WriteLine("\nCould not set node '{0}' to value '{1}'.", nodeName, nodeValue.ToString());
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				return false;
			}
		}

	}
}
