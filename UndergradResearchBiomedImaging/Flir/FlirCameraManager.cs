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

namespace UndergradResearchBiomedImaging.Flir {

	public class FlirCameraManager : IDisposable{

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
			foreach(IManagedCamera camera in cameras) {
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

		public CameraInfo GetCameraInformation(int index) {
			if (index < 0 || index >= cameras.Count) return null;
			return new CameraInfo(cameras[index]);
		}

		public FlirCamera OpenCamera(int index) {
			if (index < 0 || index >= cameras.Count) return null;
			return new FlirCamera(cameras[index]);
		}

	}

	public class CameraInfo {

		public string VendorName { get; private set; } = "N/A";
		public string DeviceModel { get; private set; } = "N/A";

		public DeviceInformation DeviceInformation { get; private set; } = new DeviceInformation();

		public CameraInfo(IManagedCamera camera) {
			try {
				INodeMap node = camera.GetTLDeviceNodeMap();
				VendorName = readVendor(node);
				DeviceModel = readDeviceModel(node);
				DeviceInformation = new DeviceInformation(node);
			}catch(SpinnakerException ex) {
				Console.WriteLine("Error: " + ex.Message);
			}
		}

		private static string readVendor(INodeMap node) {
			IString vendor = node.GetNode<IString>("DeviceVendorName");
			if (vendor != null && vendor.IsReadable) return vendor.Value;
			return "N/A";
		}

		private static string readDeviceModel(INodeMap node) {
			IString model = node.GetNode<IString>("DeviceModelName");
			if (model != null && model.IsReadable) return model.Value;
			return "N/A";
		}

	}

	public class DeviceInformation : IEnumerable<InfoNode> {

		private List<InfoNode> info = new List<InfoNode>();

		public DeviceInformation() { }

		public DeviceInformation(INodeMap node) {
			try {
				ICategory category = node.GetNode<ICategory>("DeviceInformation");
				if (category != null && category.IsReadable) {
					foreach (INode child in category.Children) {
						info.Add(new InfoNode(child));
					}
				}//Otherwise, device info not available
			} catch (SpinnakerException ex) {
				Console.WriteLine("Error: " + ex.Message);
			}
		}

		public IEnumerator<InfoNode> GetEnumerator() {
			return info.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return info.GetEnumerator();
		}

	}

	public class InfoNode {
		public string DisplayName { get; private set; }
		public string Name { get; private set; }
		public string Value { get; private set; }
		public string Description { get; private set; }

		public InfoNode(INode source) {
			DisplayName = source.DisplayName;
			Name = source.Name;
			Value = (source.IsReadable ? source.ToString() : "N/A");
			Description = source.Description;
		}
	}

}
