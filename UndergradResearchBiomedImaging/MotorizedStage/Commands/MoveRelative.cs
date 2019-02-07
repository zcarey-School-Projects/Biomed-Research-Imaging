using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Moves the stage relative to its current position. If outside of soft limits, command is ignored. </summary>
	public class MoveRelative : IStageCommand {

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

		/// <summary>Moves all axes toe specified distance.
		/// Distance is (+-)0.000001 to 999.999999 mm.</summary>
		public MoveRelative(decimal distance) : this(0, distance){ //TODO range checks
			
		}

		/// <summary>Moves the specified axis the specified distance.
		/// Axis is from (1 - 99) and distance is (+-)0.000001 to 999.999999 mm.</summary>
		public MoveRelative(byte axis, decimal distance) { //TODO range checks
			Command = axis + "MVR" + distance.ToString("N6");
		}
	}

}
