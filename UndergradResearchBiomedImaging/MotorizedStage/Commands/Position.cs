using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage.Commands {

	/// <summary>Reads the current position of an axis.</summary>
	public class Position : IStageCommand {

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
				string[] args = response.Substring(1).Split(',');
				if (args.Length == 2) {
					decimal theory;
					decimal encoder;
					if (decimal.TryParse(args[0], out theory) && decimal.TryParse(args[1], out encoder)) {
						return new StagePosition(theory, encoder);
					}
				}
			}

			return null;
		}

		/// <summary>Reads the current position of the specified axis (1 to 99).</summary>
		/// <param name="axis"></param>
		public Position(byte axis) {
			Command = axis + "POS?";
		}
	}

	public struct StagePosition {
		public decimal Theoretical;
		public decimal Encoder;

		public StagePosition(decimal theory, decimal encoder) {
			Theoretical = theory;
			Encoder = encoder;
		}
	}

}
