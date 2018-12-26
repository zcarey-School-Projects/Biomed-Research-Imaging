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
			this.ConnectBtn = new System.Windows.Forms.Button();
			this.CameraFeed = new System.Windows.Forms.PictureBox();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ScreenshotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoFilledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StagePosition = new System.Windows.Forms.TextBox();
			this.MoveStageBtn = new System.Windows.Forms.Button();
			this.SettingsPanel = new System.Windows.Forms.Panel();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).BeginInit();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FPSStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 443);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(1074, 25);
			this.StatusStrip.TabIndex = 1;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// FPSStatusLabel
			// 
			this.FPSStatusLabel.Name = "FPSStatusLabel";
			this.FPSStatusLabel.Size = new System.Drawing.Size(60, 20);
			this.FPSStatusLabel.Text = "30.0 fps";
			// 
			// ConnectBtn
			// 
			this.ConnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ConnectBtn.Location = new System.Drawing.Point(15, 401);
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
			this.CameraFeed.BackColor = System.Drawing.SystemColors.Control;
			this.CameraFeed.Location = new System.Drawing.Point(12, 31);
			this.CameraFeed.Name = "CameraFeed";
			this.CameraFeed.Size = new System.Drawing.Size(696, 358);
			this.CameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CameraFeed.TabIndex = 3;
			this.CameraFeed.TabStop = false;
			this.CameraFeed.Resize += new System.EventHandler(this.CameraFeed_Resize);
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
			// MenuStrip
			// 
			this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.testToolStripMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(1074, 28);
			this.MenuStrip.TabIndex = 2;
			this.MenuStrip.Text = "menuStrip1";
			// 
			// controlToolStripMenuItem
			// 
			this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
			this.controlToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
			this.controlToolStripMenuItem.Text = "Control";
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testImageToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
			this.testToolStripMenuItem.Text = "Test";
			// 
			// testImageToolStripMenuItem
			// 
			this.testImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoFilledToolStripMenuItem});
			this.testImageToolStripMenuItem.Name = "testImageToolStripMenuItem";
			this.testImageToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
			this.testImageToolStripMenuItem.Text = "Test Image";
			// 
			// autoFilledToolStripMenuItem
			// 
			this.autoFilledToolStripMenuItem.Enabled = false;
			this.autoFilledToolStripMenuItem.Name = "autoFilledToolStripMenuItem";
			this.autoFilledToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
			this.autoFilledToolStripMenuItem.Text = "AutoFilled";
			// 
			// StagePosition
			// 
			this.StagePosition.Location = new System.Drawing.Point(315, 402);
			this.StagePosition.Name = "StagePosition";
			this.StagePosition.Size = new System.Drawing.Size(100, 22);
			this.StagePosition.TabIndex = 5;
			// 
			// MoveStageBtn
			// 
			this.MoveStageBtn.Location = new System.Drawing.Point(421, 402);
			this.MoveStageBtn.Name = "MoveStageBtn";
			this.MoveStageBtn.Size = new System.Drawing.Size(75, 23);
			this.MoveStageBtn.TabIndex = 6;
			this.MoveStageBtn.Text = "Move";
			this.MoveStageBtn.UseVisualStyleBackColor = true;
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsPanel.AutoScroll = true;
			this.SettingsPanel.Location = new System.Drawing.Point(714, 31);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.Size = new System.Drawing.Size(348, 358);
			this.SettingsPanel.TabIndex = 7;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.numericUpDown1.Location = new System.Drawing.Point(557, 418);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
			this.numericUpDown1.TabIndex = 8;
			this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// ControlForm
			// 
			this.AcceptButton = this.MoveStageBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1074, 468);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.SettingsPanel);
			this.Controls.Add(this.MoveStageBtn);
			this.Controls.Add(this.StagePosition);
			this.Controls.Add(this.CameraFeed);
			this.Controls.Add(this.ConnectBtn);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "ControlForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.ControlForm_Load);
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).EndInit();
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel FPSStatusLabel;
		private System.Windows.Forms.Button ConnectBtn;
		private System.Windows.Forms.PictureBox CameraFeed;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ScreenshotMenuItem;
		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoFilledToolStripMenuItem;
		private System.Windows.Forms.TextBox StagePosition;
		private System.Windows.Forms.Button MoveStageBtn;
		private System.Windows.Forms.Panel SettingsPanel;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
	}
}

