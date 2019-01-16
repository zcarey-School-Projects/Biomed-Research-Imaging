using Emgu.CV;
using Emgu.CV.Structure;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.Flir {
	public class FlirCamera : IDisposable{

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

		public void StartStream() {
			if (!Properties.PixelFormat.TrySetValue(PixelFormatEnums.RGB8)) MessageBox.Show("Could not set camera to RGB.");
			camera.BeginAcquisition();
		}

		public void EndStream() {
			camera.EndAcquisition();
		}

		public bool GetNextImage(out Bitmap image) {
			image = null;
			try {
				using (IManagedImage rawImage = camera.GetNextImage()) {
					if(rawImage == null) {
						Console.WriteLine("Raw image null.");
						return false;
					}else if (rawImage.IsIncomplete) {
						Console.WriteLine("Raw image incomplete with image status {0}...", rawImage.ImageStatus);
						return false;
					} else {
						uint width = rawImage.Width;
						uint height = rawImage.Height;
						using (IManagedImage convertedImage = rawImage.Convert(PixelFormatEnums.RGB8)) { //TODO make this match whatever is saved!
							if(convertedImage == null) {
								Console.WriteLine("Converted iamge null.");
								return false;
							}else if (convertedImage.IsIncomplete) {
								Console.WriteLine("Converted image incomplete with image status {0}...", rawImage.ImageStatus);
								return false;
							}
							
							Bitmap imgBitmap = convertedImage.bitmap;
							if(imgBitmap == null) {
								Console.WriteLine("Bitmap was null.");
								return false;
							}
							image = new Bitmap(imgBitmap);
						}
						return true;
					}
				}
			} catch (SpinnakerException ex) {
				Console.WriteLine("Error: " + ex.Message);
				return false;
			}
		}

	}

}
