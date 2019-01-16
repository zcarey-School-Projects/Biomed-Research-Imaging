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

		private FlirCamera camera;
		//private INodeMap node;
		private bool isStreaming = false;

		public FlirCameraInput(FlirCamera camera) {
			try {
				this.camera = camera;
				camera.BeginAcquisition(); 
			} catch(SpinnakerException ex) {
				camera = null;
				//node = null;
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
			return camera.GrabImage();
		}

		public override void Play() {
			camera.ResumeAcquisition();
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
