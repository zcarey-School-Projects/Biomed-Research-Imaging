using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using RobotHelpers.InputHandling;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using UndergradResearchBiomedImaging;

namespace UndergradResearchBiomedImaging.Flir {
	public class FlirCameraInput : InputHandler {

		public FlirCamera Camera { get; set; }
		private bool isStreaming = false;

		public FlirCameraInput(FlirCamera camera) {
			try {
				this.Camera = camera;

				if (!camera.Properties.AcquisitionMode.TrySetValue(AcquisitionModeEnums.Continuous)) { 
					throw new SpinnakerException("Unable to set acquisition mode to continuous.");
				}

				if (!camera.Properties.PixelFormat.TrySetValue(PixelFormatEnums.RGB8)) { 
					Console.WriteLine("Pixel format '{0}' is not available.", PixelFormatEnums.RGB8.ToString());
				}

			} catch(SpinnakerException ex) {
				camera.Dispose();
				camera = null;
				Console.WriteLine("Error: " + ex.Message);
			}
		}

		protected override void onDispose() {
			if (Camera != null) {
				Camera.EndStream();
				Camera.Dispose();
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
			return Camera.GetNextImage();
		}

		public override void Play() {
			Camera.StartStream();
			isStreaming = true;
			base.Play();

		}

		public override void Pause() {
			base.Pause();
			isStreaming = false;
			Camera.EndStream();
		}

	}
}
