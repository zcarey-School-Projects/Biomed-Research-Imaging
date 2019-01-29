using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage.Commands {

	/// <summary>Stops all motion on the specified axis.</summary>
	public class StopMotion : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => true;

		public override bool CanReadDuringMotion => false;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => false;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => true;

		public override bool ExpectResponse { get => false; protected set => throw new InvalidOperationException("You can't read this command."); } //TODO make string constants for these in base class.

		public override object ParseResponse(string response) {
			throw new InvalidOperationException(); //TODO use this exception instead
		}

		/// <summary>Stops motion on the specified axis (1 to 99).</summary>
		public StopMotion(byte axis) {
			Command = axis + "STP";
		}

		/// <summary>Stops motion on all axes.</summary>
		public StopMotion() : this(0) {

		}
	}

}
