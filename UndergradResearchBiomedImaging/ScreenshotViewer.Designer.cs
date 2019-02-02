namespace UndergradResearchBiomedImaging {
	partial class ScreenshotViewer {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenshotViewer));
			this.PictureBox_Screenshot = new System.Windows.Forms.PictureBox();
			this.Btn_Save = new System.Windows.Forms.Button();
			this.Btn_Cancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox_Screenshot)).BeginInit();
			this.SuspendLayout();
			// 
			// PictureBox_Screenshot
			// 
			this.PictureBox_Screenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PictureBox_Screenshot.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Screenshot.Image")));
			this.PictureBox_Screenshot.Location = new System.Drawing.Point(12, 12);
			this.PictureBox_Screenshot.Name = "PictureBox_Screenshot";
			this.PictureBox_Screenshot.Size = new System.Drawing.Size(407, 323);
			this.PictureBox_Screenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox_Screenshot.TabIndex = 0;
			this.PictureBox_Screenshot.TabStop = false;
			// 
			// Btn_Save
			// 
			this.Btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Btn_Save.Location = new System.Drawing.Point(12, 341);
			this.Btn_Save.Name = "Btn_Save";
			this.Btn_Save.Size = new System.Drawing.Size(75, 23);
			this.Btn_Save.TabIndex = 1;
			this.Btn_Save.Text = "Save";
			this.Btn_Save.UseVisualStyleBackColor = true;
			this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
			// 
			// Btn_Cancel
			// 
			this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_Cancel.Location = new System.Drawing.Point(344, 341);
			this.Btn_Cancel.Name = "Btn_Cancel";
			this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Btn_Cancel.TabIndex = 2;
			this.Btn_Cancel.Text = "Cancel";
			this.Btn_Cancel.UseVisualStyleBackColor = true;
			this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
			// 
			// ScreenshotViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 379);
			this.Controls.Add(this.Btn_Cancel);
			this.Controls.Add(this.Btn_Save);
			this.Controls.Add(this.PictureBox_Screenshot);
			this.Name = "ScreenshotViewer";
			this.Text = "Screenshot Viewer";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox_Screenshot)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox PictureBox_Screenshot;
		private System.Windows.Forms.Button Btn_Save;
		private System.Windows.Forms.Button Btn_Cancel;
	}
}