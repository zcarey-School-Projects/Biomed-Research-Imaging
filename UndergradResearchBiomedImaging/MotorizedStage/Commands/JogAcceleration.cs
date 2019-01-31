using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage.Commands {

	/// <summary>Sets the acceleration and deceleration for jogging on an axis. Must be less than Max Acceleration (AMX).</summary>
	public class JogAcceleration : IStageCommand {

		public static decimal MinimumValue { get; } = 0.001M;
		public static decimal MaximumValue { get; } = 500.0M;

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => true;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => true;

		public override bool ExpectResponse { get; protected set; } = false;

		public override object ParseResponse(string response) {
			if (response.StartsWith("#")) {
				decimal value;
				if (decimal.TryParse(response.Substring(1), out value)) {
					return value;
				}
			}

			return null;
		}

		//TODO check other commands decimal points, and note that in documentation, as well as AMX
		/// <summary>Sets the axis (1 to 99) jog acceleration (.001 to AMX(500.000 mm/s^2)) to the specified value</summary>
		public JogAcceleration(byte axis, decimal acceleration) {
			Command = axis + "JAC" + acceleration.ToString("N3");
		}

		/// <summary>Sets the jog acceleration (.001 to AMX(500.000 mm/s^2)) of all axes.</summary>
		/// <param name="acceleration"></param>
		public JogAcceleration(decimal acceleration) : this(0, acceleration) {

		}

		/// <summary>Reads the the jog acceleration (type 'decimal') from the specified axis.</summary>
		public JogAcceleration(byte axis, bool read) { //Do we need this in commands?
			ExpectResponse = true;
			Command = axis + "JAC?";
		}
	}

}
