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

namespace UndergradResearchBiomedImaging.Flir {
	public class FlirCameraInput : InputHandler {

		public FlirCamera Camera { get; private set; }
		//private INodeMap node;
		private bool isStreaming = false;

		public FlirCameraInput() {

		}

		public FlirCameraInput(FlirCamera camera) {
			SetCamera(camera);
		}

		public void SetCamera(FlirCamera camera) {
			lock (inputLock) {
				Dispose();
				try {
					this.Camera = camera;
					camera.BeginAcquisition();
				} catch (SpinnakerException ex) {
					camera = null;
					//node = null;
					Console.WriteLine("Error: " + ex.Message);
				}
			}
			
		}

		protected override void onDispose() {
			if (Camera != null) {
				Camera.EndAcquisition();
				//Camera.Dispose();
			}
		}

		public override int GetHeight() {
			//TODO height
			throw new NotImplementedException();
		}

		public override int GetWidth() {
			//TODO wifth
			throw new NotImplementedException();
		}

		protected override int getDelayMS() {
			return 0;
		}

		protected override bool isNextFrameAvailable() {
			//throw new NotImplementedException();
			//TODO check camera stream
			return (Camera != null) && isStreaming;
		}

		protected override Image<Bgr, byte> readFrame() {
			if (Camera != null) return Camera.GrabImage();

			return null;
		}

		public override void Play() {
			lock (inputLock) {
				Camera.ResumeAcquisition();
				isStreaming = true;
				base.Play();
			}
		}

		public override void Pause() {
			lock (inputLock) {
				base.Pause();
				isStreaming = false;
				Camera.EndAcquisition();
			}
		}
	}
}
