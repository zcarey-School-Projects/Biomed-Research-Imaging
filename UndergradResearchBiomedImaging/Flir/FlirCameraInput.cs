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
using UndergradResearchBiomedImaging;

namespace RobotHelpers.InputHandling {
	public class FlirCameraInput : InputHandler {

		public FlirCamera Camera { get; set; }

		public FlirCameraInput(FlirCamera camera) {
			try {
				this.Camera = camera;
				camera.Init();

				if (!camera.TrySetAcquisitionMode(AcquisitionModeEnums.Continuous)) {
					Console.WriteLine("Could not set acquisition mode.");
				}

				if (!camera.TrySetPixelFormat(PixelFormatEnums.RGB8)) {
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
			Integer val = Camera.Height;
			if (val == null) return 0;
			else return (int)val;
		}

		public override int GetWidth() {
			Integer val = Camera.Width;
			if (val == null) return 0;
			else return (int)val;
		}

		protected override int getDelayMS() {
			return 0;
		}

		protected override bool isNextFrameAvailable() {
			//throw new NotImplementedException();
			//TODO check camera stream
			return Camera.Streaming;
		}

		protected override Image<Bgr, byte> readFrame() {
			if (!isNextFrameAvailable()) return null;
			return Camera.GetNextImage();
		}

		public override void Play() {
			Camera.StartStream();
			base.Play();
		}

		public override void Pause() {
			base.Pause();
			Camera.EndStream();
		}

	}
}
