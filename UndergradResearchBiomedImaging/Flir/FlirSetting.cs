using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpinnakerNET;
using SpinnakerNET.GenApi;

namespace UndergradResearchBiomedImaging.Flir {
	public abstract class FlirSetting {

		public abstract string Description { get; protected set; }
		public abstract string Command { get; protected set; }
		public abstract string DisplayName { get; protected set; }

		private FlirCamera camera;

		public FlirSetting(FlirCamera camera) {
			this.camera = camera;
		}

		protected bool trySetNodeValue(string nodeValue) {
			try {
				INodeMap map = camera.GetNodeMap();
				if (map == null) throw new ArgumentNullException("Null Node Map.");
				IEnum node = map.GetNode<IEnum>(this.Command);
				if (node == null) throw new ArgumentNullException("Null Enum Node");
				node.Value = nodeValue;
				return true;
			} catch (SpinnakerException e) {
				Console.WriteLine("Could not set node '{0}' to value '{1}'.", this.DisplayName, nodeValue);
				return false;
			}catch (ArgumentNullException ex) {
				Console.WriteLine("Could not find a node.");
				return false;
			}
		}

	}
}
