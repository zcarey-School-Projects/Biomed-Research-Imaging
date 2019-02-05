using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.Flir.Nodes {
	public class EnumNode<TEnum> : BaseNode<IEnum, TEnum> where TEnum : struct {

		public EnumNode(IManagedCamera cam, string nodeName) : base(cam, nodeName) {

		}

		protected override TEnum parseNodeValue(IEnum node) {
			TEnum value;
			if (!Enum.TryParse(node.Value, out value)) {
				throw new SpinnakerException("Unable to parse enum '" + NodeName + "' from node value: '" + node.Value + "'");
			}

			return value;
		}

		protected override void setNodeValue(IEnum node, TEnum value) {
			IEnumEntry entry = node.GetEntryByName(value.ToString());
			if (entry == null) throw new SpinnakerException("Could not find entry '" + value.ToString() + "' for the node '" + value + "'.");
			if (!entry.IsReadable) throw new SpinnakerException("The entry '" + value.ToString() + "' for the node '" + value + "' is not readable.");

			node.Value = entry.Value;
		}
	}
}
