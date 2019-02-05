using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Reads the firmware version of an axis.</summary>
	public class FirmwareVersion : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => false;

		public override bool CanReadRealTime => true;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => false;

		public override bool ExpectResponse { get => true; protected set => throw new InvalidOperationException("This is a read-only command."); } //TODO do this with other commands.

		public override object ParseResponse(string response) {
			if (response.StartsWith("#MMC-200")) {
				return response.Substring(1);
			}

			return null;
		}

		/// <summary>Reads the firmware version of the specified axis (1 to 99). Return type of 'string'.</summary>
		public FirmwareVersion(byte axis) {
			Command = axis + "VER?";
		}
	}

}
