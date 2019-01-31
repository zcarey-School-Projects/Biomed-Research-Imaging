using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.MotorizedStage;

namespace UndergradResearchBiomedImaging {
	public partial class StageOptionsForm : Form {

		private ControlForm form;
		private StageController stage;

		public StageOptionsForm(ControlForm form, StageController stage) {
			InitializeComponent();
			this.form = form;
			this.stage = stage;
		}

		private void StageOptionsForm_Load(object sender, EventArgs e) {

		}

		private void StageOptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		private void StageOptionsForm_Shown(object sender, EventArgs e) {
			if (!UpdateAllValues()) {
				MessageBox.Show("Please connect to a stage to view accurate values.");
				//this.Hide();
			}
		}

		public bool UpdateAllValues() {
			bool successful = true;

			decimal maxVelocity;
			Numeric_TravelVelocity.Maximum = (successful &= stage.TrySendCommand(new MotorizedStage.Commands.MaxVelocity(1), out maxVelocity)) ? maxVelocity : MotorizedStage.Commands.TravelVelocity.MaximumValue;
			decimal currentVelocity;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.TravelVelocity(1, true), out currentVelocity)) Numeric_TravelVelocity.Value = currentVelocity;

			decimal maxAcceleration;
			bool readAccel = stage.TrySendCommand(new MotorizedStage.Commands.MaxAcceleration(1, true), out maxAcceleration);
			Numeric_Acceleration.Maximum = (successful &= readAccel) ? maxAcceleration : MotorizedStage.Commands.Acceleration.MaximumValue;
			decimal currentAcceleration;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.Acceleration(1, true), out currentAcceleration)) Numeric_Acceleration.Value = currentAcceleration;

			Numeric_Deceleration.Maximum = (successful &= readAccel) ? maxAcceleration : MotorizedStage.Commands.Deceleration.MaximumValue;
			decimal currentDeceleration;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.Deceleration(1, true), out currentDeceleration)) Numeric_Deceleration.Value = currentDeceleration;

			Numeric_JogVelocityActual.Maximum = Numeric_TravelVelocity.Value;
			Numeric_JogVelocityActual.Value = Numeric_TravelVelocity.Value * Numeric_JogVelocityPercentage.Value / 100.0M;

			Numeric_JogAcceleration.Maximum = (readAccel) ? maxAcceleration : MotorizedStage.Commands.JogAcceleration.MaximumValue;
			decimal jogAccel;
			if (successful &= stage.TrySendCommand(new MotorizedStage.Commands.JogAcceleration(1, true), out jogAccel)) Numeric_JogAcceleration.Value = jogAccel;

			return successful;
		}

		private void Btn_ViewErrors_Click(object sender, EventArgs e) {
			bool ErrorsOccured;
			if(form.DisplayStageErrors(out ErrorsOccured)) {
				if (!ErrorsOccured) {
					MessageBox.Show("No errors have occured.");
				}
			} else {
				MessageBox.Show("Error communicating with stage.");
			}
		}

		private void Btn_Home_Click(object sender, EventArgs e) {
			HomingStatus status = stage.FindHome();
			if(status == HomingStatus.Error) {
				MessageBox.Show("An error has occured.");
			}else if(status == HomingStatus.Initiated) {
				MessageBox.Show("Homing started.");
			}else if(status == HomingStatus.InProgress) {
				MessageBox.Show("Already homing.");
			}
		}

		private decimal constrain(decimal value, decimal min, decimal max) {
			return Math.Max(min, Math.Min(max, value));
		}

		private void stageError() {
			MessageBox.Show("An error has occured.");
		}

		private void Numeric_TravelVelocity_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_TravelVelocity.Value, MotorizedStage.Commands.TravelVelocity.MinimumValue, MotorizedStage.Commands.TravelVelocity.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.TravelVelocity(1, value))) {
				decimal read;
				if(stage.TrySendCommand(new MotorizedStage.Commands.TravelVelocity(1, true), out read)) {
					Numeric_TravelVelocity.ValueChanged -= Numeric_TravelVelocity_ValueChanged;
					Numeric_TravelVelocity.Value = read;
					Numeric_TravelVelocity.ValueChanged += Numeric_TravelVelocity_ValueChanged;
					Numeric_JogVelocityPercentage_ValueChanged(null, null);
					return;
				}
			}

			Numeric_JogVelocityPercentage_ValueChanged(null, null);
			stageError();
		}

		private void Numeric_Acceleration_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_Acceleration.Value, MotorizedStage.Commands.Acceleration.MinimumValue, MotorizedStage.Commands.Acceleration.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.Acceleration(1, value))) {
				decimal read;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Acceleration(1, true), out read)) {
					Numeric_Acceleration.ValueChanged -= Numeric_Acceleration_ValueChanged;
					Numeric_Acceleration.Value = read;
					Numeric_Acceleration.ValueChanged += Numeric_Acceleration_ValueChanged;
					return;
				}
			}

			stageError();
		}

		private void Numeric_Deceleration_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_Deceleration.Value, MotorizedStage.Commands.Deceleration.MinimumValue, MotorizedStage.Commands.Deceleration.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.Deceleration(1, value))) {
				decimal read;
				if (stage.TrySendCommand(new MotorizedStage.Commands.Deceleration(1, true), out read)) {
					Numeric_Deceleration.ValueChanged -= Numeric_Deceleration_ValueChanged;
					Numeric_Deceleration.Value = read;
					Numeric_Deceleration.ValueChanged += Numeric_Deceleration_ValueChanged;
					return;
				}
			}

			stageError();
		}

		private void Numeric_JogVelocityPercentage_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_JogVelocityPercentage.Value, MotorizedStage.Commands.Jog.MinimumValue, MotorizedStage.Commands.Jog.MaximumValue);
			Numeric_JogVelocityPercentage.ValueChanged -= Numeric_JogVelocityPercentage_ValueChanged;
			Numeric_JogVelocityPercentage.Value = value;
			Numeric_JogVelocityPercentage.ValueChanged += Numeric_JogVelocityPercentage_ValueChanged;

			Numeric_JogVelocityActual.ValueChanged -= Numeric_JogVelocityActual_ValueChanged;
			Numeric_JogVelocityActual.Value = Numeric_TravelVelocity.Value * value;
			Numeric_JogVelocityActual.ValueChanged += Numeric_JogVelocityActual_ValueChanged;
		}

		private void Numeric_JogVelocityActual_ValueChanged(object sender, EventArgs e) {
			Numeric_JogVelocityPercentage.Value = Numeric_JogVelocityActual.Value / Numeric_TravelVelocity.Value; ;
		}

		private void Numeric_JogAcceleration_ValueChanged(object sender, EventArgs e) {
			decimal value = constrain(Numeric_JogAcceleration.Value, MotorizedStage.Commands.JogAcceleration.MinimumValue, MotorizedStage.Commands.JogAcceleration.MaximumValue);
			if (stage.TrySendCommand(new MotorizedStage.Commands.JogAcceleration(1, value))) {
				decimal read;
				if (stage.TrySendCommand(new MotorizedStage.Commands.JogAcceleration(1, true), out read)) {
					Numeric_JogAcceleration.ValueChanged -= Numeric_JogAcceleration_ValueChanged;
					Numeric_JogAcceleration.Value = read;
					Numeric_JogAcceleration.ValueChanged += Numeric_JogAcceleration_ValueChanged;
					return;
				}
			}

			stageError();
		}
	}
}
