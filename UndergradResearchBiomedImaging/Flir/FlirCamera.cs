using Emgu.CV;
using Emgu.CV.Structure;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearch.Flir {
	public class FlirCamera : IDisposable {

		private IManagedCamera camera;
		public FlirProperties Properties { get; private set; }
		private bool initialized = false;
		public bool IsStreaming { get => camera.IsStreaming(); }

		public FlirCamera(FlirCameraManager manager, IManagedCamera cam) {
			this.camera = cam;
			this.Properties = new FlirProperties(manager.GetSpinnakerLibraryVersion(), cam);
			camera.Init();
			if (camera.IsInitialized()) {
				initialized = true;
				Console.WriteLine("Camera initialized: " + camera.DeviceModelName);
			} else {
				Console.WriteLine("Camera could not be initialized.");
			}
		}

		public void Dispose() {
			initialized = false;
			camera.Dispose();
		}

		public bool BeginAcquisition() {
			INodeMap node = camera.GetNodeMap();

			// Set acquisition mode to continuous
			if (!Properties.AcquisitionMode.TrySetValue(AcquisitionModeEnums.Continuous)) { 
				return false;
			}
			Console.WriteLine("Acquisition mode set to continuous...");

			//Set camera to color mode
			if (!Properties.PixelFormat.TrySetValue(PixelFormatEnums.RGB8)) {
				return false;
			}
			Console.WriteLine("Pixel format set to RGB.");

			camera.BeginAcquisition();
			return true;
		}

		public void EndAcquisition() {
			try {
				if (initialized && camera.IsStreaming()) {
					camera.EndAcquisition();
				}
			} catch (ObjectDisposedException) {
				Console.WriteLine("Camera was already disposed.");
			}
		}

		public bool GrabImage(out Image<Bgr, byte> GrabbedImage) {
			GrabbedImage = null;
			if (!initialized || !camera.IsStreaming()) return false;
			using (IManagedImage rawImage = camera.GetNextImage()) {
				try {
					if (rawImage.IsIncomplete) throw new SpinnakerException("Image incomplete with image status " + rawImage.ImageStatus);
					using (IManagedImage deepCopy = rawImage.Convert(PixelFormatEnums.BGR8)) {
						Bitmap img = deepCopy.bitmap;
						if (img == null) throw new SpinnakerException("Image bitmap was null.");
						GrabbedImage = new Image<Bgr, byte>(img);
						return true;
					}
				} catch (SpinnakerException ex) {
					Console.WriteLine("Error: " + ex.Message);
					EndAcquisition();
					return false;
				}
			}
		}

	}
}
