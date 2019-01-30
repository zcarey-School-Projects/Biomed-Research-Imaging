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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.FPSStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ScreenshotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Options = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_CameraOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_StageOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.TestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TestPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Btn_ConnectCamera = new System.Windows.Forms.Button();
			this.CameraFeed = new System.Windows.Forms.PictureBox();
			this.Btn_Record = new System.Windows.Forms.Button();
			this.RecordingBorder = new System.Windows.Forms.Panel();
			this.ConstantBackground = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.ScreenshotViewer = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Btn_TakeScreenshot = new System.Windows.Forms.Button();
			this.Btn_SaveScreenshot = new System.Windows.Forms.Button();
			this.Seperator = new System.Windows.Forms.Panel();
			this.StagePanel = new System.Windows.Forms.Panel();
			this.Label_CurrentPosition = new System.Windows.Forms.Label();
			this.Btn_JogNegative = new System.Windows.Forms.Button();
			this.Btn_WalkPositive = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.Btn_JogPositive = new System.Windows.Forms.Button();
			this.Btn_WalkNegative = new System.Windows.Forms.Button();
			this.Btn_Absolute = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.Numeric_Absolute = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.Btn_RelativePositive = new System.Windows.Forms.Button();
			this.Btn_RelativeNegative = new System.Windows.Forms.Button();
			this.Numeric_Relative = new System.Windows.Forms.NumericUpDown();
			this.Btn_ConnectStage = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.PositionTimer = new System.Windows.Forms.Timer(this.components);
			this.StatusStrip.SuspendLayout();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).BeginInit();
			this.RecordingBorder.SuspendLayout();
			this.ConstantBackground.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ScreenshotViewer)).BeginInit();
			this.StagePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Absolute)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Relative)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FPSStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 432);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(931, 25);
			this.StatusStrip.TabIndex = 1;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// FPSStatusLabel
			// 
			this.FPSStatusLabel.Name = "FPSStatusLabel";
			this.FPSStatusLabel.Size = new System.Drawing.Size(60, 20);
			this.FPSStatusLabel.Text = "00.0 fps";
			// 
			// MenuStrip
			// 
			this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.Menu_Options,
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
			this.ScreenshotMenuItem.Size = new System.Drawing.Size(216, 26);
			this.ScreenshotMenuItem.Text = "Screenshot";
			this.ScreenshotMenuItem.Click += new System.EventHandler(this.Control_TakeScreenshot);
			// 
			// Menu_Options
			// 
			this.Menu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_CameraOptions,
            this.Menu_StageOptions});
			this.Menu_Options.Name = "Menu_Options";
			this.Menu_Options.Size = new System.Drawing.Size(73, 24);
			this.Menu_Options.Text = "Options";
			// 
			// Menu_CameraOptions
			// 
			this.Menu_CameraOptions.Name = "Menu_CameraOptions";
			this.Menu_CameraOptions.Size = new System.Drawing.Size(216, 26);
			this.Menu_CameraOptions.Text = "Camera Options";
			this.Menu_CameraOptions.Click += new System.EventHandler(this.Menu_CameraOptions_Click);
			// 
			// Menu_StageOptions
			// 
			this.Menu_StageOptions.Name = "Menu_StageOptions";
			this.Menu_StageOptions.Size = new System.Drawing.Size(216, 26);
			this.Menu_StageOptions.Text = "Stage Options";
			this.Menu_StageOptions.Click += new System.EventHandler(this.Menu_StageOptions_Click);
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
			// Btn_ConnectCamera
			// 
			this.Btn_ConnectCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_ConnectCamera.Location = new System.Drawing.Point(465, 31);
			this.Btn_ConnectCamera.Name = "Btn_ConnectCamera";
			this.Btn_ConnectCamera.Size = new System.Drawing.Size(75, 23);
			this.Btn_ConnectCamera.TabIndex = 4;
			this.Btn_ConnectCamera.Text = "Connect";
			this.Btn_ConnectCamera.UseVisualStyleBackColor = true;
			this.Btn_ConnectCamera.Click += new System.EventHandler(this.Control_ConnectToCamera);
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
			this.CameraFeed.Size = new System.Drawing.Size(517, 311);
			this.CameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CameraFeed.TabIndex = 3;
			this.CameraFeed.TabStop = false;
			// 
			// Btn_Record
			// 
			this.Btn_Record.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Btn_Record.Location = new System.Drawing.Point(23, 393);
			this.Btn_Record.Name = "Btn_Record";
			this.Btn_Record.Size = new System.Drawing.Size(83, 23);
			this.Btn_Record.TabIndex = 9;
			this.Btn_Record.Text = "Record";
			this.Btn_Record.UseVisualStyleBackColor = true;
			this.Btn_Record.Click += new System.EventHandler(this.Control_Record);
			// 
			// RecordingBorder
			// 
			this.RecordingBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RecordingBorder.BackColor = System.Drawing.Color.Red;
			this.RecordingBorder.Controls.Add(this.ConstantBackground);
			this.RecordingBorder.Location = new System.Drawing.Point(15, 60);
			this.RecordingBorder.Name = "RecordingBorder";
			this.RecordingBorder.Size = new System.Drawing.Size(533, 327);
			this.RecordingBorder.TabIndex = 11;
			// 
			// ConstantBackground
			// 
			this.ConstantBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConstantBackground.BackColor = System.Drawing.SystemColors.Control;
			this.ConstantBackground.Controls.Add(this.CameraFeed);
			this.ConstantBackground.Location = new System.Drawing.Point(5, 5);
			this.ConstantBackground.Name = "ConstantBackground";
			this.ConstantBackground.Size = new System.Drawing.Size(523, 317);
			this.ConstantBackground.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "Camera Feed";
			// 
			// ScreenshotViewer
			// 
			this.ScreenshotViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScreenshotViewer.BackColor = System.Drawing.Color.Black;
			this.ScreenshotViewer.Image = ((System.Drawing.Image)(resources.GetObject("ScreenshotViewer.Image")));
			this.ScreenshotViewer.Location = new System.Drawing.Point(554, 68);
			this.ScreenshotViewer.Name = "ScreenshotViewer";
			this.ScreenshotViewer.Size = new System.Drawing.Size(365, 186);
			this.ScreenshotViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ScreenshotViewer.TabIndex = 13;
			this.ScreenshotViewer.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(551, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 17);
			this.label2.TabIndex = 14;
			this.label2.Text = "Latest Screenshot";
			// 
			// Btn_TakeScreenshot
			// 
			this.Btn_TakeScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_TakeScreenshot.Location = new System.Drawing.Point(554, 260);
			this.Btn_TakeScreenshot.Name = "Btn_TakeScreenshot";
			this.Btn_TakeScreenshot.Size = new System.Drawing.Size(98, 23);
			this.Btn_TakeScreenshot.TabIndex = 15;
			this.Btn_TakeScreenshot.Text = "Screenshot";
			this.Btn_TakeScreenshot.UseVisualStyleBackColor = true;
			this.Btn_TakeScreenshot.Click += new System.EventHandler(this.Control_TakeScreenshot);
			// 
			// Btn_SaveScreenshot
			// 
			this.Btn_SaveScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_SaveScreenshot.Location = new System.Drawing.Point(844, 260);
			this.Btn_SaveScreenshot.Name = "Btn_SaveScreenshot";
			this.Btn_SaveScreenshot.Size = new System.Drawing.Size(75, 23);
			this.Btn_SaveScreenshot.TabIndex = 16;
			this.Btn_SaveScreenshot.Text = "Save As";
			this.Btn_SaveScreenshot.UseVisualStyleBackColor = true;
			this.Btn_SaveScreenshot.Click += new System.EventHandler(this.Control_SaveScreenshot);
			// 
			// Seperator
			// 
			this.Seperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Seperator.BackColor = System.Drawing.Color.DimGray;
			this.Seperator.Location = new System.Drawing.Point(554, 287);
			this.Seperator.Name = "Seperator";
			this.Seperator.Size = new System.Drawing.Size(362, 5);
			this.Seperator.TabIndex = 17;
			// 
			// StagePanel
			// 
			this.StagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.StagePanel.BackColor = System.Drawing.SystemColors.Control;
			this.StagePanel.Controls.Add(this.Label_CurrentPosition);
			this.StagePanel.Controls.Add(this.Btn_JogNegative);
			this.StagePanel.Controls.Add(this.Btn_WalkPositive);
			this.StagePanel.Controls.Add(this.label6);
			this.StagePanel.Controls.Add(this.Btn_JogPositive);
			this.StagePanel.Controls.Add(this.Btn_WalkNegative);
			this.StagePanel.Controls.Add(this.Btn_Absolute);
			this.StagePanel.Controls.Add(this.label5);
			this.StagePanel.Controls.Add(this.Numeric_Absolute);
			this.StagePanel.Controls.Add(this.label4);
			this.StagePanel.Controls.Add(this.Btn_RelativePositive);
			this.StagePanel.Controls.Add(this.Btn_RelativeNegative);
			this.StagePanel.Controls.Add(this.Numeric_Relative);
			this.StagePanel.Controls.Add(this.Btn_ConnectStage);
			this.StagePanel.Controls.Add(this.label3);
			this.StagePanel.Location = new System.Drawing.Point(554, 300);
			this.StagePanel.Name = "StagePanel";
			this.StagePanel.Size = new System.Drawing.Size(365, 129);
			this.StagePanel.TabIndex = 18;
			// 
			// Label_CurrentPosition
			// 
			this.Label_CurrentPosition.AutoSize = true;
			this.Label_CurrentPosition.Location = new System.Drawing.Point(129, 9);
			this.Label_CurrentPosition.Name = "Label_CurrentPosition";
			this.Label_CurrentPosition.Size = new System.Drawing.Size(102, 17);
			this.Label_CurrentPosition.TabIndex = 14;
			this.Label_CurrentPosition.Text = "10.000000 mm";
			// 
			// Btn_JogNegative
			// 
			this.Btn_JogNegative.Location = new System.Drawing.Point(3, 103);
			this.Btn_JogNegative.Name = "Btn_JogNegative";
			this.Btn_JogNegative.Size = new System.Drawing.Size(80, 23);
			this.Btn_JogNegative.TabIndex = 13;
			this.Btn_JogNegative.Text = "<<";
			this.Btn_JogNegative.UseVisualStyleBackColor = true;
			this.Btn_JogNegative.Click += new System.EventHandler(this.Control_JogNegative);
			// 
			// Btn_WalkPositive
			// 
			this.Btn_WalkPositive.Location = new System.Drawing.Point(201, 103);
			this.Btn_WalkPositive.Name = "Btn_WalkPositive";
			this.Btn_WalkPositive.Size = new System.Drawing.Size(80, 23);
			this.Btn_WalkPositive.TabIndex = 12;
			this.Btn_WalkPositive.Text = "Positive";
			this.Btn_WalkPositive.UseVisualStyleBackColor = true;
			this.Btn_WalkPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_WalkPositive);
			this.Btn_WalkPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_StopWalk);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(166, 106);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 17);
			this.label6.TabIndex = 11;
			this.label6.Text = "Jog";
			// 
			// Btn_JogPositive
			// 
			this.Btn_JogPositive.Location = new System.Drawing.Point(282, 103);
			this.Btn_JogPositive.Name = "Btn_JogPositive";
			this.Btn_JogPositive.Size = new System.Drawing.Size(80, 23);
			this.Btn_JogPositive.TabIndex = 10;
			this.Btn_JogPositive.Text = ">>";
			this.Btn_JogPositive.UseVisualStyleBackColor = true;
			this.Btn_JogPositive.Click += new System.EventHandler(this.Control_JogPositive);
			// 
			// Btn_WalkNegative
			// 
			this.Btn_WalkNegative.Location = new System.Drawing.Point(84, 103);
			this.Btn_WalkNegative.Name = "Btn_WalkNegative";
			this.Btn_WalkNegative.Size = new System.Drawing.Size(80, 23);
			this.Btn_WalkNegative.TabIndex = 9;
			this.Btn_WalkNegative.Text = "Negative";
			this.Btn_WalkNegative.UseVisualStyleBackColor = true;
			this.Btn_WalkNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_WalkNegative);
			this.Btn_WalkNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_StopWalk);
			// 
			// Btn_Absolute
			// 
			this.Btn_Absolute.Location = new System.Drawing.Point(282, 64);
			this.Btn_Absolute.Name = "Btn_Absolute";
			this.Btn_Absolute.Size = new System.Drawing.Size(80, 23);
			this.Btn_Absolute.TabIndex = 8;
			this.Btn_Absolute.Text = "Move To";
			this.Btn_Absolute.UseVisualStyleBackColor = true;
			this.Btn_Absolute.Click += new System.EventHandler(this.Control_MoveAbsolute);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(246, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 17);
			this.label5.TabIndex = 7;
			this.label5.Text = "mm";
			// 
			// Numeric_Absolute
			// 
			this.Numeric_Absolute.DecimalPlaces = 6;
			this.Numeric_Absolute.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			this.Numeric_Absolute.Location = new System.Drawing.Point(89, 65);
			this.Numeric_Absolute.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.Numeric_Absolute.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
			this.Numeric_Absolute.Name = "Numeric_Absolute";
			this.Numeric_Absolute.Size = new System.Drawing.Size(151, 22);
			this.Numeric_Absolute.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(246, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "mm";
			// 
			// Btn_RelativePositive
			// 
			this.Btn_RelativePositive.Location = new System.Drawing.Point(282, 35);
			this.Btn_RelativePositive.Name = "Btn_RelativePositive";
			this.Btn_RelativePositive.Size = new System.Drawing.Size(80, 23);
			this.Btn_RelativePositive.TabIndex = 4;
			this.Btn_RelativePositive.Text = "Positive";
			this.Btn_RelativePositive.UseVisualStyleBackColor = true;
			this.Btn_RelativePositive.Click += new System.EventHandler(this.Control_MoveRelativePositive);
			// 
			// Btn_RelativeNegative
			// 
			this.Btn_RelativeNegative.Location = new System.Drawing.Point(3, 35);
			this.Btn_RelativeNegative.Name = "Btn_RelativeNegative";
			this.Btn_RelativeNegative.Size = new System.Drawing.Size(80, 23);
			this.Btn_RelativeNegative.TabIndex = 3;
			this.Btn_RelativeNegative.Text = "Negative";
			this.Btn_RelativeNegative.UseVisualStyleBackColor = true;
			this.Btn_RelativeNegative.Click += new System.EventHandler(this.Control_MoveRelativeNegative);
			// 
			// Numeric_Relative
			// 
			this.Numeric_Relative.DecimalPlaces = 6;
			this.Numeric_Relative.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			this.Numeric_Relative.Location = new System.Drawing.Point(89, 36);
			this.Numeric_Relative.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            393216});
			this.Numeric_Relative.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			this.Numeric_Relative.Name = "Numeric_Relative";
			this.Numeric_Relative.Size = new System.Drawing.Size(151, 22);
			this.Numeric_Relative.TabIndex = 2;
			this.Numeric_Relative.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			// 
			// Btn_ConnectStage
			// 
			this.Btn_ConnectStage.Location = new System.Drawing.Point(282, 6);
			this.Btn_ConnectStage.Name = "Btn_ConnectStage";
			this.Btn_ConnectStage.Size = new System.Drawing.Size(80, 23);
			this.Btn_ConnectStage.TabIndex = 1;
			this.Btn_ConnectStage.Text = "Connect";
			this.Btn_ConnectStage.UseVisualStyleBackColor = true;
			this.Btn_ConnectStage.Click += new System.EventHandler(this.Control_ConnectToStage);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Stage Control";
			// 
			// PositionTimer
			// 
			this.PositionTimer.Interval = 500;
			this.PositionTimer.Tick += new System.EventHandler(this.PositionTimer_Tick);
			// 
			// ControlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(931, 457);
			this.Controls.Add(this.StagePanel);
			this.Controls.Add(this.Seperator);
			this.Controls.Add(this.Btn_SaveScreenshot);
			this.Controls.Add(this.Btn_TakeScreenshot);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ScreenshotViewer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RecordingBorder);
			this.Controls.Add(this.Btn_Record);
			this.Controls.Add(this.Btn_ConnectCamera);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "ControlForm";
			this.Text = "Main Controller";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
			this.Load += new System.EventHandler(this.ControlForm_Load);
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).EndInit();
			this.RecordingBorder.ResumeLayout(false);
			this.ConstantBackground.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ScreenshotViewer)).EndInit();
			this.StagePanel.ResumeLayout(false);
			this.StagePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Absolute)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Relative)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel FPSStatusLabel;
		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ScreenshotMenuItem;
		private System.Windows.Forms.Button Btn_ConnectCamera;
		private System.Windows.Forms.PictureBox CameraFeed;
		private System.Windows.Forms.ToolStripMenuItem TestMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TestPatternMenuItem;
		private System.Windows.Forms.Button Btn_Record;
		private System.Windows.Forms.Panel RecordingBorder;
		private System.Windows.Forms.Panel ConstantBackground;
		private System.Windows.Forms.ToolStripMenuItem Menu_Options;
		private System.Windows.Forms.ToolStripMenuItem Menu_CameraOptions;
		private System.Windows.Forms.ToolStripMenuItem Menu_StageOptions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox ScreenshotViewer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Btn_TakeScreenshot;
		private System.Windows.Forms.Button Btn_SaveScreenshot;
		private System.Windows.Forms.Panel Seperator;
		private System.Windows.Forms.Panel StagePanel;
		private System.Windows.Forms.Button Btn_ConnectStage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button Btn_JogPositive;
		private System.Windows.Forms.Button Btn_WalkNegative;
		private System.Windows.Forms.Button Btn_Absolute;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown Numeric_Absolute;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button Btn_RelativePositive;
		private System.Windows.Forms.Button Btn_RelativeNegative;
		private System.Windows.Forms.NumericUpDown Numeric_Relative;
		private System.Windows.Forms.Button Btn_JogNegative;
		private System.Windows.Forms.Button Btn_WalkPositive;
		private System.Windows.Forms.Label Label_CurrentPosition;
		private System.Windows.Forms.Timer PositionTimer;
	}
}

