namespace UndergradResearchBiomedImaging {
	partial class CameraOptionsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.SettingsPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsPanel.AutoScroll = true;
			this.SettingsPanel.Location = new System.Drawing.Point(12, 12);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.Size = new System.Drawing.Size(412, 495);
			this.SettingsPanel.TabIndex = 10;
			// 
			// CameraOptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 519);
			this.Controls.Add(this.SettingsPanel);
			this.Name = "CameraOptionsForm";
			this.Text = "Camera Options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraOptionsForm_FormClosing);
			this.Load += new System.EventHandler(this.CameraOptionsForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel SettingsPanel;
	}
}