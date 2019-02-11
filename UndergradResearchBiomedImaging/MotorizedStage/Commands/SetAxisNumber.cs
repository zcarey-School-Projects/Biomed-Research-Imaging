using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Sets the acceleration and deceleration for jogging on an axis. Must be less than Max Acceleration (AMX).</summary>
	public class SetAxisNumber : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => true;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => true;

		public override bool ExpectResponse { get => false; protected set => base.ThrowWriteOnlyException(); }

		public override object ParseResponse(string response) {
			/*	if (response.StartsWith("#")) {
					byte value;
					if (byte.TryParse(response.Substring(1), out value)) {
						return value;
					}
				}
				*/
			base.ThrowWriteOnlyException();
			return null;
		}

		/// <summary>Sets the axis (1 to 99) to the new specified axis (1 to 99)</summary>
		public SetAxisNumber(byte axis, byte newAxis) {
			Command = axis + "ANR" + newAxis;
		}

		/// <summary>Sets the axis numbers to be generated automatically.</summary>
		public SetAxisNumber() : this(0, 0) {

		}
		/*
		/// <summary>Reads the the jog acceleration (type 'decimal') from the specified axis.</summary>
		public SetAxisNumber(byte axis, bool read) { //Do we need this in commands?
			ExpectResponse = true;
			Command = axis + "JAC?";
		}*/
	}

}
