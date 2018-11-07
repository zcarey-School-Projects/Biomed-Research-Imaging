using RobotHelpers.InputHandling;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging {

	public class FlirCameraManager : IDisposable {

		private ManagedSystem spinnaker;
		private List<IManagedCamera> cameras = new List<IManagedCamera>();

		public FlirCameraManager() {
			spinnaker = new ManagedSystem();
		}

		~FlirCameraManager() {
			Dispose();
		}

		public void Dispose() {
			if (cameras == null) return;
			foreach (IManagedCamera camera in cameras) {
				camera.Dispose();
			}
			cameras = null;
			if (spinnaker != null) spinnaker.Dispose();
		}

		public string GetSpinnakerLibraryVersion() {
			LibraryVersion version = spinnaker.GetLibraryVersion();
			return version.major + "." + version.minor + "." + version.type + "." + version.build;
		}

		public int DetectCameras() {
			spinnaker.UpdateCameras();
			cameras = spinnaker.GetCameras();
			if (cameras == null) cameras = new List<IManagedCamera>();
			Console.WriteLine("{0} Flir camera{1} detected.", cameras.Count, (cameras.Count > 1) ? "s were" : " was");
			return cameras.Count;
		}

		public int NumberOfAvailableCameras() {
			return cameras.Count;
		}

		public FlirCamera GetCamera(int index) {
			if (index < 0 || index >= cameras.Count) return null;
			return new FlirCamera(cameras[index]);
		}

	}
}
	
