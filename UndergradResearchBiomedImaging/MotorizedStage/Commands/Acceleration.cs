using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage.Commands {
	/// <summary>Sets and reads the acceleration. Return type is 'decimal'</summary>
	public class Acceleration : IStageCommand {

		public static decimal MinimumValue { get; } = 0.001M;
		public static decimal MaximumValue { get; } = 500.0M;

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => true;

		public override bool CanProgram => true;

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

		/// <summary>Sets the acceleration of an axis (1 to 99) to the specified value (000.001 to AMX(500.000 mm/s2)).</summary>
		public Acceleration(byte axis, decimal acceleration) {
			Command = axis + "ACC" + acceleration.ToString("N6");
		}

		/// <summary>Reads the acceleration of an axis (1 to 99), of type 'decimal'.
		/// NOTE: The bool does nothing but specify that this is a read operation, and its value has no effect.</summary>
		public Acceleration(byte axis, bool read) {
			ExpectResponse = true;
			Command = axis + "ACC?";
		}

		/// <summary>Sets the acceleration of all axes to the specified value (000.001 to AMX(500.000 mm/s2)).</summary>
		public Acceleration(decimal acceleration) : this(0, acceleration) { //TODO other commands like this

		}

	}
}
