using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;

namespace UndergradResearchBiomedImaging.Util {
	public class FastRecorder : IDisposable {
		private const int Max_Image_Buffer_Count = 60;

		private VideoWriter writer;
		private string filepath;
		private FlirCameraStream stream;

		private Thread savingThread;
		private ConcurrentQueue<Image<Bgr, byte>> imageBuffer = new ConcurrentQueue<Image<Bgr, byte>>();

		public FastRecorder(string filepath) {
			this.filepath = filepath;

			savingThread = new Thread(ThreadLoop);
			savingThread.Name = "Fast Recording Thread";
			savingThread.IsBackground = true;
			savingThread.Start();
		}

		public void Dispose() {
			//TODO end thread
		}

		private void ThreadLoop() {
			while (true) {
				lock (this) {
					if((writer != null) && (writer.IsOpened)) {
						Image<Bgr, byte> temp; //TODO save in chunks if possible?
						if(imageBuffer.TryDequeue(out temp)) {
							writer.Write(temp.Mat);
						}
					}
				}
				Thread.Sleep(1);
			}
		}

		private void NewImageGrabbed(FlirCameraStream sender, Image<Bgr, byte> image) {
			if(imageBuffer.Count >= Max_Image_Buffer_Count) {
				Stop();
				Console.WriteLine("Too many images in queue! Assuming can't keep up, so stopped recording.");//TODO send event.
																											 //TODO Blow up! too many images!
				MessageBox.Show("Too many images!");

			} else {
				imageBuffer.Enqueue(image);
			}
		}

		public bool Start(FlirCameraStream stream) {
			this.stream = stream;
			FlirCamera camera = stream.SourceCamera;
			if (camera == null) return false;
			long width = 0;
			long height = 0;
			if (!camera.Properties.Width.TryGetValue(ref width) || !camera.Properties.Height.TryGetValue(ref height)) return false;
			VideoWriter newWriter = new VideoWriter(filepath, VideoWriter.Fourcc('M', 'P', '4', '2'), 60, new Size((int)width, (int)height), true);
			if (newWriter.IsOpened) {
				writer = newWriter;
				stream.OnNewImage += NewImageGrabbed;
				return true;
			} else {
				newWriter.Dispose();
				return false;
			}
		}

		public void Stop() {
			VideoWriter oldWriter;
			lock (this) {
				oldWriter = writer;
				writer = null;
			}
			if(stream != null) stream.OnNewImage -= NewImageGrabbed;
			stream = null; //TODO thead safe please
			if (oldWriter != null) {
				oldWriter.Dispose();
			}
			//TODO write remaining images.
			Image<Bgr, byte> temp;
			while (imageBuffer.TryDequeue(out temp)) {

			}
		}

	}
}
