using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Stops the specified axis using the maximum allowed acceleration.</summary>
	public class EmergencyStop : IStageCommand {

		public override string Command { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

		public override bool CanSetDuringMotion => true;

		public override bool CanReadDuringMotion => false;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => false;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => true;

		public override bool ExpectResponse { get => false; protected set => throw new InvalidOperationException("Can't read."); }

		public override object ParseResponse(string response) {
			throw new InvalidOperationException();
		}

		/// <summary>Performs an eStop for the specified axis (1 to 99) at max acceleration (AMX).</summary>
		public EmergencyStop(byte axis) {
			Command = axis + "EST";
		}

		/// <summary>Performs an eStop for all axes at max acceleration (AMX).</summary>
		public EmergencyStop() : this(0) {

		}
	}

}
