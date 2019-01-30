using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging {
	public partial class StageOptionsForm : Form {
		public StageOptionsForm() {
			InitializeComponent();
		}

		private void StageOptionsForm_Load(object sender, EventArgs e) {

		}

		private void StageOptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		private void StageOptionsForm_Shown(object sender, EventArgs e) {

		}
	}
}
