using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.MotorizedStage {
	public class StageError {

		public byte ID { get; private set; }

		public string Name { get; private set; }

		private ShortExplanationType shortDescrip;
		public string ShortDescription {
			get {
				switch (shortDescrip) {
					case ShortExplanationType.SillyZack: return "Apparently, Zack can't program. Let him know of this issue.";
					case ShortExplanationType.Runtime: return "An error occured that only happens under certain conditions.";
					case ShortExplanationType.Hardware: return "Hardware errors usually indicate either hardware malfunctions, or software variables need to be changed.";
					case ShortExplanationType.Unknown:
					default: return "An unknown error has occured.";
				}
			}
		}

		public string Description { get; private set; }

		private StageError(StageError copy) {
			this.ID = copy.ID;
			this.Name = copy.Name;
			this.shortDescrip = copy.shortDescrip;
			this.Description = copy.Description;
		}

		private StageError(byte id, string name, ShortExplanationType shortDescription, string descrip) {
			this.ID = id;
			this.Name = name;
			this.shortDescrip = shortDescription;
			this.Description = descrip;
		}

		private enum ShortExplanationType {
			Unknown,
			SillyZack,
			Runtime,
			Hardware
		}

		private static Dictionary<byte, StageError> AllErrors = new Dictionary<byte, StageError>();

		public static StageError GetError(byte id) {
			return AllErrors[id];
		}

		private static void addError(StageError error) {
			if (AllErrors.ContainsKey(error.ID)) throw new ArgumentException("Two errors can't contain the same ID! " + error.Name + ", " + AllErrors[error.ID].Name);
			AllErrors.Add(error.ID, error);
		}

		static StageError() {
			addError(new StageError(10, "Receive Buffer Overrun", ShortExplanationType.Runtime, "The Receive Buffer has reached or exceeded maximum capacity."));
			addError(new StageError(11, "Motor Disabled", ShortExplanationType.SillyZack, "The command that triggered this error was trying to move the servo while it was disabled."));
			addError(new StageError(12, "No Encoder Detected", ShortExplanationType.Hardware, "The command that triggered this error was trying to access encoder data when no encoder was attached."));
			addError(new StageError(13, "Index Not Found", ShortExplanationType.Hardware, "The controller moved across the full range of motion and did not find an index."));
			addError(new StageError(14, "Home Requires Encoder", ShortExplanationType.Hardware, "The HOM command requires an encoder signal."));
			addError(new StageError(15, "Move Limit Requires Encoder", ShortExplanationType.Hardware, "The MLN and MLP commands require an encoder signal."));
			addError(new StageError(20, "Command is Read Only", ShortExplanationType.SillyZack, "The command that triggered this error only supports read operations.The command must be followed by a question mark to be accepted.Ex: XXX?"));
			addError(new StageError(21, "One Read Operation PerLine", ShortExplanationType.SillyZack, "Multiple read operations on the same command line. Only one read operation is allowed per line, even if addressed to separate axes."));
			addError(new StageError(22, "Too Many Commands On Line", ShortExplanationType.SillyZack, "The maximum number of allowed commands per command line has been exceeded. No more than 8 commands are allowed on a single command line."));
			addError(new StageError(23, "Line Character Limit Exceeded", ShortExplanationType.SillyZack, "The maximum number of characters per command line has been exceeded.Each line has an 80 character limit."));
			addError(new StageError(24, "Missing Axis Number", ShortExplanationType.SillyZack, "The controller could not find an axis number or the beginning of an instruction.Check the beginning of the command for erroneous characters."));
			addError(new StageError(25, "Malformed Command", ShortExplanationType.SillyZack, "The controller could not find a 3-letter instruction in the input. Check to ensure that each instruction in the line has exactly 3 letters referring to a command."));
			addError(new StageError(26, "Invalid Command", ShortExplanationType.SillyZack, "The 3-letter instruction entered is not a valid command. Ensure that the 3-letter instruction is a recognizable command."));
			addError(new StageError(27, "Global Read Operation Request", ShortExplanationType.SillyZack, "A read request for a command was entered without an axis number. A read request cannot be used in a global context."));
			addError(new StageError(28, "Invalid Parameter Type", ShortExplanationType.SillyZack, "1. The parameter entered does not correspond to the type of number that the instruction requires.For example, the command may expect an integer value, therefore sending a floating point value will trigger this error.\n2.The allowable precision for a parameter has been exceeded.For example, velocity can be specified with a precision of 0.001 mm / sec. If a more precise velocity value of 0.0001 mm / sec is entered, this error will be triggered. Refer to the command pages for the type of parameter that each command expects."));
			addError(new StageError(29, "Invalid Character in Parameter", ShortExplanationType.SillyZack, "There is an alpha character in a parameter that should be a numeric character."));
			addError(new StageError(30, "Command Cannot Be Used In Global Context", ShortExplanationType.SillyZack, "The command entered must be addressed to a specific axis number. Not all commands can be used in a global context. Check the specific command page or the table of commands for more info."));
			addError(new StageError(31, "Parameter Out Of Bounds", ShortExplanationType.SillyZack, "The parameter is out of bounds. The current state of the controller will not allow this parameter to be used. Check the command page for more information."));
			addError(new StageError(32, "Incorrect Jog Velocity Request", ShortExplanationType.SillyZack, "The jog velocity can only be changed during motion by using a new JOG command. If the VEL command is used to change the velocity, this error will be triggered. The VEL command can only be used to change velocity during motion initiated by the move commands[MVR, MVA, MSR, MSA]."));
			addError(new StageError(33, "Not In Jog Mode", ShortExplanationType.SillyZack, "Sending a JOG command during motion initiated by a move command will trigger this error. To initiate Jog Mode, the controller should be at stand-still.To change velocity during a move, use the VEL command."));
			addError(new StageError(34, "Trace Already In Progress", ShortExplanationType.SillyZack, "This error is triggered when a new trace command is received after a trace is already in progress. Trace settings may be modified only if the trace hasn’t started recording data. Otherwise, wait until the trace has finished before modifying the trace settings."));
			addError(new StageError(35, "Trace Did Not Complete", ShortExplanationType.Runtime, "An error occurred while recording trace data. Try the operation again."));
			addError(new StageError(36, "Command Cannot Be Executed During Motion", ShortExplanationType.SillyZack, "Only certain commands can be executed when motion is in progress. Check the command pages for information on individual commands."));
			addError(new StageError(37, "Move Outside Soft Limits", ShortExplanationType.SillyZack, "If a requested move will take the controller outside of the preset travel limits, then the command will not be executed."));
			addError(new StageError(38, "Read Not Available For This Command", ShortExplanationType.SillyZack, "This error is triggered by a read request from a command that does not support a read operation."));
			addError(new StageError(39, "Program Number Out of Range", ShortExplanationType.SillyZack, "The number entered for the program number was either less than 1 or greater than 16."));
			addError(new StageError(40, "Program Size Limit Exceeded", ShortExplanationType.Runtime, "The program has exceeded the character limit of 4 Kb."));
			addError(new StageError(41, "Program failed to Record", ShortExplanationType.Runtime, "Error in recording program. Erase program and try operation again."));
			addError(new StageError(42, "End Command Must Be on its Own Line", ShortExplanationType.SillyZack, "The End command used to end a program must be on a separate line from all other instructions."));
			addError(new StageError(43, "Failed to Read Program", ShortExplanationType.Runtime, "An error occurred while trying to read a program. Try the Operation again."));
			addError(new StageError(44, "Command Only Valid Within Program", ShortExplanationType.SillyZack, "The command that triggered this error is only suitable for use within a program."));
			addError(new StageError(45, "Program Already Exists", ShortExplanationType.Runtime, "A program already exists for the indicated program parameter. The program must be erased with the ERA command before being written again."));
			addError(new StageError(46, "Program Doesn’t Exist", ShortExplanationType.SillyZack, "The indicated program does not exist. This error can occur when you try to execute a program number that has not had a program assigned to it."));
			addError(new StageError(47, "Read Operations Not Allowed Inside Program", ShortExplanationType.SillyZack, "Read Operations are not permitted in programs."));
			addError(new StageError(48, "Command Not Allowed While Program in Progress", ShortExplanationType.SillyZack, "The command that triggered this error was given while a program was executing."));
			addError(new StageError(50, "Limit Activated", ShortExplanationType.Hardware, "Motion in the direction of the activated limit switch is disallowed if limit switches are enabled."));
			addError(new StageError(51, "End of Travel Limit", ShortExplanationType.Hardware, "The requested move will take the controller outside of its valid travel range, therefore the move is disallowed."));
			addError(new StageError(52, "Home In Progress", ShortExplanationType.SillyZack, "A Home or a Move To Limit Procedure is in progress. Motion commands are disallowed during this time. A STP or EST command can be used to terminate the Home, and then a motion command can be sent."));
			addError(new StageError(53, "IO Function Already In Use", ShortExplanationType.Hardware, "The I/O Function in question is already assigned to another I/O pin. Some Functions can only be assigned to one pin at a time. See the documentation for each function for more details."));
			addError(new StageError(54, "Invalid Resolution", ShortExplanationType.Hardware, "The parameters entered for Gear Ratio, Lead-Screw Pitch, and Full Steps Per Revolution result in a resolution that cannot be handled by the controller."));
			addError(new StageError(55, "Limits Are Not Configured Properly", ShortExplanationType.Hardware, "Both Limit Switches are active, so motion is disallowed in both directions. Most likely the LPL(Limit Polarity command) setting should be switched."));
			addError(new StageError(80, "Command Not Available in this Version", ShortExplanationType.Hardware, "The command entered is not supported in this version of the firmware."));
			addError(new StageError(81, "Analog Encoder Not Available In this Version", ShortExplanationType.Hardware, "The current version of firmware installed does not support Analog Encoders."));
		}

	}
}
