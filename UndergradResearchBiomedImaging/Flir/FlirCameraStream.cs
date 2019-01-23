using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.Flir {

	public class FlirCameraStream : IDisposable{

		private FlirCamera camera = null;
		public FlirCamera SourceCamera {
			get => camera;
			set {
				lock (this) {
					if (value == camera) return;
					fpsCounter.Reset();
					//width
					//height
					imageBuffer = null;
					if (value != null) {
						if (value.BeginAcquisition()) {
							camera = value;
							OnSourceChanged?.Invoke(this, value);
						} else {
							if(camera != null) {
								camera = null;
								OnSourceChanged?.Invoke(this, null);
							}
						}
					} else {
						camera = null;
						OnSourceChanged?.Invoke(this, null);
					}
				}
			}
		}

		private Thread grabbingThread;
		private volatile bool exitThread = false;
		private Image<Bgr, byte> imageBuffer;
		private FPSCounter fpsCounter = new FPSCounter();

		public delegate void NewImageHandler(FlirCameraStream sender, Image<Bgr, byte> image);
		public event NewImageHandler OnNewImage;

		public delegate void SourceChangedHandler(FlirCameraStream sender, FlirCamera NewSource);
		public event SourceChangedHandler OnSourceChanged;

		long Width {
			get {
				FlirCamera camera = this.camera;
				if (camera == null) return 0;
				long width = 0;
				if (!camera.Properties.Width.TryGetValue(ref width)) return 0;
				else return width;
			}
		}

		long Height {
			get {
				FlirCamera camera = this.camera;
				if (camera == null) return 0;
				long height = 0;
				if (!camera.Properties.Height.TryGetValue(ref height)) return 0;
				else return height;
			}
		}

		public float FPS { get => fpsCounter.FPS; }

		public FlirCameraStream() {
			grabbingThread = new Thread(imageGrabbingLoop);
			grabbingThread.Name = "Flir Camera Stream";
			grabbingThread.IsBackground = true;
			grabbingThread.Start();
		}

		public void Dispose() {
			exitThread = true;
			grabbingThread.Join();
			endStream();
		}

		private void imageGrabbingLoop() {
			while (!exitThread) {
				lock (this) {
					if (camera != null) {
						if (camera.GrabImage(out imageBuffer)) {
							fpsCounter.Tick();
							//We all good
							OnNewImage?.Invoke(this, imageBuffer);
						} else {
							endStream();
						}
					}
				}
				Thread.Sleep(1); 
			}
		}

		private void endStream() {
			bool shouldInvoke = (camera != null);
			camera = null;
			imageBuffer = null;
			if(shouldInvoke) OnSourceChanged?.Invoke(this, null);
			fpsCounter.Reset();
			//Width = 0;
			//Height = 0;
		}
	}
}
