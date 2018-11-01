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
using UndergradResearchBiomedImaging.Flir;

namespace UndergradResearchBiomedImaging {
	public class FlirCamera : IDisposable{

		public FlirSettings Settings { get; private set; }

		private IManagedCamera camera;
		private bool initialized = false;
		private bool streaming = false;

		public FlirCamera(IManagedCamera cam) {
			this.camera = cam;
			Settings = new FlirSettings(this);
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

		public INodeMap GetNodeMap() {
			return camera.GetNodeMap();
		}
		
	}

}
