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
			this.TestPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Btn_ConnectCamera = new System.Windows.Forms.Button();
			this.CameraFeed = new System.Windows.Forms.PictureBox();
			this.Btn_Record = new System.Windows.Forms.Button();
			this.RecordingBorder = new System.Windows.Forms.Panel();
			this.ConstantBackground = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.Btn_TakeScreenshot = new System.Windows.Forms.Button();
			this.Label_PositionTheory = new System.Windows.Forms.Label();
			this.Btn_JogNegative = new System.Windows.Forms.Button();
			this.Btn_WalkPositive = new System.Windows.Forms.Button();
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
			this.PositionTimer = new System.Windows.Forms.Timer(this.components);
			this.StageTabs = new System.Windows.Forms.TabControl();
			this.Tab_StageControls = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Numeric_JogVelocityPercent = new System.Windows.Forms.NumericUpDown();
			this.Numeric_JogVelocityActual = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Tab_StageSettings = new System.Windows.Forms.TabPage();
			this.Btn_Home = new System.Windows.Forms.Button();
			this.Btn_ViewErrors = new System.Windows.Forms.Button();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.Numeric_JogAcceleration = new System.Windows.Forms.NumericUpDown();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.Numeric_Deceleration = new System.Windows.Forms.NumericUpDown();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.Numeric_Acceleration = new System.Windows.Forms.NumericUpDown();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.Numeric_TravelVelocity = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.Btn_StopJog = new System.Windows.Forms.Button();
			this.Label_PositionEncoder = new System.Windows.Forms.Label();
			this.StatusStrip.SuspendLayout();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CameraFeed)).BeginInit();
			this.RecordingBorder.SuspendLayout();
			this.ConstantBackground.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Absolute)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Relative)).BeginInit();
			this.StageTabs.SuspendLayout();
			this.Tab_StageControls.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityPercent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityActual)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.Tab_StageSettings.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogAcceleration)).BeginInit();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Deceleration)).BeginInit();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Acceleration)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_TravelVelocity)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FPSStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 428);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(923, 25);
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
            this.Menu_Options});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(923, 28);
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
			this.ScreenshotMenuItem.Click += new System.EventHandler(this.Control_TakeScreenshot);
			// 
			// Menu_Options
			// 
			this.Menu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_CameraOptions,
            this.TestPatternMenuItem});
			this.Menu_Options.Name = "Menu_Options";
			this.Menu_Options.Size = new System.Drawing.Size(73, 24);
			this.Menu_Options.Text = "Options";
			// 
			// Menu_CameraOptions
			// 
			this.Menu_CameraOptions.Name = "Menu_CameraOptions";
			this.Menu_CameraOptions.Size = new System.Drawing.Size(191, 26);
			this.Menu_CameraOptions.Text = "Camera Options";
			this.Menu_CameraOptions.Click += new System.EventHandler(this.Menu_CameraOptions_Click);
			// 
			// TestPatternMenuItem
			// 
			this.TestPatternMenuItem.Name = "TestPatternMenuItem";
			this.TestPatternMenuItem.Size = new System.Drawing.Size(191, 26);
			this.TestPatternMenuItem.Text = "Test Pattern";
			// 
			// Btn_ConnectCamera
			// 
			this.Btn_ConnectCamera.Location = new System.Drawing.Point(119, 34);
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
			this.CameraFeed.Size = new System.Drawing.Size(519, 307);
			this.CameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CameraFeed.TabIndex = 3;
			this.CameraFeed.TabStop = false;
			// 
			// Btn_Record
			// 
			this.Btn_Record.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Btn_Record.Location = new System.Drawing.Point(23, 389);
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
			this.RecordingBorder.Size = new System.Drawing.Size(535, 323);
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
			this.ConstantBackground.Size = new System.Drawing.Size(525, 313);
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
			// Btn_TakeScreenshot
			// 
			this.Btn_TakeScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_TakeScreenshot.Location = new System.Drawing.Point(444, 389);
			this.Btn_TakeScreenshot.Name = "Btn_TakeScreenshot";
			this.Btn_TakeScreenshot.Size = new System.Drawing.Size(98, 23);
			this.Btn_TakeScreenshot.TabIndex = 15;
			this.Btn_TakeScreenshot.Text = "Screenshot";
			this.Btn_TakeScreenshot.UseVisualStyleBackColor = true;
			this.Btn_TakeScreenshot.Click += new System.EventHandler(this.Control_TakeScreenshot);
			// 
			// Label_PositionTheory
			// 
			this.Label_PositionTheory.AutoSize = true;
			this.Label_PositionTheory.Location = new System.Drawing.Point(9, 3);
			this.Label_PositionTheory.Name = "Label_PositionTheory";
			this.Label_PositionTheory.Size = new System.Drawing.Size(235, 17);
			this.Label_PositionTheory.TabIndex = 14;
			this.Label_PositionTheory.Text = "Theoretical Position: 10.000000 mm";
			// 
			// Btn_JogNegative
			// 
			this.Btn_JogNegative.Location = new System.Drawing.Point(6, 48);
			this.Btn_JogNegative.Name = "Btn_JogNegative";
			this.Btn_JogNegative.Size = new System.Drawing.Size(80, 23);
			this.Btn_JogNegative.TabIndex = 13;
			this.Btn_JogNegative.Text = "Negative";
			this.Btn_JogNegative.UseVisualStyleBackColor = true;
			this.Btn_JogNegative.Click += new System.EventHandler(this.Control_JogNegative);
			// 
			// Btn_WalkPositive
			// 
			this.Btn_WalkPositive.Location = new System.Drawing.Point(92, 22);
			this.Btn_WalkPositive.Name = "Btn_WalkPositive";
			this.Btn_WalkPositive.Size = new System.Drawing.Size(80, 23);
			this.Btn_WalkPositive.TabIndex = 12;
			this.Btn_WalkPositive.Text = "Positive";
			this.Btn_WalkPositive.UseVisualStyleBackColor = true;
			this.Btn_WalkPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_WalkPositive);
			this.Btn_WalkPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_StopWalk);
			// 
			// Btn_JogPositive
			// 
			this.Btn_JogPositive.Location = new System.Drawing.Point(92, 48);
			this.Btn_JogPositive.Name = "Btn_JogPositive";
			this.Btn_JogPositive.Size = new System.Drawing.Size(80, 23);
			this.Btn_JogPositive.TabIndex = 10;
			this.Btn_JogPositive.Text = "Positive";
			this.Btn_JogPositive.UseVisualStyleBackColor = true;
			this.Btn_JogPositive.Click += new System.EventHandler(this.Control_JogPositive);
			// 
			// Btn_WalkNegative
			// 
			this.Btn_WalkNegative.Location = new System.Drawing.Point(6, 21);
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
			this.Btn_Absolute.Location = new System.Drawing.Point(6, 49);
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
			this.label5.Location = new System.Drawing.Point(142, 23);
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
			this.Numeric_Absolute.Location = new System.Drawing.Point(6, 21);
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
			this.Numeric_Absolute.Size = new System.Drawing.Size(130, 22);
			this.Numeric_Absolute.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(142, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "mm";
			// 
			// Btn_RelativePositive
			// 
			this.Btn_RelativePositive.Location = new System.Drawing.Point(92, 49);
			this.Btn_RelativePositive.Name = "Btn_RelativePositive";
			this.Btn_RelativePositive.Size = new System.Drawing.Size(80, 23);
			this.Btn_RelativePositive.TabIndex = 4;
			this.Btn_RelativePositive.Text = "Positive";
			this.Btn_RelativePositive.UseVisualStyleBackColor = true;
			this.Btn_RelativePositive.Click += new System.EventHandler(this.Control_MoveRelativePositive);
			// 
			// Btn_RelativeNegative
			// 
			this.Btn_RelativeNegative.Location = new System.Drawing.Point(6, 49);
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
			this.Numeric_Relative.Location = new System.Drawing.Point(6, 21);
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
			this.Numeric_Relative.Size = new System.Drawing.Size(130, 22);
			this.Numeric_Relative.TabIndex = 2;
			this.Numeric_Relative.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			// 
			// Btn_ConnectStage
			// 
			this.Btn_ConnectStage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_ConnectStage.Location = new System.Drawing.Point(664, 34);
			this.Btn_ConnectStage.Name = "Btn_ConnectStage";
			this.Btn_ConnectStage.Size = new System.Drawing.Size(80, 23);
			this.Btn_ConnectStage.TabIndex = 1;
			this.Btn_ConnectStage.Text = "Connect";
			this.Btn_ConnectStage.UseVisualStyleBackColor = true;
			this.Btn_ConnectStage.Click += new System.EventHandler(this.Control_ConnectToStage);
			// 
			// PositionTimer
			// 
			this.PositionTimer.Interval = 500;
			this.PositionTimer.Tick += new System.EventHandler(this.PositionTimer_Tick);
			// 
			// StageTabs
			// 
			this.StageTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StageTabs.Controls.Add(this.Tab_StageControls);
			this.StageTabs.Controls.Add(this.Tab_StageSettings);
			this.StageTabs.Location = new System.Drawing.Point(556, 60);
			this.StageTabs.Name = "StageTabs";
			this.StageTabs.SelectedIndex = 0;
			this.StageTabs.Size = new System.Drawing.Size(355, 365);
			this.StageTabs.TabIndex = 19;
			// 
			// Tab_StageControls
			// 
			this.Tab_StageControls.AutoScroll = true;
			this.Tab_StageControls.Controls.Add(this.Label_PositionEncoder);
			this.Tab_StageControls.Controls.Add(this.groupBox4);
			this.Tab_StageControls.Controls.Add(this.groupBox3);
			this.Tab_StageControls.Controls.Add(this.Label_PositionTheory);
			this.Tab_StageControls.Controls.Add(this.groupBox2);
			this.Tab_StageControls.Controls.Add(this.groupBox1);
			this.Tab_StageControls.Location = new System.Drawing.Point(4, 25);
			this.Tab_StageControls.Name = "Tab_StageControls";
			this.Tab_StageControls.Padding = new System.Windows.Forms.Padding(3);
			this.Tab_StageControls.Size = new System.Drawing.Size(347, 336);
			this.Tab_StageControls.TabIndex = 0;
			this.Tab_StageControls.Text = "Controls";
			this.Tab_StageControls.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.Btn_WalkPositive);
			this.groupBox4.Controls.Add(this.Btn_WalkNegative);
			this.groupBox4.Location = new System.Drawing.Point(6, 282);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(308, 50);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Manual Control";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Btn_StopJog);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.Numeric_JogVelocityPercent);
			this.groupBox3.Controls.Add(this.Numeric_JogVelocityActual);
			this.groupBox3.Controls.Add(this.Btn_JogNegative);
			this.groupBox3.Controls.Add(this.Btn_JogPositive);
			this.groupBox3.Location = new System.Drawing.Point(6, 205);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(308, 77);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Jog";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(283, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 17);
			this.label6.TabIndex = 15;
			this.label6.Text = "%";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(142, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 17);
			this.label3.TabIndex = 9;
			this.label3.Text = "mm/s";
			// 
			// Numeric_JogVelocityPercent
			// 
			this.Numeric_JogVelocityPercent.DecimalPlaces = 3;
			this.Numeric_JogVelocityPercent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityPercent.Location = new System.Drawing.Point(189, 21);
			this.Numeric_JogVelocityPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityPercent.Name = "Numeric_JogVelocityPercent";
			this.Numeric_JogVelocityPercent.Size = new System.Drawing.Size(88, 22);
			this.Numeric_JogVelocityPercent.TabIndex = 14;
			this.Numeric_JogVelocityPercent.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.Numeric_JogVelocityPercent.ValueChanged += new System.EventHandler(this.Numeric_JogVelocityPercent_ValueChanged);
			// 
			// Numeric_JogVelocityActual
			// 
			this.Numeric_JogVelocityActual.DecimalPlaces = 3;
			this.Numeric_JogVelocityActual.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityActual.Location = new System.Drawing.Point(6, 21);
			this.Numeric_JogVelocityActual.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            196608});
			this.Numeric_JogVelocityActual.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            524288});
			this.Numeric_JogVelocityActual.Name = "Numeric_JogVelocityActual";
			this.Numeric_JogVelocityActual.Size = new System.Drawing.Size(130, 22);
			this.Numeric_JogVelocityActual.TabIndex = 9;
			this.Numeric_JogVelocityActual.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityActual.ValueChanged += new System.EventHandler(this.Numeric_JogVelocityActual_ValueChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Numeric_Absolute);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.Btn_Absolute);
			this.groupBox2.Location = new System.Drawing.Point(6, 122);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(308, 77);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Absolute";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Btn_RelativeNegative);
			this.groupBox1.Controls.Add(this.Numeric_Relative);
			this.groupBox1.Controls.Add(this.Btn_RelativePositive);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(6, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(308, 78);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Relative";
			// 
			// Tab_StageSettings
			// 
			this.Tab_StageSettings.AutoScroll = true;
			this.Tab_StageSettings.Controls.Add(this.Btn_Home);
			this.Tab_StageSettings.Controls.Add(this.Btn_ViewErrors);
			this.Tab_StageSettings.Controls.Add(this.groupBox8);
			this.Tab_StageSettings.Controls.Add(this.groupBox7);
			this.Tab_StageSettings.Controls.Add(this.groupBox6);
			this.Tab_StageSettings.Controls.Add(this.groupBox5);
			this.Tab_StageSettings.Location = new System.Drawing.Point(4, 25);
			this.Tab_StageSettings.Name = "Tab_StageSettings";
			this.Tab_StageSettings.Padding = new System.Windows.Forms.Padding(3);
			this.Tab_StageSettings.Size = new System.Drawing.Size(347, 323);
			this.Tab_StageSettings.TabIndex = 1;
			this.Tab_StageSettings.Text = "Settings";
			this.Tab_StageSettings.UseVisualStyleBackColor = true;
			// 
			// Btn_Home
			// 
			this.Btn_Home.Location = new System.Drawing.Point(6, 230);
			this.Btn_Home.Name = "Btn_Home";
			this.Btn_Home.Size = new System.Drawing.Size(96, 23);
			this.Btn_Home.TabIndex = 22;
			this.Btn_Home.Text = "Home";
			this.Btn_Home.UseVisualStyleBackColor = true;
			this.Btn_Home.Click += new System.EventHandler(this.Btn_Home_Click);
			// 
			// Btn_ViewErrors
			// 
			this.Btn_ViewErrors.Location = new System.Drawing.Point(6, 259);
			this.Btn_ViewErrors.Name = "Btn_ViewErrors";
			this.Btn_ViewErrors.Size = new System.Drawing.Size(96, 23);
			this.Btn_ViewErrors.TabIndex = 21;
			this.Btn_ViewErrors.Text = "View Errors";
			this.Btn_ViewErrors.UseVisualStyleBackColor = true;
			this.Btn_ViewErrors.Click += new System.EventHandler(this.Btn_ViewErrors_Click);
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label10);
			this.groupBox8.Controls.Add(this.Numeric_JogAcceleration);
			this.groupBox8.Location = new System.Drawing.Point(6, 174);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(308, 50);
			this.groupBox8.TabIndex = 19;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Jog Acceleration";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(142, 23);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 17);
			this.label10.TabIndex = 18;
			this.label10.Text = "mm/s^2";
			// 
			// Numeric_JogAcceleration
			// 
			this.Numeric_JogAcceleration.DecimalPlaces = 3;
			this.Numeric_JogAcceleration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogAcceleration.Location = new System.Drawing.Point(6, 21);
			this.Numeric_JogAcceleration.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            196608});
			this.Numeric_JogAcceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogAcceleration.Name = "Numeric_JogAcceleration";
			this.Numeric_JogAcceleration.Size = new System.Drawing.Size(130, 22);
			this.Numeric_JogAcceleration.TabIndex = 17;
			this.Numeric_JogAcceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogAcceleration.ValueChanged += new System.EventHandler(this.Numeric_JogAcceleration_ValueChanged);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label9);
			this.groupBox7.Controls.Add(this.Numeric_Deceleration);
			this.groupBox7.Location = new System.Drawing.Point(6, 118);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(308, 50);
			this.groupBox7.TabIndex = 19;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Deceleration";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(142, 23);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 17);
			this.label9.TabIndex = 18;
			this.label9.Text = "mm/s^2";
			// 
			// Numeric_Deceleration
			// 
			this.Numeric_Deceleration.DecimalPlaces = 3;
			this.Numeric_Deceleration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Deceleration.Location = new System.Drawing.Point(6, 21);
			this.Numeric_Deceleration.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            196608});
			this.Numeric_Deceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Deceleration.Name = "Numeric_Deceleration";
			this.Numeric_Deceleration.Size = new System.Drawing.Size(130, 22);
			this.Numeric_Deceleration.TabIndex = 17;
			this.Numeric_Deceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Deceleration.ValueChanged += new System.EventHandler(this.Numeric_Deceleration_ValueChanged);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label8);
			this.groupBox6.Controls.Add(this.Numeric_Acceleration);
			this.groupBox6.Location = new System.Drawing.Point(6, 62);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(308, 50);
			this.groupBox6.TabIndex = 19;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Acceleration";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(142, 23);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 17);
			this.label8.TabIndex = 18;
			this.label8.Text = "mm/s^2";
			// 
			// Numeric_Acceleration
			// 
			this.Numeric_Acceleration.DecimalPlaces = 3;
			this.Numeric_Acceleration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Acceleration.Location = new System.Drawing.Point(6, 21);
			this.Numeric_Acceleration.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            196608});
			this.Numeric_Acceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Acceleration.Name = "Numeric_Acceleration";
			this.Numeric_Acceleration.Size = new System.Drawing.Size(130, 22);
			this.Numeric_Acceleration.TabIndex = 17;
			this.Numeric_Acceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Acceleration.ValueChanged += new System.EventHandler(this.Numeric_Acceleration_ValueChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.Numeric_TravelVelocity);
			this.groupBox5.Location = new System.Drawing.Point(6, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(308, 50);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Travel Velocity";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(142, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 17);
			this.label7.TabIndex = 18;
			this.label7.Text = "mm/s";
			// 
			// Numeric_TravelVelocity
			// 
			this.Numeric_TravelVelocity.DecimalPlaces = 3;
			this.Numeric_TravelVelocity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_TravelVelocity.Location = new System.Drawing.Point(6, 21);
			this.Numeric_TravelVelocity.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            196608});
			this.Numeric_TravelVelocity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_TravelVelocity.Name = "Numeric_TravelVelocity";
			this.Numeric_TravelVelocity.Size = new System.Drawing.Size(130, 22);
			this.Numeric_TravelVelocity.TabIndex = 17;
			this.Numeric_TravelVelocity.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_TravelVelocity.ValueChanged += new System.EventHandler(this.Numeric_TravelVelocity_ValueChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(557, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 17);
			this.label2.TabIndex = 20;
			this.label2.Text = "Stage Controls";
			// 
			// Btn_StopJog
			// 
			this.Btn_StopJog.Location = new System.Drawing.Point(178, 48);
			this.Btn_StopJog.Name = "Btn_StopJog";
			this.Btn_StopJog.Size = new System.Drawing.Size(80, 23);
			this.Btn_StopJog.TabIndex = 16;
			this.Btn_StopJog.Text = "Stop";
			this.Btn_StopJog.UseVisualStyleBackColor = true;
			this.Btn_StopJog.Click += new System.EventHandler(this.Btn_StopJog_Click);
			// 
			// Label_PositionEncoder
			// 
			this.Label_PositionEncoder.AutoSize = true;
			this.Label_PositionEncoder.Location = new System.Drawing.Point(9, 20);
			this.Label_PositionEncoder.Name = "Label_PositionEncoder";
			this.Label_PositionEncoder.Size = new System.Drawing.Size(233, 17);
			this.Label_PositionEncoder.TabIndex = 17;
			this.Label_PositionEncoder.Text = "Encoder Position:     10.000000 mm";
			// 
			// ControlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(923, 453);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.StageTabs);
			this.Controls.Add(this.Btn_TakeScreenshot);
			this.Controls.Add(this.Btn_ConnectStage);
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
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Absolute)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Relative)).EndInit();
			this.StageTabs.ResumeLayout(false);
			this.Tab_StageControls.ResumeLayout(false);
			this.Tab_StageControls.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityPercent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityActual)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.Tab_StageSettings.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogAcceleration)).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Deceleration)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Acceleration)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_TravelVelocity)).EndInit();
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
		private System.Windows.Forms.Button Btn_Record;
		private System.Windows.Forms.Panel RecordingBorder;
		private System.Windows.Forms.Panel ConstantBackground;
		private System.Windows.Forms.ToolStripMenuItem Menu_Options;
		private System.Windows.Forms.ToolStripMenuItem Menu_CameraOptions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Btn_TakeScreenshot;
		private System.Windows.Forms.Button Btn_ConnectStage;
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
		private System.Windows.Forms.Label Label_PositionTheory;
		private System.Windows.Forms.Timer PositionTimer;
		private System.Windows.Forms.TabControl StageTabs;
		private System.Windows.Forms.TabPage Tab_StageControls;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage Tab_StageSettings;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown Numeric_JogVelocityPercent;
		private System.Windows.Forms.NumericUpDown Numeric_JogVelocityActual;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown Numeric_TravelVelocity;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown Numeric_Deceleration;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown Numeric_Acceleration;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown Numeric_JogAcceleration;
		private System.Windows.Forms.Button Btn_Home;
		private System.Windows.Forms.Button Btn_ViewErrors;
		private System.Windows.Forms.ToolStripMenuItem TestPatternMenuItem;
		private System.Windows.Forms.Button Btn_StopJog;
		private System.Windows.Forms.Label Label_PositionEncoder;
	}
}

