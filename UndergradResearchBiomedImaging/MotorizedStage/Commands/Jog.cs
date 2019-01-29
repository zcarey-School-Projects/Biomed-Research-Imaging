using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage.Commands {

	/// <summary>Continuously moves (or stops) the stage in a direction until stopped.</summary>
	public class Jog : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => true;

		public override bool CanReadDuringMotion => false;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => false;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => true;

		public override bool ExpectResponse { get; protected set; } = false;

		public override object ParseResponse(string response) {
			throw new NotImplementedException();
		}

		/// <summary>Stops any jogging on the specified axis (1 to 99).</summary>
		public Jog(byte axis) {
			Command = axis + "JOG0";
		}

		/// <summary>Continuously move an axis (1 to 99) in a direction until stopped. 
		/// Moves at a given percentage of maximum velocity (-100.000% yo 100.000%), or 0 to stop.</summary>
		public Jog(byte axis, decimal percentMaxVelocity) {
			Command = axis + "JOG" + percentMaxVelocity.ToString("N3");
		}
	}

}
