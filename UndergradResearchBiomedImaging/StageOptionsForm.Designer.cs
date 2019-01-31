namespace UndergradResearchBiomedImaging {
	partial class StageOptionsForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.Btn_ViewErrors = new System.Windows.Forms.Button();
			this.Btn_Home = new System.Windows.Forms.Button();
			this.Numeric_TravelVelocity = new System.Windows.Forms.NumericUpDown();
			this.Numeric_Acceleration = new System.Windows.Forms.NumericUpDown();
			this.Numeric_Deceleration = new System.Windows.Forms.NumericUpDown();
			this.Numeric_JogVelocityActual = new System.Windows.Forms.NumericUpDown();
			this.Numeric_JogAcceleration = new System.Windows.Forms.NumericUpDown();
			this.Numeric_JogVelocityPercentage = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_TravelVelocity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Acceleration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Deceleration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityActual)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogAcceleration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityPercentage)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Acceleration:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Deceleration:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 126);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Jog Acceleration:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Travel Velocity:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(37, 98);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(92, 17);
			this.label6.TabIndex = 5;
			this.label6.Text = "Jog Velocity :";
			// 
			// Btn_ViewErrors
			// 
			this.Btn_ViewErrors.Location = new System.Drawing.Point(135, 198);
			this.Btn_ViewErrors.Name = "Btn_ViewErrors";
			this.Btn_ViewErrors.Size = new System.Drawing.Size(96, 23);
			this.Btn_ViewErrors.TabIndex = 7;
			this.Btn_ViewErrors.Text = "View Errors";
			this.Btn_ViewErrors.UseVisualStyleBackColor = true;
			this.Btn_ViewErrors.Click += new System.EventHandler(this.Btn_ViewErrors_Click);
			// 
			// Btn_Home
			// 
			this.Btn_Home.Location = new System.Drawing.Point(135, 169);
			this.Btn_Home.Name = "Btn_Home";
			this.Btn_Home.Size = new System.Drawing.Size(96, 23);
			this.Btn_Home.TabIndex = 8;
			this.Btn_Home.Text = "Home";
			this.Btn_Home.UseVisualStyleBackColor = true;
			this.Btn_Home.Click += new System.EventHandler(this.Btn_Home_Click);
			// 
			// Numeric_TravelVelocity
			// 
			this.Numeric_TravelVelocity.DecimalPlaces = 3;
			this.Numeric_TravelVelocity.Location = new System.Drawing.Point(135, 12);
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
			this.Numeric_TravelVelocity.Size = new System.Drawing.Size(120, 22);
			this.Numeric_TravelVelocity.TabIndex = 9;
			this.Numeric_TravelVelocity.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_TravelVelocity.ValueChanged += new System.EventHandler(this.Numeric_TravelVelocity_ValueChanged);
			// 
			// Numeric_Acceleration
			// 
			this.Numeric_Acceleration.DecimalPlaces = 3;
			this.Numeric_Acceleration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Acceleration.Location = new System.Drawing.Point(135, 40);
			this.Numeric_Acceleration.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            196608});
			this.Numeric_Acceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Acceleration.Name = "Numeric_Acceleration";
			this.Numeric_Acceleration.Size = new System.Drawing.Size(120, 22);
			this.Numeric_Acceleration.TabIndex = 10;
			this.Numeric_Acceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Acceleration.ValueChanged += new System.EventHandler(this.Numeric_Acceleration_ValueChanged);
			// 
			// Numeric_Deceleration
			// 
			this.Numeric_Deceleration.DecimalPlaces = 3;
			this.Numeric_Deceleration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Deceleration.Location = new System.Drawing.Point(135, 68);
			this.Numeric_Deceleration.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            196608});
			this.Numeric_Deceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Deceleration.Name = "Numeric_Deceleration";
			this.Numeric_Deceleration.Size = new System.Drawing.Size(120, 22);
			this.Numeric_Deceleration.TabIndex = 11;
			this.Numeric_Deceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_Deceleration.ValueChanged += new System.EventHandler(this.Numeric_Deceleration_ValueChanged);
			// 
			// Numeric_JogVelocityActual
			// 
			this.Numeric_JogVelocityActual.DecimalPlaces = 3;
			this.Numeric_JogVelocityActual.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityActual.Location = new System.Drawing.Point(135, 96);
			this.Numeric_JogVelocityActual.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            196608});
			this.Numeric_JogVelocityActual.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityActual.Name = "Numeric_JogVelocityActual";
			this.Numeric_JogVelocityActual.Size = new System.Drawing.Size(120, 22);
			this.Numeric_JogVelocityActual.TabIndex = 12;
			this.Numeric_JogVelocityActual.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityActual.ValueChanged += new System.EventHandler(this.Numeric_JogVelocityActual_ValueChanged);
			// 
			// Numeric_JogAcceleration
			// 
			this.Numeric_JogAcceleration.DecimalPlaces = 3;
			this.Numeric_JogAcceleration.Location = new System.Drawing.Point(135, 124);
			this.Numeric_JogAcceleration.Name = "Numeric_JogAcceleration";
			this.Numeric_JogAcceleration.Size = new System.Drawing.Size(120, 22);
			this.Numeric_JogAcceleration.TabIndex = 13;
			this.Numeric_JogAcceleration.ValueChanged += new System.EventHandler(this.Numeric_JogAcceleration_ValueChanged);
			// 
			// Numeric_JogVelocityPercentage
			// 
			this.Numeric_JogVelocityPercentage.DecimalPlaces = 3;
			this.Numeric_JogVelocityPercentage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityPercentage.Location = new System.Drawing.Point(308, 96);
			this.Numeric_JogVelocityPercentage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.Numeric_JogVelocityPercentage.Name = "Numeric_JogVelocityPercentage";
			this.Numeric_JogVelocityPercentage.Size = new System.Drawing.Size(120, 22);
			this.Numeric_JogVelocityPercentage.TabIndex = 14;
			this.Numeric_JogVelocityPercentage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.Numeric_JogVelocityPercentage.ValueChanged += new System.EventHandler(this.Numeric_JogVelocityPercentage_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(261, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 17);
			this.label3.TabIndex = 15;
			this.label3.Text = "mm/s";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(261, 14);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 17);
			this.label7.TabIndex = 16;
			this.label7.Text = "mm/s";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(434, 98);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(20, 17);
			this.label8.TabIndex = 17;
			this.label8.Text = "%";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(261, 42);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 17);
			this.label9.TabIndex = 18;
			this.label9.Text = "mm/s^2";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(261, 70);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 17);
			this.label10.TabIndex = 19;
			this.label10.Text = "mm/s^2";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(261, 126);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 17);
			this.label11.TabIndex = 20;
			this.label11.Text = "mm/s^2";
			// 
			// StageOptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 250);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Numeric_JogVelocityPercentage);
			this.Controls.Add(this.Numeric_JogAcceleration);
			this.Controls.Add(this.Numeric_JogVelocityActual);
			this.Controls.Add(this.Numeric_Deceleration);
			this.Controls.Add(this.Numeric_Acceleration);
			this.Controls.Add(this.Numeric_TravelVelocity);
			this.Controls.Add(this.Btn_Home);
			this.Controls.Add(this.Btn_ViewErrors);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "StageOptionsForm";
			this.Text = "Stage Options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StageOptionsForm_FormClosing);
			this.Load += new System.EventHandler(this.StageOptionsForm_Load);
			this.Shown += new System.EventHandler(this.StageOptionsForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.Numeric_TravelVelocity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Acceleration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_Deceleration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityActual)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogAcceleration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Numeric_JogVelocityPercentage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button Btn_ViewErrors;
		private System.Windows.Forms.Button Btn_Home;
		private System.Windows.Forms.NumericUpDown Numeric_TravelVelocity;
		private System.Windows.Forms.NumericUpDown Numeric_Acceleration;
		private System.Windows.Forms.NumericUpDown Numeric_Deceleration;
		private System.Windows.Forms.NumericUpDown Numeric_JogVelocityActual;
		private System.Windows.Forms.NumericUpDown Numeric_JogAcceleration;
		private System.Windows.Forms.NumericUpDown Numeric_JogVelocityPercentage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
	}
}