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

namespace UndergradResearchBiomedImaging.Flir {
	public class FlirCamera : IDisposable {

		private IManagedCamera camera;
		public FlirProperties Properties { get; private set; }
		private bool initialized = false;
		public bool IsStreaming { get => camera.IsStreaming(); }

		public FlirCamera(IManagedCamera cam) {
			this.camera = cam;
			this.Properties = new FlirProperties(cam);
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

		//TODO simplify
		public void BeginAcquisition() {
			INodeMap node = camera.GetNodeMap();

			// Set acquisition mode to continuous
			/*IEnum iAcquisitionMode = node.GetNode<IEnum>("AcquisitionMode");
			if (iAcquisitionMode == null || !iAcquisitionMode.IsWritable) {
				throw new SpinnakerException("Unable to set acquisition mode to continuous(node retrieval).");
			}

			IEnumEntry iAcquisitionModeContinuous = iAcquisitionMode.GetEntryByName("Continuous");
			if (iAcquisitionModeContinuous == null || !iAcquisitionMode.IsReadable) {
				throw new SpinnakerException("Unable to set acquisition mode to continuous(entry retrieval).");
			}

			iAcquisitionMode.Value = iAcquisitionModeContinuous.Value;
			*/
			if (!Properties.AcquisitionMode.TrySetValue(AcquisitionModeEnums.Continuous)) {
				throw new SpinnakerException("Unable to set acquisition mode to continuous.");
			}
			Console.WriteLine("Acquisition mode set to continuous...");

			//Set camera to color mode
			/*IEnum pixelFormat = node.GetNode<IEnum>("PixelFormat");

			if (pixelFormat != null && pixelFormat.IsWritable) {
				IEnumEntry pixelFormatBgr8 = pixelFormat.GetEntryByName("RGB8");
				if (pixelFormatBgr8 != null && pixelFormatBgr8.IsReadable) {
					pixelFormat.Value = pixelFormatBgr8.Value;
					Console.WriteLine("Pixel format set to {0}...", pixelFormat.Value.String);
				} else {
					Console.WriteLine("Pixel format '{0}' is not available.", ((pixelFormatBgr8 != null) ? pixelFormatBgr8.ToString() : "???"));
				}
			} else {
				Console.WriteLine("Pixel format is not available.");
			}*/
			if (!Properties.PixelFormat.TrySetValue(PixelFormatEnums.RGB8)) {
				throw new SpinnakerException("Could not set PixelFormat to RGB");
			} else {
				Console.WriteLine("Pixel format set to RGB.");
			}

			camera.BeginAcquisition();
		}

		public void ResumeAcquisition() {
		//	if(camera.IsStreaming()) camera.BeginAcquisition();
		}

		public void EndAcquisition() {
			if(initialized && camera.IsStreaming()) camera.EndAcquisition();
		}

		public Image<Bgr, byte> GrabImage() {
			if (!initialized || !camera.IsStreaming()) return null;
			using (IManagedImage rawImage = camera.GetNextImage()) {
				try {
					if (rawImage.IsIncomplete) throw new SpinnakerException("Image incomplete with image status " + rawImage.ImageStatus);
					using (IManagedImage deepCopy = rawImage.Convert(PixelFormatEnums.BGR8)) {
						Bitmap img = deepCopy.bitmap;
						if (img == null) return null;
						return new Image<Bgr, byte>(img);
					}
				} catch (SpinnakerException ex) {
					Console.WriteLine("Error: " + ex.Message);
					return null;
				}
			}
		}

	}
}
