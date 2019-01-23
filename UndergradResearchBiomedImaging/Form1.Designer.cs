namespace UndergradResearchBiomedImaging {
	partial class ControlForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.FPSStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ScreenshotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TestPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ConnectBtn = new System.Windows.Forms.Button();
			this.CameraFeed = new System.Windows.Forms.PictureBox();
			this.SettingsPanel = new System.Windows.Forms.Panel();
			this.Record = new System.Windows.Forms.Button();
			this.RecordingBorder = new System.Windows.Forms.Panel();
			this.ConstantBackground = new System.Windows.Forms.Panel();
			this.StatusStrip.SuspendLayout();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).BeginInit();
			this.RecordingBorder.SuspendLayout();
			this.ConstantBackground.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FPSStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 425);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(931, 25);
			this.StatusStrip.TabIndex = 1;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// FPSStatusLabel
			// 
			this.FPSStatusLabel.Name = "FPSStatusLabel";
			this.FPSStatusLabel.Size = new System.Drawing.Size(60, 20);
			this.FPSStatusLabel.Text = "30.0 fps";
			// 
			// MenuStrip
			// 
			this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.TestMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(931, 28);
			this.MenuStrip.TabIndex = 2;
			this.MenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScreenshotMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// ScreenshotMenuItem
			// 
			this.ScreenshotMenuItem.Name = "ScreenshotMenuItem";
			this.ScreenshotMenuItem.ShortcutKeyDisplayString = "";
			this.ScreenshotMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.ScreenshotMenuItem.Size = new System.Drawing.Size(206, 26);
			this.ScreenshotMenuItem.Text = "Screenshot";
			this.ScreenshotMenuItem.Click += new System.EventHandler(this.ScreenshotMenuItem_Click);
			// 
			// TestMenuItem
			// 
			this.TestMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestPatternMenuItem});
			this.TestMenuItem.Name = "TestMenuItem";
			this.TestMenuItem.Size = new System.Drawing.Size(47, 24);
			this.TestMenuItem.Text = "Test";
			// 
			// TestPatternMenuItem
			// 
			this.TestPatternMenuItem.Name = "TestPatternMenuItem";
			this.TestPatternMenuItem.Size = new System.Drawing.Size(160, 26);
			this.TestPatternMenuItem.Text = "Test Pattern";
			// 
			// ConnectBtn
			// 
			this.ConnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ConnectBtn.Location = new System.Drawing.Point(12, 383);
			this.ConnectBtn.Name = "ConnectBtn";
			this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
			this.ConnectBtn.TabIndex = 4;
			this.ConnectBtn.Text = "Connect";
			this.ConnectBtn.UseVisualStyleBackColor = true;
			this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
			// 
			// CameraFeed
			// 
			this.CameraFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CameraFeed.BackColor = System.Drawing.Color.Black;
			this.CameraFeed.Image = ((System.Drawing.Image)(resources.GetObject("CameraFeed.Image")));
			this.CameraFeed.Location = new System.Drawing.Point(3, 3);
			this.CameraFeed.Name = "CameraFeed";
			this.CameraFeed.Size = new System.Drawing.Size(536, 330);
			this.CameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CameraFeed.TabIndex = 3;
			this.CameraFeed.TabStop = false;
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsPanel.AutoScroll = true;
			this.SettingsPanel.Location = new System.Drawing.Point(545, 3);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.Size = new System.Drawing.Size(349, 330);
			this.SettingsPanel.TabIndex = 9;
			// 
			// Record
			// 
			this.Record.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Record.Location = new System.Drawing.Point(836, 383);
			this.Record.Name = "Record";
			this.Record.Size = new System.Drawing.Size(83, 23);
			this.Record.TabIndex = 9;
			this.Record.Text = "Record";
			this.Record.UseVisualStyleBackColor = true;
			this.Record.Click += new System.EventHandler(this.Record_Click);
			// 
			// RecordingBorder
			// 
			this.RecordingBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RecordingBorder.BackColor = System.Drawing.Color.Red;
			this.RecordingBorder.Controls.Add(this.ConstantBackground);
			this.RecordingBorder.Location = new System.Drawing.Point(12, 31);
			this.RecordingBorder.Name = "RecordingBorder";
			this.RecordingBorder.Size = new System.Drawing.Size(907, 346);
			this.RecordingBorder.TabIndex = 11;
			// 
			// ConstantBackground
			// 
			this.ConstantBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConstantBackground.BackColor = System.Drawing.SystemColors.Control;
			this.ConstantBackground.Controls.Add(this.CameraFeed);
			this.ConstantBackground.Controls.Add(this.SettingsPanel);
			this.ConstantBackground.Location = new System.Drawing.Point(5, 5);
			this.ConstantBackground.Name = "ConstantBackground";
			this.ConstantBackground.Size = new System.Drawing.Size(897, 336);
			this.ConstantBackground.TabIndex = 0;
			// 
			// ControlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(931, 450);
			this.Controls.Add(this.RecordingBorder);
			this.Controls.Add(this.Record);
			this.Controls.Add(this.ConnectBtn);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "ControlForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.ControlForm_Load);
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).EndInit();
			this.RecordingBorder.ResumeLayout(false);
			this.ConstantBackground.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel FPSStatusLabel;
		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ScreenshotMenuItem;
		private System.Windows.Forms.Button ConnectBtn;
		private System.Windows.Forms.PictureBox CameraFeed;
		private System.Windows.Forms.Panel SettingsPanel;
		private System.Windows.Forms.ToolStripMenuItem TestMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TestPatternMenuItem;
		private System.Windows.Forms.Button Record;
		private System.Windows.Forms.Panel RecordingBorder;
		private System.Windows.Forms.Panel ConstantBackground;
	}
}

