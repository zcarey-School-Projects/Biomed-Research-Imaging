using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.UI.Options {
	public class OptionsCategory : IOptionEntry {

		private Label categoryName;
		private Label titleBevel;
		private Label endBevel;

		/*
		private OptionsPanel parent;
		public OptionsPanel Parent { get => parent; set {
			parent = value;
			categoryName.Parent = value.getPanel();
			titleBevel.Parent = value.getPanel();
			endBevel.Parent = value.getPanel();
			foreach (OptionEntry<Control> entry in entries) {
				entry.Parent = value;
			}
			Update();
		} }
		*/
		public override int Height { get; protected set; } = 64;

		public OptionsCategory(string CategoryName) {
			categoryName = new Label();
			categoryName.Text = CategoryName;
			categoryName.Location = new Point(3, 5);

			titleBevel = new Label();
			titleBevel.AutoSize = false;
			titleBevel.Height = 2;
			titleBevel.BorderStyle = BorderStyle.Fixed3D;
			titleBevel.Location = new Point(3, 30); //28 + 2

			endBevel = new Label();
			endBevel.AutoSize = false;
			endBevel.Height = 2;
			endBevel.BorderStyle = BorderStyle.Fixed3D;
			endBevel.Location = new Point(3, 38); //36 + 2
		}

		public override void Update() {
			foreach (IOptionEntry entry in base.GetChildren()) {
				entry.Update();
			}
		}

		public override void DrawControls(int yPos) {
			categoryName.Location = new Point(categoryName.Location.X, yPos + 5);
			titleBevel.Location = new Point(titleBevel.Location.X, yPos + 30);
			yPos += 36;
			Height = 36;
			foreach (IOptionEntry child in base.GetChildren()) {
				child.DrawControls(yPos);
				yPos += child.Height;
				Height += child.Height;
			}
			endBevel.Location = new Point(endBevel.Location.X, yPos);
			Height += 28;
		}

		protected override void OnPanelChanged(OptionsPanel newPanel) {
			categoryName.Parent = newPanel.getPanel();
			titleBevel.Parent = newPanel.getPanel();
			titleBevel.Width = newPanel.getPanel().Width - 6;
			endBevel.Parent = newPanel.getPanel();
			endBevel.Width = newPanel.getPanel().Width - 6;
		}

	}
}
