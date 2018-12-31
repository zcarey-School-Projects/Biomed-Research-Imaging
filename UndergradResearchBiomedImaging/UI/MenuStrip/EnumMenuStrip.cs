using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.UI.MenuStrip {
	public abstract class EnumMenuStrip<TEnum> : ToolStripMenuItem where TEnum : struct{

		private ImageStream input;

		public EnumMenuStrip(ImageStream input, TEnum? IgnoreCase, bool checkItems = true) {
			this.input = input;
			this.Name = "EnumMenuStrip-" + getEnumName();
			this.Text = getDisplayText();

			foreach(TEnum enumValue in GetValues()) {
				if (!enumValue.Equals(IgnoreCase)) {
					ToolStripMenuItem entry = new ToolStripMenuItem(enumValue.ToString());

					entry.Click += (object sender, EventArgs e) => {
						if(input != null) {
							FlirCamera camera = input.camera;
							if(camera != null) {
								setProperty(camera, enumValue);
							}
						}
					};
					
					entry.CheckOnClick = checkItems;
					if (checkItems) {

						entry.CheckedChanged += (object sender, EventArgs e) => {
							if (entry.Checked == false) return;
							foreach(ToolStripMenuItem item in this.DropDownItems) {
								if(item != entry) {
									item.Checked = false;
								}
							}
						};

					}
					this.DropDownItems.Add(entry);
				}
			}

			if (this.DropDownItems.Count == 0) {
				ToolStripItem noneEntry = new ToolStripMenuItem("(none)");
				noneEntry.Enabled = false;
				this.DropDownItems.Add(noneEntry);
			}
		}

		protected abstract string getEnumName();

		protected abstract string getDisplayText();

		protected abstract void setProperty(FlirCamera camera, TEnum newValue);

		/// <summary>Returns all possible enum values.</summary>
		/// <returns>Enumerable for all possible enum values.</returns>
		private static IEnumerable<TEnum> GetValues() {
			return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
		}
	}
}
