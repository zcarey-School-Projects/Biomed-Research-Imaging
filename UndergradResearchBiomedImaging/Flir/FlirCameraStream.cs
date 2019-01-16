using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndergradResearchBiomedImaging.Flir {
	public class FlirCameraStream {

		private Thread grabbingThread;
		private volatile bool running = true;
		private Stopwatch timer;
		private Bitmap framebuffer;
		private FlirCamera camera;

		public float FPS { get; private set; } = 0;

		public delegate void NewImageHandler(FlirCameraStream sender, Bitmap Image);
		public event NewImageHandler OnNewImage;

		public delegate void SourceChangeHandler(FlirCameraStream sender, FlirCamera NewSource);
		public event SourceChangeHandler OnSourceChanged;

		private static SaveFileDialog saveDialog;
		static FlirCameraStream() { //TODO move to class
			saveDialog = new SaveFileDialog();
			saveDialog.RestoreDirectory = true;
			saveDialog.AddExtension = true;
			saveDialog.Filter = "BMP (*.bmp)|*.bmp|EMF (*.emf)|*.emf|EXIF (*.exif)|*.exif|GIF (*.gif)|*.gif|Icon(*.ico)|*.ico|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|TIFF (*.tiff)|*.tiff|WMF (*.wmf)|*.wmf";
			saveDialog.DefaultExt = "*.png";
		}

		public FlirCameraStream() {
			timer = new Stopwatch();

			grabbingThread = new Thread(grabbingLoop);
			grabbingThread.IsBackground = true;
			grabbingThread.Name = "Image Grabbing Thread";
			grabbingThread.Start();
		}

		/// <summary>If running, stops the grabbing thread.</summary>
		public void Dispose() {
			running = false;
			EndStream();
			grabbingThread.Join();
		}

		private void grabbingLoop() {
			while (running) {
				lock (this) {
					if (camera != null) {
						if (!camera.IsStreaming) {
							endStream();
							OnSourceChanged?.Invoke(this, null);
						}

						if (timer.IsRunning) {
							//TODO fps
							FPS = 1;
						}
						timer.Restart();
						if (camera.GetNextImage(out framebuffer)) {
							OnNewImage?.Invoke(this, framebuffer);
						} else {
							endStream();
							OnSourceChanged?.Invoke(this, null);
						}
					}
				}

				//FPSStatusLabel.InvokeIfRequired(this, label => { label.Text = fpsCounter.FPS.ToString("N2"); });
				//Thread.Sleep(1);
			}
		}

		private void endStream() {
			if(camera != null) camera.EndStream();
			camera = null;
			framebuffer = null;
		}

		/// <summary> Stops the stream and raises a source changed event. </summary>
		public void EndStream() {
			lock (this) {
				if(camera != null) {
					endStream();
					OnSourceChanged?.Invoke(this, camera);
				}
			}
		}

		/// <summary> Select a camera with the specified index as the source. </summary>
		/// <param name="index">Index of camera to be selected.</param>
		public bool SelectCamera(FlirCamera camera) {
			if (camera == null) return false;
			lock (this) {
				endStream();
				this.camera = camera;
				OnSourceChanged?.Invoke(this, camera);
				camera.StartStream();
				return true;
			}
		}

		/// <summary>
		/// Returns the path to the current working directory, i.e. Files in your solution.
		/// </summary>
		/// <returns></returns>
		public static String GetWorkingDirectory() {
			return System.IO.Directory.GetCurrentDirectory() + "\\";
		}
	}
}
