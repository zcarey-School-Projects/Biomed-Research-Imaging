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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item 1",
            "Lol"}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Item 2");
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Item 3");
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Item 4");
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.FPSStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ScreenshotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ConnectBtn = new System.Windows.Forms.Button();
			this.CameraFeed = new System.Windows.Forms.PictureBox();
			this.CameraProperties = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SettingsPanel = new System.Windows.Forms.Panel();
			this.StatusStrip.SuspendLayout();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).BeginInit();
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
			this.StatusStrip.Location = new System.Drawing.Point(0, 584);
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
			// MenuStrip
			// 
			this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(851, 28);
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
			// ConnectBtn
			// 
			this.ConnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ConnectBtn.Location = new System.Drawing.Point(15, 542);
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
			this.CameraFeed.Size = new System.Drawing.Size(536, 325);
			this.CameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CameraFeed.TabIndex = 3;
			this.CameraFeed.TabStop = false;
			this.CameraFeed.Resize += new System.EventHandler(this.CameraFeed_Resize);
			// 
			// CameraProperties
			// 
			this.CameraProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CameraProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.CameraProperties.FullRowSelect = true;
			this.CameraProperties.GridLines = true;
			listViewItem1.StateImageIndex = 0;
			listViewItem2.StateImageIndex = 0;
			listViewItem3.StateImageIndex = 0;
			listViewItem4.StateImageIndex = 0;
			this.CameraProperties.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
			this.CameraProperties.Location = new System.Drawing.Point(3, 3);
			this.CameraProperties.Name = "CameraProperties";
			this.CameraProperties.Size = new System.Drawing.Size(280, 325);
			this.CameraProperties.TabIndex = 6;
			this.CameraProperties.UseCompatibleStateImageBehavior = false;
			this.CameraProperties.View = System.Windows.Forms.View.Details;
			this.CameraProperties.Resize += new System.EventHandler(this.CameraProperties_Resize);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Col1";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Col2";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
			this.splitContainer1.Panel2.Controls.Add(this.CameraProperties);
			this.splitContainer1.Size = new System.Drawing.Size(827, 331);
			this.splitContainer1.SplitterDistance = 537;
			this.splitContainer1.TabIndex = 8;
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.AutoScroll = true;
			this.SettingsPanel.Location = new System.Drawing.Point(552, 368);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.Size = new System.Drawing.Size(287, 197);
			this.SettingsPanel.TabIndex = 9;
			// 
			// ControlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(851, 609);
			this.Controls.Add(this.SettingsPanel);
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
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
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
		private System.Windows.Forms.ListView CameraProperties;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel SettingsPanel;
	}
}

