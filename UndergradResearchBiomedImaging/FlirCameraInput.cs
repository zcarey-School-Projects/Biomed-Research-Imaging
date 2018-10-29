using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using SpinnakerNET;
using SpinnakerNET.GenApi;

namespace RobotHelpers.InputHandling {
	public class FlirCameraInput : InputHandler {

		private IManagedCamera camera;
		private INodeMap node;
		private bool isStreaming = false;

		public FlirCameraInput(IManagedCamera camera) {
			try {
				this.camera = camera;
				camera.Init();
				node = camera.GetNodeMap();

				// Set acquisition mode to continuous
				IEnum iAcquisitionMode = node.GetNode<IEnum>("AcquisitionMode");
				if (iAcquisitionMode == null || !iAcquisitionMode.IsWritable) {
					throw new SpinnakerException("Unable to set acquisition mode to continuous(node retrieval).");
				}

				IEnumEntry iAcquisitionModeContinuous = iAcquisitionMode.GetEntryByName("Continuous");
				if (iAcquisitionModeContinuous == null || !iAcquisitionMode.IsReadable) {
					throw new SpinnakerException("Unable to set acquisition mode to continuous(entry retrieval).");
				}

				iAcquisitionMode.Value = iAcquisitionModeContinuous.Value;

				Console.WriteLine("Acquisition mode set to continuous...");

				//Set camera to color mode
				IEnum pixelFormat = node.GetNode<IEnum>("PixelFormat");
				foreach(IEnumEntry entry in pixelFormat.Entries) {
					Console.WriteLine(entry.DisplayName);
				}

				if(pixelFormat != null && pixelFormat.IsWritable) {
					IEnumEntry pixelFormatBgr8 = pixelFormat.GetEntryByName("RGB8");
					if(pixelFormatBgr8 != null && pixelFormatBgr8.IsReadable) {
						pixelFormat.Value = pixelFormatBgr8.Value;
						Console.WriteLine("Pixel format set to {0}...", pixelFormat.Value.String);
					} else {
						Console.WriteLine("Pixel format '{0}' is not available.", ((pixelFormatBgr8 != null) ? pixelFormatBgr8.ToString() : "???"));
					}
				} else {
					Console.WriteLine("Pixel format is not available.");
				}

			} catch(SpinnakerException ex) {
				camera = null;
				node = null;
				Console.WriteLine("Error: " + ex.Message);
			}
		}

		protected override void onDispose() {
			if (camera != null) {
				camera.EndAcquisition();
				camera.Dispose();
			}
		}

		public override int GetHeight() {
			throw new NotImplementedException();
		}

		public override int GetWidth() {
			throw new NotImplementedException();
		}

		protected override int getDelayMS() {
			return 0;
		}

		protected override bool isNextFrameAvailable() {
			//throw new NotImplementedException();
			//TODO check camera stream
			return isStreaming;
		}

		protected override Image<Bgr, byte> readFrame() {
			if (!isStreaming) return null;
			using(IManagedImage rawImage = camera.GetNextImage()) {
				try {
					if (rawImage.IsIncomplete) throw new SpinnakerException("Image incomplete with image status " + rawImage.ImageStatus);
					using (IManagedImage deepCopy = rawImage.Convert(PixelFormatEnums.BGR8)) {
						Bitmap img = deepCopy.bitmap;
						if (img == null) return null;
						return new Image<Bgr, byte>(img);
					}
				} catch(SpinnakerException ex) {
					Console.WriteLine("Error: " + ex.Message);
					return null;
				}
			}
		}

		public override void Play() {
			camera.BeginAcquisition();
			isStreaming = true;
			base.Play();

		}

		public override void Pause() {
			base.Pause();
			isStreaming = false;
			camera.EndAcquisition();
		}

	}
}
