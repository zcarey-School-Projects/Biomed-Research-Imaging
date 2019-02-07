using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage {
	public abstract class IStageCommand {

		/// <summary>A 3-char long command, may also add a '?' for reading. </summary>
		public abstract string Command { get; protected set; }

		public abstract bool CanSetDuringMotion { get; }
		public abstract bool CanReadDuringMotion { get; }
		public abstract bool CanSetRealTime { get; }
		public abstract bool CanReadRealTime { get; }
		public abstract bool CanProgram { get; }
		public abstract bool CanSetGlobal { get; }

		public abstract bool ExpectResponse { get; protected set; }

		public abstract object ParseResponse(string response);

		/// <exception cref="InvalidOperationException">Throws exception with message "This command is write-only and can't be set to read."</exception>
		protected void ThrowWriteOnlyException() { throw new InvalidOperationException("This command is write-only and can't be set to read."); }

		/// <exception cref="InvalidOperationException">"This command is read-only and can't be set to write."</exception>
		protected void ThrowReadOnlyException() { throw new InvalidOperationException("This command is read-only and can't be set to write."); }

	}
}
