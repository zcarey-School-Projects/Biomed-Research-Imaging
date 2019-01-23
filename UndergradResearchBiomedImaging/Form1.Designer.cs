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
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.FPSStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ScreenshotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TestPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ConnectBtn = new System.Windows.Forms.Button();
			this.CameraFeed = new System.Windows.Forms.PictureBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SettingsPanel = new System.Windows.Forms.Panel();
			this.Record = new System.Windows.Forms.Button();
			this.RecordingBorderPanel = new System.Windows.Forms.Panel();
			this.StatusStrip.SuspendLayout();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.RecordingBorderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FPSStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 425);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(839, 25);
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
			this.MenuStrip.Size = new System.Drawing.Size(839, 28);
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
			this.CameraFeed.Location = new System.Drawing.Point(3, 3);
			this.CameraFeed.Name = "CameraFeed";
			this.CameraFeed.Size = new System.Drawing.Size(528, 324);
			this.CameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CameraFeed.TabIndex = 3;
			this.CameraFeed.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(12, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.CameraFeed);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.SettingsPanel);
			this.splitContainer1.Size = new System.Drawing.Size(815, 330);
			this.splitContainer1.SplitterDistance = 529;
			this.splitContainer1.TabIndex = 8;
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsPanel.AutoScroll = true;
			this.SettingsPanel.Location = new System.Drawing.Point(4, 3);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.Size = new System.Drawing.Size(275, 324);
			this.SettingsPanel.TabIndex = 9;
			// 
			// Record
			// 
			this.Record.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Record.Location = new System.Drawing.Point(744, 383);
			this.Record.Name = "Record";
			this.Record.Size = new System.Drawing.Size(83, 23);
			this.Record.TabIndex = 9;
			this.Record.Text = "Record";
			this.Record.UseVisualStyleBackColor = true;
			this.Record.Click += new System.EventHandler(this.Record_Click);
			// 
			// RecordingBorderPanel
			// 
			this.RecordingBorderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RecordingBorderPanel.BackColor = System.Drawing.SystemColors.Control;
			this.RecordingBorderPanel.Controls.Add(this.splitContainer1);
			this.RecordingBorderPanel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RecordingBorderPanel.Location = new System.Drawing.Point(0, 31);
			this.RecordingBorderPanel.Name = "RecordingBorderPanel";
			this.RecordingBorderPanel.Size = new System.Drawing.Size(839, 346);
			this.RecordingBorderPanel.TabIndex = 10;
			// 
			// ControlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(839, 450);
			this.Controls.Add(this.Record);
			this.Controls.Add(this.ConnectBtn);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MenuStrip);
			this.Controls.Add(this.RecordingBorderPanel);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "ControlForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.ControlForm_Load);
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.RecordingBorderPanel.ResumeLayout(false);
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
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel SettingsPanel;
		private System.Windows.Forms.ToolStripMenuItem TestMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TestPatternMenuItem;
		private System.Windows.Forms.Button Record;
		private System.Windows.Forms.Panel RecordingBorderPanel;
	}
}

