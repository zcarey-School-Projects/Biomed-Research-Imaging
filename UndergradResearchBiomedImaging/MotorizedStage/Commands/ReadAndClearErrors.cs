using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.MotorizedStage.Commands {

	/// <summary>This command is used to read and clear pending errors. Return type is 'StageError[]'</summary>
	public class ReadAndClearErrors : IStageCommand {

		public override bool CanSetDuringMotion => false;

		public override bool CanReadDuringMotion => true;

		public override bool CanSetRealTime => false;

		public override bool CanReadRealTime => true;

		public override bool CanProgram => false;

		public override bool CanSetGlobal => false;

		public override bool ExpectResponse { get; protected set; } = true;

		public override string Command { get; protected set; }

		public override object ParseResponse(string response) {
			//Errors are returned in ASCII in the following format:
			//#Error [Error#] - [CMD] - [Error Name]
			List<StageError> errors = new List<StageError>();

			string[] lines = response.Split('\n');
			foreach (string line in lines) {
				if (line.StartsWith("#Error ")) {
					string[] parts = line.Split('-');
					if (parts.Length < 1) {
						Console.WriteLine("FATAL ERROR: Not enough parameters in error message!: " + line);
						continue;
					}
					byte id;
					if (byte.TryParse(parts[0].Trim(' ').Substring("#Error ".Length), out id)) {
						StageError error = StageError.GetError(id);
						if (error != null) {
							errors.Add(error);
						} else {
							Console.WriteLine("FATAL ERROR: Could not find error ID!: " + id);
						}
					} else {
						Console.WriteLine("FATAL ERROR: Unable to parse error number: " + parts[1].Trim(' ') + " from '" + line + "'");
					}
				} else {
					Console.WriteLine("FATAL ERROR: Expected error message in wrong format!: " + line);
				}
			}

			return errors.ToArray();
		}

		/// <summary>Given an axis #(1-99), reads any pending errors.</summary>
		public ReadAndClearErrors(byte axis) {
			Command = axis + "ERR?";
		}
	}

}
