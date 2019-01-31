using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage.Commands {

	/// <summary>Sets or reads the deceleration value (slowing down) of an axis.</summary>
	public class Deceleration : IStageCommand {

		public static decimal MinimumValue { get; } = 0.001M;
		public static decimal MaximumValue { get; } = 500.000M;

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => false;

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

		/// <summary>Sets the deceleration value (000.001 to AMX(500.000 mm/s^2)) of the specified axis (1 to 99).</summary>
		public Deceleration(byte axis, decimal deceleration) {
			Command = axis + "DEC" + deceleration.ToString("N6");
		}

		/// <summary>Reads the deceleration (type 'decimal') of the specified axis (1 to 99).</summary>
		public Deceleration(byte axis, bool read) {
			ExpectResponse = true;
			Command = axis + "DEC?";
		}

		/// <summary>Sets the deceleration (000.001 to AMX(500.000 mm/s^2)) for all axes.</summary>
		public Deceleration(decimal deceleration) : this(0, deceleration) {

		}
	}

}
