using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage.Commands {

	/// <summary>Sets or gets the positive software limit of an axis.
	/// The software limit will prevent the axis from moving past that point.</summary>
	public class SoftLimitPositive : IStageCommand {
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

		/// <summary>Sets the specified axis positive soft limit to the specified value.
		/// Axis from (1 to 99), Position from (Negative Soft Limit to 999.999999)</summary>
		public SoftLimitPositive(byte axis, decimal position) {
			Command = axis + "TLP" + position.ToString("N6");
		}

		/// <summary> Reads the positive soft limit of the specified axis (1 - 99).
		/// NOTE: read bool does not affect anything, simply serves as a way to select reading.</summary>
		public SoftLimitPositive(byte axis, bool read) {
			ExpectResponse = true;
			Command = axis + "TLP?";
		}

		/// <summary>Sets all axes positive soft limit to the specified value (Negative Soft Limit to 999.999999).</summary>
		public SoftLimitPositive(decimal position) {
			Command = "0TLP" + position.ToString("N6");
		}

		/// <summary>Sets the current position of the specified axis (1 to 99) as its positive soft limit.</summary>
		public SoftLimitPositive(byte axis) {
			Command = axis + "TLP";
		}
	}

}
