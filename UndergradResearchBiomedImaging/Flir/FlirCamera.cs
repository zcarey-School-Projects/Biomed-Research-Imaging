using Emgu.CV;
using Emgu.CV.Structure;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace UndergradResearchBiomedImaging.Flir {
	public class FlirCamera : IDisposable{

		private IManagedCamera camera;
		public FlirProperties Properties { get; private set; }
		private bool initialized = false;
		private bool streaming = false;

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
			streaming = false;
			initialized = false;
			camera.Dispose();
		}

		public void StartStream() {
			camera.BeginAcquisition();
			streaming = true;
		}

		public void EndStream() {
			streaming = false;
			camera.EndAcquisition();
		}

		public bool GetNextImage(out Bitmap image) {
			image = null;
			using (IManagedImage rawImage = camera.GetNextImage()) {
				try {
					if (rawImage.IsIncomplete) return false;
					using (IManagedImage deepCopy = rawImage.Convert(PixelFormatEnums.BGR8)) {
						image = deepCopy.bitmap;
						return true;
					}
				} catch (SpinnakerException ex) {
					Console.WriteLine("Error: " + ex.Message);
					return false;
				}
			}
		}

	}

}
