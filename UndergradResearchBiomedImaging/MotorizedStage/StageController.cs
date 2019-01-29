using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.MotorizedStage {
	public class StageController {

		/*
		 * commands sent must be followed by [\n\r] or just [\r]
Receiving each line of data is followed by [\n] and final line ends in [\n\r]
		 */

		private SerialPort serial; //8 data bits, 1 stop bit, no parity, no handshake, baud 38400
		private volatile bool isHoming = false;


		public StageController() {
			serial = new SerialPort("None", 38400, Parity.None, 8, StopBits.One);
			serial.Handshake = Handshake.None;
			serial.NewLine = "\n\r";

			serial.ReadTimeout = 500;
			serial.WriteTimeout = 500;
		}

		public bool IsOpen() {
			return serial.IsOpen;
		}

		public void Close() {
			try {
				isHoming = false;
				serial.Close();
			} catch (IOException) {

			}
		}

		/// <summary>Internal method that simply sends a command, no checks.</summary>
		private bool sendCommand(IStageCommand command) { //TODO implement in other methods
			try {
				serial.WriteLine(command.Command);
				return true;
			} catch (Exception ex) {
				Console.WriteLine("Error sending message: " + ex.Message);
				return false;
			}
		}

		/// <summary>Internal method to read serial without checks.</summary>
		private bool readLine(out string response) { //TODO implement in other methods
			response = null;
			try {
				response = serial.ReadLine();
				return true;
			} catch (Exception ex) {
				Console.WriteLine("Error reading data: " + ex.Message);
				return false;
			}
		}

		/// <summary>Attempts to send a command and ignore any returned data.</summary>
		public bool TrySendCommand(IStageCommand command) {
			object temp;
			return TrySendCommand(command, out temp);
		}

		/// <summary>Attempts to send a command and parse its return data, if any.</summary>
		public bool TrySendCommand(IStageCommand command, out object response) {
			return TrySendCommand<object>(command, out response);
		}

		public bool TrySendCommand<T>(IStageCommand command, out T response) {
			lock (this) {
				response = default(T); //TODO can other method just use this, defaulting to object?
				if (!serial.IsOpen || isHoming) return false; //TODO makes checkes likes global axis
				if (!sendCommand(command)) return false;
				if (command.ExpectResponse) {
					string responseData = null;
					if (readLine(out responseData)) {
						object obj = command.ParseResponse(responseData);
						if ((obj != null) && (obj is T)) {
							response = (T)obj;
							return true;
						}
					}
				} else {
					return true;
				}

				return false;
			}
		}

		#region WaitForStatus
		public bool WaitForStop() {
			if (!serial.IsOpen || isHoming) return false;
			while (true) {
				IStageCommand command = new Commands.Status(1);
				Commands.StageStatus status;
				if (!TrySendCommand(command, out status)) return false; //Error reading status
				if (status.Stopped) return true;

				//Wait to check again.
				Thread.Sleep(100);
			}
		}//TODO "Fix axis errors" button, to reset the axis counting
		

		private bool waitForHomingStop() { //Must run when isHoming = true, but return false if port closes.
			if (!serial.IsOpen) return false;
			while (true) {
				//Read status
				IStageCommand statusCMD = new Commands.Status(1);
				if (!sendCommand(statusCMD)) return false;
				string response = null;
				if (!readLine(out response)) return false;
				object obj = statusCMD.ParseResponse(response);
				if ((obj == null) || !(obj is Commands.StageStatus)) return false;
				Commands.StageStatus status = (Commands.StageStatus)obj;
				if (status.Stopped) return true;

				//Wait to check status again.
				Thread.Sleep(100);
			}
		}
		#endregion

		/// <summary>Reads and displays any errors via Message boxes</summary>
		public bool DisplayErrors() {
			IStageCommand command = new Commands.ReadAndClearErrors(1);
			StageError[] errors;
			if (!TrySendCommand(command, out errors)) return false;
			foreach(StageError error in errors) {
				MessageBox.Show("ERROR: " + error.Name + "; " + error.ShortDescription);
			}

			return true;
		}

		#region Homing
		public HomingStatus FindHome() {
			lock (this) {
				if (!serial.IsOpen) return HomingStatus.Error;
				if (isHoming) return HomingStatus.InProgress;
				isHoming = true;
			}

			Thread homingThread = new Thread(() => {
				try {
					if (runHomeCommands()) {
						MessageBox.Show("Stage homed successfully.");
					} else {
						MessageBox.Show("Unable to home the stage.");
					}
				}catch(Exception e) {
					Console.WriteLine("\nFatal Error: " + e.Message);
					Console.WriteLine(e.StackTrace);
					Console.WriteLine();
					MessageBox.Show("A fatal error has occured while homing.");
				} finally {
					lock (this) {
						isHoming = false;
					}
				}
			});
			homingThread.Name = "Stage Homing Thread";
			homingThread.IsBackground = true;
			homingThread.Start();

			return HomingStatus.Initiated;
		}

		private bool runHomeCommands() {
			if (!sendCommand(new Commands.FeedbackMode(1, Commands.StageFeedbackMode.ClosedLoop))) return false;
			if (!sendCommand(new Commands.Home(1))) return false;
			if (!waitForHomingStop()) return false;
			IStageCommand readHome = new Commands.Home(1, true);
			if (!sendCommand(readHome)) return false;
			string response;
			if (!readLine(out response)) return false;
			object obj = readHome.ParseResponse(response);
			if (!(obj is bool) || ((bool)obj != true)) return false;
			if (!sendCommand(new Commands.MoveRelative(1, -0.77M))) return false;
			if (!waitForHomingStop()) return false;
			if (!sendCommand(new Commands.ZeroPosition(1))) return false;
			if (!sendCommand(new Commands.SoftLimitNegative(1, -5.25M))) return false;
			if (!sendCommand(new Commands.SoftLimitPositive(1, 5.25M))) return false;
			return true;
		}
		#endregion

		public bool TryAutoConnect() {
			lock (this) {
				Close(); //Start "fresh"

				Console.WriteLine("\nFinding connections...");
				string[] allPorts = SerialPort.GetPortNames();
				foreach (string portName in allPorts) {
					Console.Write("Connecting to '" + portName + "': ");
					serial.PortName = portName;
					try {
						serial.Open();
						if (serial.IsOpen) {
							Console.WriteLine("SUCCESS!. Attempting to read firmware version: ");
							int originalReadTimeout = serial.ReadTimeout;
							int originalWriteTimeout = serial.WriteTimeout;
							serial.ReadTimeout = 100;
							serial.WriteTimeout = 100;
							IStageCommand versionCommand = new Commands.FirmwareVersion(1);
							string version;
							if (TrySendCommand(versionCommand, out version)) { //Gurantees non-null
								if (version.ToUpper().StartsWith("MMC-200")) {
									Console.WriteLine("SUCCESS!: Version: {0}", version);
									DisplayErrors();
									return true;
								}
							}

							Console.WriteLine("FAILED - Does not appear to be a stage controller.");

							serial.ReadTimeout = originalReadTimeout;
							serial.WriteTimeout = originalWriteTimeout;
						} else {
							Console.WriteLine("FAILED - Serial port did not open.");
						}
						//If we reach here, we failed to open so just ensure the port is closed for the next available port
						Close();
					} catch (Exception ex) {
						Console.WriteLine("FAILED - " + ex.Message);
					}
				}
				Close(); //Ensure that the port is closed before we exit.
				Console.WriteLine("\n Could not find a stage controller.");
				return false;
			}
		}

	}

	public enum HomingStatus {
		Initiated,
		InProgress,
		Error
	}

}
