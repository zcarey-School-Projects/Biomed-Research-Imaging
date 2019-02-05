using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Sets or reads the maximum allowable acceleration.</summary>
	public class MaxAcceleration : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => false;

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

		/// <summary>Sets the max allowable acceleration (000.001 to 500.000) mm/s^2 for a specified axis (1 to 99).</summary>
		public MaxAcceleration(byte axis, decimal acceleration) {
			Command = axis + "AMX" + acceleration.ToString("N3");
		}

		/// Reads the max allowable acceleration (type 'decimal') for a specified axis (1 to 99).</summary>
		public MaxAcceleration(byte axis, bool read) {
			ExpectResponse = true;
			Command = axis + "AMX?";
		}

		/// <summary>Sets the max allowable acceleration (000.001 to 500.000) mm/s^2 for all axes.</summary>
		public MaxAcceleration(decimal acceleration) : this(0, acceleration) {

		}
	}

}
