using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearch.UI.Options {
	public class ConstantValueEntry : IOptionEntry {

		private const int controlXPos = 114;
		public override int Height { get; protected set; } = 28;

		private Label entryLabel;
		private Label valueLabel;

		public ConstantValueEntry(string name, string value) {
			if (value == null) value = "";
			entryLabel = new Label();
			entryLabel.Text = name + ": ";
			entryLabel.Location = new Point(3, 5);

			valueLabel = new Label();
			valueLabel.Width = 100;
			valueLabel.Text = value;
			valueLabel.Location = new Point(controlXPos, 5);
		}

		public override void DrawControls(int yPos) {
			lock (this) {
				entryLabel.Location = new Point(entryLabel.Location.X, yPos + 5);
				valueLabel.Location = new Point(valueLabel.Location.X, yPos + 5);
			}
		}

		public override void Update() {
			
		}

		protected override void OnPanelChanged(OptionsPanel newPanel) {
			lock (this) {
				entryLabel.Parent = newPanel.getPanel();
				valueLabel.Parent = newPanel.getPanel();
			}
		}

	}
}
