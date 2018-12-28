using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.UI.Options {
	public abstract class OptionEntry<ControlType> : IOptionEntry where ControlType : Control {

		private const int ControlXPos = 114;

		private Label entryName;
		private ControlType entryControl;

		/*private OptionsPanel parent;
		public override OptionsPanel Parent {
			get => parent; set {
				parent = value;
				entryName.Parent = (value == null) ? null : value.getPanel();
				entryControl.Parent = (value == null) ? null : value.getPanel();
			}
		}*/

		public override int Height { get; protected set; } = 28;

		public OptionEntry(string name) {
			entryName = new Label();
			entryName.Text = name + ": ";
			entryName.Location = new Point(3, 5);
		}

		protected abstract ControlType generateControl(int xPos);

		public override void DrawControls(int yPos) {
			if (entryControl == null) entryControl = generateControl(ControlXPos);
			entryName.Location = new Point(entryName.Location.X, yPos + 5);
			entryControl.Location = new Point(entryControl.Location.X, yPos + 3);
		}

		protected override void OnPanelChanged(OptionsPanel newPanel) {
			if (entryControl == null) entryControl = generateControl(ControlXPos);
			entryName.Parent = newPanel.getPanel();
			entryControl.Parent = newPanel.getPanel();
			entryControl.BringToFront();
		}

		public bool Enabled { get => entryControl.Enabled; set => entryControl.Enabled = value; }

		public void ClearTest() {
			entryControl.ResetText();
		}

	}
}
