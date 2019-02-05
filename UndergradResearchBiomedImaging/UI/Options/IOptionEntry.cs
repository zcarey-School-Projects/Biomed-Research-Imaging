using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.UI.Options {
	public abstract class IOptionEntry {

		private List<IOptionEntry> children = new List<IOptionEntry>();

		private OptionsPanel panel;
		private OptionsPanel Panel {
			get => panel;
			set {
				panel = value;
				OnPanelChanged(value);
				//TODO set controls parent
				foreach (IOptionEntry child in children) {
					child.Panel = value;
				}
			}
		}

		protected abstract void OnPanelChanged(OptionsPanel newPanel);

		private IOptionEntry parent;
		public IOptionEntry Parent {
			get => parent;
			set {
				parent = value;
				value.children.Add(this);
				//OnParentChanged(value);
				if (value is OptionsPanel) {
					Panel = (OptionsPanel)value;
				} else if (value.Panel != null) {
					Panel = value.Panel;
				}
			}
		}

		//protected abstract void OnParentChanged(IOptionEntry newParent);

		public abstract void DrawControls(int yPos);

		public abstract void Update();

		public abstract int Height { get; protected set; }

		public int Y { get; set; }

		public IOptionEntry() {

		}

		public IEnumerable<IOptionEntry> GetChildren() {
			return children.AsEnumerable();
		}

	}
}
