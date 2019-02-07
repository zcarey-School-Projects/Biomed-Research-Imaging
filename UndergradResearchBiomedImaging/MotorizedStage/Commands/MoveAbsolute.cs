using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Moves an axis to an absolute position. Moves outside soft limits are ignored.</summary>
	public class MoveAbsolute : IStageCommand {

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

		/// <summary>Moves the axis (1 to 99) to the specified position (-999.999999 to 999.999999 mm).
		/// If the position is outside of the soft limits, the command will be ignored.</summary>
		public MoveAbsolute(byte axis, decimal position) {
			Command = axis + "MVA" + position.ToString("N6");
		}

		/// <summary>Moves all axes to the specified position (-999.999999 to 999.999999 mm).
		/// If the position is outside of the soft limits, the command will be ignored.</summary>
		public MoveAbsolute(decimal position) : this(0, position){
			
		}
	}

}
