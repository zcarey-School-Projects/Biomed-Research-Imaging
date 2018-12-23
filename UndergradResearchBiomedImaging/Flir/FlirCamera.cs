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

		public Image<Bgr, byte> GetNextImage() {
			using (IManagedImage rawImage = camera.GetNextImage()) {
				try {
					if (rawImage.IsIncomplete) return null;
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
