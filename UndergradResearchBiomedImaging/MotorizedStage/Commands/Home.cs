using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Finds the zero position of the stage (usually in the center). Buffers commands until finished.</summary>
	public class Home : IStageCommand {

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
				byte value;
				if (byte.TryParse(response.Substring(1), out value)) {
					if (value == 0) return false;
					else if (value == 1) return true;
				}
			}

			return null;
		}

		/// <summary>Causes all axes to return to home.</summary>
		public Home() {
			this.Command = "0HOM";
		}

		/// <summary>Will home the specified axis(1-99)</summary>
		public Home(byte axis) {
			this.Command = axis + "HOM";
		}

		/// <summary>If "read" is set to true, will read if the stage has been homed at least once since startup. Axis number (1-99).
		/// Returns true if it has been homed since startup, false otherwise.</summary>
		public Home(byte axis, bool read) {
			this.ExpectResponse = read;
			this.Command = axis + "HOM" + (read ? "?" : "");
		}
	}

}
