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
		private volatile bool markedDead = false;

		/// <summary> Fired when the recording is forced closed because it can't keep up. </summary>
		public event ForcedClosedHandler OnRecordingForcedClosed;
		public delegate void ForcedClosedHandler(FastRecorder sender);

		/// <summary>Fires when the cording starts or stops. </summary>
		public event RecordingStateChangedHandler OnRecordingChanged;
		public delegate void RecordingStateChangedHandler(FastRecorder sender, bool IsRecording);

		public FastRecorder(string filepath) {
			if (filepath == null) filepath = @"TempVideo.avi";
			this.filepath = filepath;

			savingThread = new Thread(ThreadLoop);
			savingThread.Name = "Fast Recording Thread";
			savingThread.IsBackground = true;
			savingThread.Start();
		}

		public void Dispose() {
			lock (this) {
				savingThread.Abort();
			}
			closeWriterSafely();
		}
		//TODO every X number of frames, save the current data in a seperate thread and open a new writer to help save memory.
		private void ThreadLoop() {
			while (true) {
				lock (this) {
					if((writer != null) && (writer.IsOpened)) {
						if (imageBuffer.Count >= Max_Image_Buffer_Count) {
							//This is a problem, the recording can't keep up.
							if (stream != null) stream.OnNewImage -= NewImageGrabbed;
							return; //Will end the thread, will will prevent any events to close themselves.
						}
						
						//Save any images in the queue. Limit to 3 at a time juat in case we can't save fast enough.
						Image<Bgr, byte> frame;
						for(int i = 0; i < 3; i++) {
							if(imageBuffer.TryDequeue(out frame)) {
								writer.Write(frame.Mat);
							} else {
								break;
							}
						}
					}else if (imageBuffer.Count >= Max_Image_Buffer_Count) {
						//We must be closing, just let the "NewImageGrabbed" method close itself, and keep the buffer clean.
						imageBuffer = new ConcurrentQueue<Image<Bgr, byte>>();
					}
				}
				Thread.Sleep(1);
			}
		}

		private void NewImageGrabbed(FlirCameraStream sender, Image<Bgr, byte> image) {
			if (savingThread.IsAlive) {
				imageBuffer.Enqueue(image);
			} else {
				sender.OnNewImage -= NewImageGrabbed;
				lock (this) {
					if (!markedDead) {
						markedDead = true;
						closeWriterSafely();
						OnRecordingForcedClosed?.Invoke(this);
					}
				}
			}
		}

		public bool Start(FlirCameraStream stream) {
			lock (this) {
				if (((writer != null) && (writer.IsOpened)) || !savingThread.IsAlive) return false;
				FlirCamera camera = stream.SourceCamera;
				if (camera == null) return false;
				long width = 0;
				long height = 0;
				if (!camera.Properties.Width.TryGetValue(ref width) || !camera.Properties.Height.TryGetValue(ref height)) return false;
				writer = new VideoWriter(filepath, VideoWriter.Fourcc('M', 'P', '4', '2'), 48, new Size((int)width, (int)height), true);
				if (writer.IsOpened) {
					this.stream = stream;
					imageBuffer = new ConcurrentQueue<Image<Bgr, byte>>();
					stream.OnNewImage += NewImageGrabbed;
					OnRecordingChanged?.Invoke(this, true);
					return true;
				} else {
					writer.Dispose();
					writer = null;
					return false;
				}
			}
			
		}

		private bool closeWriterSafely() {
			if ((writer != null) && (writer.IsOpened)) {
				stream.OnNewImage -= NewImageGrabbed;
				stream = null;

				Image<Bgr, byte> frame = null;
				while (imageBuffer.TryDequeue(out frame)) {
					//Empty the queue, saving any frames to the file
					writer.Write(frame.Mat);
				}

				writer.Dispose();
				writer = null;
				return true;
			} else {
				//Something may have happened, but this isn't a successful stop, so just try and clean up what we can.
				if (writer != null) writer.Dispose();
				writer = null;
				if (stream != null) stream.OnNewImage -= NewImageGrabbed;
				stream = null;
				return false;
			}
		}

		public bool Stop() {
			lock (this) {
				if (closeWriterSafely()) {
					OnRecordingChanged?.Invoke(this, false);
					return true;
				} else {
					return false; 
				}
			}
		}

	}
}
