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
			this.autofillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testPatternStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autofillToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.DeviceName = new System.Windows.Forms.Label();
			this.VendorName = new System.Windows.Forms.Label();
			this.DeviceTempSource = new System.Windows.Forms.Label();
			this.DeviceTemp = new System.Windows.Forms.Label();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).BeginInit();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FPSStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 443);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(851, 25);
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
			this.CameraFeed.Location = new System.Drawing.Point(3, 3);
			this.CameraFeed.Name = "CameraFeed";
			this.CameraFeed.Size = new System.Drawing.Size(636, 358);
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
			this.MenuStrip.Size = new System.Drawing.Size(851, 28);
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
            this.testImageToolStripMenuItem,
            this.testPatternStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
			this.testToolStripMenuItem.Text = "Test";
			// 
			// testImageToolStripMenuItem
			// 
			this.testImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autofillToolStripMenuItem});
			this.testImageToolStripMenuItem.Name = "testImageToolStripMenuItem";
			this.testImageToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
			this.testImageToolStripMenuItem.Text = "Test Image";
			// 
			// autofillToolStripMenuItem
			// 
			this.autofillToolStripMenuItem.Name = "autofillToolStripMenuItem";
			this.autofillToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
			this.autofillToolStripMenuItem.Text = "Autofill";
			// 
			// testPatternStripMenuItem
			// 
			this.testPatternStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autofillToolStripMenuItem1});
			this.testPatternStripMenuItem.Name = "testPatternStripMenuItem";
			this.testPatternStripMenuItem.Size = new System.Drawing.Size(230, 26);
			this.testPatternStripMenuItem.Text = "Test Pattern Generator";
			// 
			// autofillToolStripMenuItem1
			// 
			this.autofillToolStripMenuItem1.Name = "autofillToolStripMenuItem1";
			this.autofillToolStripMenuItem1.Size = new System.Drawing.Size(143, 26);
			this.autofillToolStripMenuItem1.Text = "(Autofill)";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(12, 31);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.CameraFeed);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.DeviceTemp);
			this.splitContainer1.Panel2.Controls.Add(this.DeviceTempSource);
			this.splitContainer1.Panel2.Controls.Add(this.VendorName);
			this.splitContainer1.Panel2.Controls.Add(this.DeviceName);
			this.splitContainer1.Size = new System.Drawing.Size(827, 364);
			this.splitContainer1.SplitterDistance = 642;
			this.splitContainer1.TabIndex = 5;
			// 
			// DeviceName
			// 
			this.DeviceName.AutoSize = true;
			this.DeviceName.Location = new System.Drawing.Point(3, 3);
			this.DeviceName.Name = "DeviceName";
			this.DeviceName.Size = new System.Drawing.Size(96, 17);
			this.DeviceName.TabIndex = 0;
			this.DeviceName.Text = "Device Name:";
			// 
			// VendorName
			// 
			this.VendorName.AutoSize = true;
			this.VendorName.Location = new System.Drawing.Point(3, 20);
			this.VendorName.Name = "VendorName";
			this.VendorName.Size = new System.Drawing.Size(99, 17);
			this.VendorName.TabIndex = 1;
			this.VendorName.Text = "Vendor Name:";
			// 
			// DeviceTempSource
			// 
			this.DeviceTempSource.AutoSize = true;
			this.DeviceTempSource.Location = new System.Drawing.Point(3, 55);
			this.DeviceTempSource.Name = "DeviceTempSource";
			this.DeviceTempSource.Size = new System.Drawing.Size(97, 17);
			this.DeviceTempSource.TabIndex = 2;
			this.DeviceTempSource.Text = "Temp Source:";
			// 
			// DeviceTemp
			// 
			this.DeviceTemp.AutoSize = true;
			this.DeviceTemp.Location = new System.Drawing.Point(5, 72);
			this.DeviceTemp.Name = "DeviceTemp";
			this.DeviceTemp.Size = new System.Drawing.Size(94, 17);
			this.DeviceTemp.TabIndex = 3;
			this.DeviceTemp.Text = "Temperature:";
			// 
			// ControlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(851, 468);
			this.Controls.Add(this.splitContainer1);
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
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripMenuItem autofillToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testPatternStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autofillToolStripMenuItem1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label DeviceName;
		private System.Windows.Forms.Label VendorName;
		private System.Windows.Forms.Label DeviceTemp;
		private System.Windows.Forms.Label DeviceTempSource;
	}
}

