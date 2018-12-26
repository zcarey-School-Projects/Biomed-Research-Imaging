using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.UI {
	public class OptionsPanel : IOptionEntry{

		private Panel optionsPanel;
		private bool dirty = true;

		public override int Height { get; protected set; }

		public OptionsPanel(Panel panel) {
			optionsPanel = panel;
			panel.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) => {
				if (dirty) DrawControls(0);
			};
		}

		protected override void OnPanelChanged(OptionsPanel newPanel) {
			//LOL!
		}

		public override void DrawControls(int yPos) {
			Height = 0;
			foreach (IOptionEntry entry in base.GetChildren()) {
				entry.DrawControls(yPos);
				yPos += entry.Height;
				Height += entry.Height;
			}
			dirty = false;
		}

		public void MarkDirty() {
			dirty = true;
		}

		public Panel getPanel() {
			return optionsPanel;
		}
		/*
		public void add(OptionsCategory category) {
			categories.Add(category);
			category.Parent = this;
			Update();
		}
		*//*
		public void Update() {
			dirty = true;
		}
		*/
	}
}
