using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Zeros the stage for the specified axis at its current position.</summary>
	public class ZeroPosition : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => false;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => false;

		public override bool CanProgram => true;

		public override bool CanSetGlobal => true;

		public override bool ExpectResponse { get => false; protected set => base.ThrowWriteOnlyException(); }

		public override object ParseResponse(string response) {
			base.ThrowWriteOnlyException();
			return null;
		}

		/// <summary>Axis is from (1 to 99)</summary>
		public ZeroPosition(byte axis) {
			Command = axis + "ZRO";
		}
	}

}
