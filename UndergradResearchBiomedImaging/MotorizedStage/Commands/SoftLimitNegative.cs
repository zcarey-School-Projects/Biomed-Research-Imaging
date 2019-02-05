using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {
	
	/// <summary>Gets or sets the negative software limit of an axis.
	/// The software limit will prevent the axis from moving past that point.</summary>
	public class SoftLimitNegative : IStageCommand {

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

		/// <summary>Sets the specified axis negative soft limit to the specified value.
		/// Axis from (1 to 99), Position from (-999.999999 to Positive Soft Limit)</summary>
		public SoftLimitNegative(byte axis, decimal position) {
			Command = axis + "TLN" + position.ToString("N6");
		}

		/// <summary> Reads the negative soft limit of the specified axis (1 - 99).
		/// NOTE: read bool does not affect anything, simply serves as a way to select reading.</summary>
		public SoftLimitNegative(byte axis, bool read) {
			ExpectResponse = true;
			Command = axis + "TLN?";
		}

		/// <summary>Sets all axes negative soft limit to the specified value (-999.999999 to Positive Soft Limit).</summary>
		public SoftLimitNegative(decimal position) {
			Command = "0TLN" + position.ToString("N6");
		}

		/// <summary>Sets the current position of the specified axis (1 to 99) as its negative soft limit.</summary>
		public SoftLimitNegative(byte axis) {
			Command = axis + "TLN";
		}
	}

}
