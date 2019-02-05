using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Sets the velocity of an axis. Must be less than the maximum velocity (VMX).</summary>
	public class TravelVelocity : IStageCommand {

		public static decimal MinimumValue { get; } = 0.001M;
		public static decimal MaximumValue { get; } = 999.999M;

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => true;

		public override bool CanReadDuringMotion => false;

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

		/// <summary>Sets the velocity for the specified axis (1 to 99) to the maximum velocity (VMX).</summary>
		public TravelVelocity(byte axis) {
			Command = axis + "VEL0";
		}

		/// <summary>Sets the axis (1 to 99) velocity (000.001 to VMX(999.999 mm/s)) to the specified value.</summary>
		public TravelVelocity(byte axis, decimal velocity) {
			Command = axis + "VEL" + velocity.ToString("N3");
		}

		/// <summary>Reads the velocity (type 'decimal') from the specified axis (1 to 99).</summary>
		public TravelVelocity(byte axis, bool read) {
			ExpectResponse = true;
			Command = axis + "VEL?";
		}

		/// <summary>Sets the velocity of all axes to the maximum velocity (VMX).</summary>
		public TravelVelocity() : this((byte)0) {

		}

		/// <summary>Sets the velocity of all axes to the specified velocity (000.001 to VMX(999.999 mm/s)).</summary>
		public TravelVelocity(decimal velocity) : this(0, velocity) {

		}
	}

}
