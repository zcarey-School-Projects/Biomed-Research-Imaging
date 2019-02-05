using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>Sets or reads the feedback mode for a specified axis. Return type for reading is 'StageFeedbackMode'.</summary>
	public class FeedbackMode : IStageCommand {

		public override string Command { get; protected set; }

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => true;

		public override bool CanReadRealTime => true;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => false;

		public override bool ExpectResponse { get; protected set; } = false;

		public override object ParseResponse(string response) {
			if (response.StartsWith("#")) {
				byte value;
				if (byte.TryParse(response.Substring(1), out value)) {
					if (Enum.IsDefined(typeof(StageFeedbackMode), value)) {
						return (StageFeedbackMode)value;
					}
				}
			}

			return null;
		}

		/// <summary>Sets the feesback mode of an axis (1 to 99) to the specified type.</summary>
		public FeedbackMode(byte axis, StageFeedbackMode mode) {
			Command = axis + "FBK" + (byte)mode;
		}

		/// <summary>Reads the feedback mode for an axis (1 to 99) as a 'StageFeedbackMode' type.
		/// NOTE: The bool 'read' parameter does nothing but serve to specify that it is a read operation.</summary>
		public FeedbackMode(byte axis, bool read) {
			ExpectResponse = true;
			Command = axis + "FBK?";
		}
	}

	public enum StageFeedbackMode : byte {
		OpenLoop = 0,
		OpenLoopWithCorrection = 1,
		OpenLoopMovementWithClosedLoopDeceleration = 2,
		ClosedLoop = 3
	}

}
