using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearchBiomedImaging.FlirEnums;

namespace UndergradResearchBiomedImaging {
	public class FlirCamera {

		private IManagedCamera camera;
		private INodeMap nodeMap;

		public FlirCamera(IManagedCamera cam) {
			this.camera = cam;
			nodeMap = camera.GetNodeMap(); ;
		}

		public bool SetAcquisitionMode(AcquisitionModeEnums mode) {
			return trySetNode("AcquisitionMode", mode.ToString());
		}

		private bool trySetNode(string nodeName, string nodeValue) {
			IEnum node = nodeMap.GetNode<IEnum>(nodeName);
			if (node == null || !node.IsWritable) return false;

			IEnumEntry nodeEntry = node.GetEntryByName(nodeValue);
			if (nodeEntry == null || !nodeEntry.IsReadable) return false;

			node.Value = nodeEntry.Value;
			return true;
		}

	}
}
