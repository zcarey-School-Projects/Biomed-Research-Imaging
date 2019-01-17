using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;

namespace UndergradResearchBiomedImaging.UI.MenuStrip {
	public abstract class EnumMenuStrip<TEnum> where TEnum : struct {

		private FlirCameraStream stream;
		private ToolStripMenuItem baseMenu;
		private ToolStripMenuItem checkedItem = null;
		public ToolStripMenuItem CheckedItem {
			get => checkedItem;
			set {
				if (checkedItem != null) checkedItem.Checked = false;
				checkedItem = checkItems ? value : null;
				if (checkedItem != null) checkedItem.Checked = true;
			}
		}
		private bool checkItems;

		public EnumMenuStrip(ToolStripMenuItem BaseMenu, FlirCameraStream stream, TEnum? IgnoreCase, bool checkItems = true) {
			this.baseMenu = BaseMenu;
			this.stream = stream;
			this.checkItems = checkItems;

			foreach(TEnum enumValue in GetValues()) {
				if (enumValue.Equals(IgnoreCase)) continue;
				BaseMenu.DropDownItems.Add(new MenuEntry<TEnum>(this, enumValue));
			}

			if(BaseMenu.DropDownItems.Count == 0) {
				ToolStripItem noneEntry = new ToolStripMenuItem("(none)");
				noneEntry.Enabled = false;
				BaseMenu.DropDownItems.Add(noneEntry);
			}
		}

		private bool SetValue(TEnum value) {
			if (stream == null) return false;
			FlirCamera camera = stream.SourceCamera;
			if (camera == null) return false;
			return setProperty(camera, value);
		}

		protected abstract bool setProperty(FlirCamera camera, TEnum value);

		/// <summary> Returns all possible enum values. </summary>
		private static IEnumerable<TEnum> GetValues() {
			return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
		}

		private class MenuEntry<T> : ToolStripMenuItem where T:struct{

			private EnumMenuStrip<T> parent;
			private T value;

			public MenuEntry(EnumMenuStrip<T> parent, T value) {
				this.parent = parent;
				this.value = value;
				this.Text = value.ToString();

				this.DropDownItemClicked += OnClick;
			}

			private void OnClick(object sender, EventArgs e) {
				if (parent.SetValue(value)) { //TODO set value
					parent.CheckedItem = this;
				} else {
					parent.CheckedItem = null;
				}
			}

		}

	}
}
