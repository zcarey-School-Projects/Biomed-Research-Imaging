using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Checks the current status of the controller.</summary>
	public class Status : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => false;

		public override bool CanReadRealTime => true;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => false;

		public override bool ExpectResponse { get; protected set; } = true;

		public override object ParseResponse(string response) {
			if (response.StartsWith("#")) {
				byte status;
				if (byte.TryParse(response.Substring(1), out status)) {
					return new StageStatus(status);
				}
			}

			return null;
		}

		/// <summary>Axis (1 to 99). Returns data as type 'StageStatus'</summary>
		public Status(byte axis) {
			Command = axis + "STA?";
		}
	}

	public class StageStatus {

		public bool ErrorHasOccured { get; private set; }
		public bool Accelerating { get; private set; }
		public bool ConstantVelocity { get; private set; }
		public bool Decelerating { get; private set; }
		public bool Stopped { get; private set; }
		public bool ProgramRunning { get; private set; }
		public bool PositiveSwitchActivated { get; private set; }
		public bool NegativeSwitchActivated { get; private set; }

		public StageStatus(byte status) {
			BitArray bits = new BitArray(new byte[] { status });
			ErrorHasOccured = bits[7];
			Accelerating = bits[6];
			ConstantVelocity = bits[5];
			Decelerating = bits[4];
			Stopped = bits[3];
			ProgramRunning = bits[2];
			PositiveSwitchActivated = bits[1];
			NegativeSwitchActivated = bits[0];
		}

		public override string ToString() {
			return "Stage Status: " +
				"\n - Error: " + (ErrorHasOccured ? "One or more errors have occurred. Use ERR? Or CER to clear." : "No Errors have occurred.") +
				"\n - Accel: " + (Accelerating ? "Currently" : "Not") + " in Acceleration phase of motion." +
				"\n - Vel: " + (ConstantVelocity ? "Currently" : "Not") + " in Constant Velocity phase of motion." +
				"\n - Decel: " + (Decelerating ? "Currently" : "Not") + " in Deceleration phase of motion." +
				"\n - Stopped: " + (Stopped ? "Stage has stopped. (In Closed Loop Stage, is in the deadband)" : "Stage is moving. (In Closed Loop, Stage is out of deadband)") +
				"\n - Program: " + (ProgramRunning ? "A" : "No") + " program is currently running" +
				"\n - Pos Switch: Positive Switch is " + (PositiveSwitchActivated ? "" : "not") + "Activated" +
				"\n - Neg switch: Negative Switch is " + (NegativeSwitchActivated ? "" : "not") + " Activated";
		}
	}

}
