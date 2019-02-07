using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Stops all motion on the specified axis.</summary>
	public class StopMotion : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => true;

		public override bool CanReadDuringMotion => false;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => false;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => true;

		public override bool ExpectResponse { get => false; protected set => base.ThrowWriteOnlyException(); }

		public override object ParseResponse(string response) {
			base.ThrowWriteOnlyException();
			return null;
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
