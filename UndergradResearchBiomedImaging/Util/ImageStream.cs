using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;

namespace UndergradResearchBiomedImaging.Util {

	/// <summary>
	/// Allows easier use of various input sources. Loads images from camera, images (including animated GIFs), and videos.
	/// Also has functions to prompt the user to load a file, or save a screenshot.
	/// </summary>
	public class ImageStream : IDisposable {

		#region Static Things
		//Used to prompt the user to open/save files
		private static OpenFileDialog openDialog;
		private static SaveFileDialog saveDialog;

		/// <summary>Contains "suported" image file extensions. Format of {{extension, extension name}, ...}</summary>
		private static string[,] imageFileExtensions = {
			{ ".bmp", "Bmp" },
			{ ".emf", "Emf" },
			{ ".exif", "Exif" },
			{ ".gif", "Gif" },
			{ ".ico", "Icon" },
			{ ".jpeg", "Jpeg" },
			{ ".jpg", "Jpg" },
			{ ".png", "Png" },
			{ ".tiff", "Tiff" }
		};

		/// <summary>Contains "Supported" video file extensions.</summary>
		private static string[] videoFileExtensions = new string[] { ".mkv", ".flv", ".f4v", ".ogv", ".ogg", ".gifv", ".mng", ".avi", ".mov", ".wmv", ".rm", ".rmvb", ".asf", ".amv", ".mp4", ".m4p", ".m4v", ".m4v", ".svi" };

		//Sets up the file dialogs
		static ImageStream() {
			//Prepare open file dialog
			openDialog = new OpenFileDialog();
			openDialog.RestoreDirectory = true;

			//Initialize the filter
			string openFilter = "Media Files (Image, Video)|";
			imageFileExtensions.GetLength(0);
			for (int i = 0; i < imageFileExtensions.GetLength(0); i++) {
				//For every image extension, add it to the filter.
				//e.x. for Bpm, it would add "*.bmp;"
				imageFileExtensions[i, 0] = imageFileExtensions[i, 0].ToLower();
				openFilter += "*" + imageFileExtensions[i, 0] + ";";
			}
			for (int i = 0; i < videoFileExtensions.Length; i++) {
				//This ensures all entered extensions are lowercase for matching later.
				videoFileExtensions[i] = videoFileExtensions[i].ToLower();

				//For every video extension, add it to the filter.
				//e.x. for mp4, it would add "*.mp4;"
				openFilter += "*" + videoFileExtensions[i] + ";";
			}
			openFilter = openFilter.TrimEnd(';'); //Trim the end to comply with the filter format.
			openDialog.Filter = openFilter; //Apply filter to open dialog.

			//Prepare save dialog.
			saveDialog = new SaveFileDialog();
			saveDialog.RestoreDirectory = true;
			saveDialog.AddExtension = true;

			string saveFilter = ""; //Initialize the filter
			for (int i = 0; i < imageFileExtensions.GetLength(0); i++) {
				//For every image, add its name and extension to the filter.
				//e.x. for bmp, it would add "Bmp (*.bmp)|*.bmp|"
				string ext = imageFileExtensions[i, 0];
				if (ext == ".png") saveDialog.FilterIndex = i + 1;
				saveFilter += imageFileExtensions[i, 1] + "(*" + ext + ")|*" + ext + "|";
			}
			saveFilter = saveFilter.TrimEnd('|'); //Trim the end to comply with filter format.
			saveDialog.Filter = saveFilter; //Apply filter to save dialog
		}
		#endregion

		#region Locks
		/// <summary> Used for checking if disposed or not. </summary>
		private readonly object streamLock = new object();

		/// <summary> Prevent running while a frame is being grabbed. </summary>
		private readonly object captureLock = new object();

		/// <summary> Ensures Dispose is only being called by one thread at a time. </summary>
		private readonly object disposeLock = new object();
		#endregion

		public FlirCamera camera { get; set; }

		private VideoCapture capture; //EmguCV class that assists in loading camera/files
		private Thread grabbingThread; //New thread that continously tries to grab images from the source.
		private volatile bool exitThread = false; //When set to true, informs grabbingThread to exit
		private Stopwatch timer = new Stopwatch(); //Used to set the correct FPS for video playback.
		private FPSCounter fpsCounter = new FPSCounter(); //Calculates the FPS.
		private Bitmap imageBuffer; //The last image that was grabbed, used for pausing, static images, and taking screenshots
		private volatile bool isPaused = true; //Indicates if the stream is paused or not.
		private string lastVideoFilePath = null; //Stores the last loaded video file path for auto-looping

		#region Events and Handlers
		/// <summary> Fired when a new image is grabbed from the selected source. </summary>
		public event NewImageHandler OnNewImage;
		public delegate void NewImageHandler(ImageStream sender, Bitmap image);

		/// <summary> Fired when a running stream is ended, either by the user, disposal of the object, or error reading the stream. </summary>
		public event StreamEndedHandler OnStreamEnded;
		public delegate void StreamEndedHandler(ImageStream sender); //Called when the current stream ends and is closed.

		/// <summary> Fired when the selected source for the input is changed. Does not fire when source changes to null due to the stream ending.</summary>
		public event SourceChangedHandler OnSourceChanged;
		public delegate void SourceChangedHandler(ImageStream sender, StreamType NewSource);
		#endregion

		#region Properties
		/// <summary> The width of the stream (i.e. grabbed images). </summary>
		public int Width { get { lock (captureLock) { return (capture == null) ? 0 : capture.Width; } } }

		/// <summary> The height of the stream (i.e. grabbed images). </summary>
		public int Height { get { lock (captureLock) { return (capture == null) ? 0 : capture.Height; } } }

		/// <summary> The size of the stream (i.e. grabbed images). </summary>
		public Size Size { get { lock (captureLock) { return (capture == null) ? (new Size(0, 0)) : (new Size(capture.Width, capture.Height)); } } }

		/// <summary> Whether or not there is an opened stream. </summary>
		public bool IsOpened { get { return StreamSource != StreamType.None; } }

		/// <summary> The target FPS defined by the selected stream. For a camera input, this is generally zero. </summary>
		public float TargetFPS { get; private set; } = 0f;

		/// <summary> The estimated measured FPS that is being achieved. This includes the time taken to fire new image events. </summary>
		public float FPS { get; private set; } = 0f;

		/// <summary>Setting this will override the target FPS and attempt to read images at this speed. Set to zero to turn off and operate normally. Note: Does not change TargetFPS property. </summary>
		public float AdjustedFPS { get; set; } = 0f;

		/// <summary>Flip enum set by flip properties.</summary>
		private RotateFlipType flipType = RotateFlipType.RotateNoneFlipNone;

		private static RotateFlipType getFlipType(bool flipHoriz, bool flipVert, InputRotation rotation) {
			if (flipHoriz) {
				if (flipVert) {
					switch (rotation) {
						case InputRotation.Degree0: return RotateFlipType.RotateNoneFlipXY;
						case InputRotation.Degree90: return RotateFlipType.Rotate90FlipXY;
						case InputRotation.Degree180: return RotateFlipType.Rotate180FlipXY;
						case InputRotation.Degree270: return RotateFlipType.Rotate270FlipXY;
					}
				} else {
					switch (rotation) {
						case InputRotation.Degree0: return RotateFlipType.RotateNoneFlipX;
						case InputRotation.Degree90: return RotateFlipType.Rotate90FlipX;
						case InputRotation.Degree180: return RotateFlipType.Rotate180FlipX;
						case InputRotation.Degree270: return RotateFlipType.Rotate270FlipX;
					}
				}
			} else {
				if (flipVert) {
					switch (rotation) {
						case InputRotation.Degree0: return RotateFlipType.RotateNoneFlipY;
						case InputRotation.Degree90: return RotateFlipType.Rotate90FlipY;
						case InputRotation.Degree180: return RotateFlipType.Rotate180FlipY;
						case InputRotation.Degree270: return RotateFlipType.Rotate270FlipY;
					}
				} else {
					switch (rotation) {
						case InputRotation.Degree0: return RotateFlipType.RotateNoneFlipNone;
						case InputRotation.Degree90: return RotateFlipType.Rotate90FlipNone;
						case InputRotation.Degree180: return RotateFlipType.Rotate180FlipNone;
						case InputRotation.Degree270: return RotateFlipType.Rotate270FlipNone;
					}
				}
			}

			return RotateFlipType.RotateNoneFlipNone;
		}

		private void setFlipType() {
			RotateFlipType type = getFlipType(flipHorizontal, flipVertical, rotation);
			if(type != flipType) {
				flipType = type;
				imageBuffer.RotateFlip(flipType);
			}
		}

		public InputRotation Rotation {
			get { return rotation; }
			set {
				lock (captureLock) {
					if(value != rotation) {
						rotation = value;
						setFlipType();
					}
				}
			}
		}
		private InputRotation rotation;

		/// <summary> Whether or not the input image should be flipped horizontally. </summary>
		public bool FlipHorizontal {
			get { return flipHorizontal; }

			set {
				lock (captureLock) {
					if (value != flipHorizontal) {
						flipHorizontal = value;
						setFlipType();
					}
				}
			}
		}
		private bool flipHorizontal = false;

		/// <summary> Whether or not the input image should be flipped vertically. </summary>
		public bool FlipVertical {
			get { return flipVertical; }

			set {
				lock (captureLock) {
					if (value != flipVertical) {
						flipVertical = value;
						setFlipType();
					}
				}
			}
		}
		private bool flipVertical = false;

		/// <summary> The FPS that will be used when streaming a static image or when the stream is paused. </summary>
		public float ImageFps { get => imageFPS; set { if (value >= 0) imageFPS = value; } }
		private float imageFPS = 15;

		/// <summary> The currently selected source of the stream. </summary>
		public StreamType StreamSource { get; private set; } = StreamType.None;

		/// <summary> If set to true, video streams will repeat from the beginning when the end is reached. </summary>
		public bool AutoLoop { get; set; } = false;
		#endregion

		/// <summary>
		/// Once created, a background thread is started that runs until the object is disposed.
		/// The purpose of this thread is to grab images from whatever input source was selected.
		/// </summary>
		public ImageStream() {
			grabbingThread = new Thread(imageGrabbingLoop);
			grabbingThread.Name = "Image Grabbing Thread";
			grabbingThread.IsBackground = true;
			grabbingThread.Start();
		}

		~ImageStream() { //Dispose object on garbadge collection
			Dispose();
		}

		/// <summary> Stops the grabbing thread and releases any inputs that were being used. If a stream was running, calling this fires an end of stream event. </summary>
		public void Dispose() {
			lock (disposeLock) {
				lock (streamLock) {
					if (grabbingThread == null) return;
				}

				exitThread = true;
				grabbingThread.Join();

				lock (streamLock) {
					grabbingThread = null; //Signals to other functions that we are disposed
					StreamSource = StreamType.None;
					if (capture != null) capture.Dispose();
					camera = null;
					capture = null;
					imageBuffer = null; //We do NOT want to dispose imageBuffer, in the case the image is being used elsewhere!
					fpsCounter = null;
					timer.Stop();
					timer = null;
				}
			}
		}

		#region Image Grabbing Thread
		/// <summary> The grabbing thread that runs in the background. </summary>
		private void imageGrabbingLoop() {
			try {
				while (!exitThread) { //Loops until the Dispose() flags up to stop 
					StreamType effectiveSource = StreamType.None; //After settings, what the source is effectivley acting as (i.e. if paused, acts as an iamge)
					Bitmap newImage = null; //Any new images grabbed that should be stored in the buffer
					timer.Restart(); //Starts timing the time it takes to process the next frame.
					lock (captureLock) { //Lock to prevent a new source opening while grabbing a frame.
						if (StreamSource != StreamType.None) { //There is a source we want to read!
							if (isPaused || (StreamSource == StreamType.Image && imageBuffer != null)) { //Streaming an image that has already been loaded OR the stream is paused
								if (imageBuffer != null) { //Check for paused stream (!isPlaying) if there is a stored image. (if not, we just want to wait, not try and grab one)
									effectiveSource = StreamType.Image;
									newImage = imageBuffer;
								}
							}else if(StreamSource == StreamType.Camera) {
								if (camera.GetNextImage(out newImage)) effectiveSource = StreamType.Camera;
								else endStream();
							} else { //Attempt to grab a frame from the source.
								Mat temp = new Mat(); //Give a place for the grabbed image to go.
								if (grabImage(temp)) {
									effectiveSource = StreamSource; //Source is still open.
									newImage = temp.Bitmap;
								} else if ((StreamSource == StreamType.Video) && (lastVideoFilePath != null) && AutoLoop) {
									capture.Dispose(); //Release the current video
									if (LoadFile(lastVideoFilePath)) { //Attempt to reload the video.
										Play();
										continue; //We have to try and read a frame again.
									} else endStream(); //Could not load, end stream.
								} else endStream();//Source must be closed.
							}
						}

						//Appropriately set the TargetFPS, and if needed, calculate the estimated FPS
						if (effectiveSource == StreamType.None) TargetFPS = 0;
						else {
							TargetFPS = (effectiveSource == StreamType.Image) ? imageFPS : (float)capture.GetCaptureProperty(CapProp.Fps);
							FPS = fpsCounter.Tick();
						}

						//if (newImage != null) newImage.RotateFlip(flipType); //TODO System.InvalidOperationException: 'Object is currently in use elsewhere.'
						imageBuffer = newImage; //Store the grabbed image into the image buffer.
					}

					int delayMS = 0; //The target time to wait;

					if (effectiveSource == StreamType.None) delayMS = 1; //If there is no stream, we want a small wait to look for a new input.
					else {
						OnNewImage?.Invoke(this, newImage); //If there is a stream, we want to invoke the new image grabbed, even if it was empty or null.
						if (effectiveSource != StreamType.Camera) delayMS = (int)(1000 / TargetFPS); //Calculate the ms each frame should last
					}

					//Wait the necessary time to acieve desired FPS
					float adjustedFps = AdjustedFPS;
					if (adjustedFps > 0) {
						int adjustedMS = (int)(1000 / adjustedFps);
						delayMS = adjustedMS;
					}

					timer.Stop();
					long millis = timer.ElapsedMilliseconds; //Read in the time it took to process one frame
					if (millis < delayMS && millis >= 0) delayMS -= (int)millis; //If the elapsed time is less than our desired time, calculate the time we should wait

					if (delayMS > 0) Thread.Sleep(delayMS); //This way if we can't keep up it will just run as fast as it can.
				}
			} finally {
				endStream(); //If anything breaks, or Dispose() exits the thread, end the current stream. Should fire OnStreamEnd.
			}
		}

		/// <summary> Attemps to grab grab an image from the stream, catching any errors. </summary>
		/// <param name="outputImage">Where the grabbed image will be saved to.</param>
		/// <returns>true if was grabbed successfully, false otherwise.</returns>
		private bool grabImage(Mat outputImage) {
			try {
				return capture.Grab() && capture.Retrieve(outputImage);
			} catch {
				return false;
			}
		}

		/// <summary> Attempts to end the stream by disposing of the capture object, and setting all variables to default. Throws OnStreamEnd event.</summary>
		private void endStream() {
			lock (captureLock) {
				lock (streamLock) {
					if (grabbingThread == null) return;
				}

				if (capture != null) capture.Dispose();
				camera = null;
				capture = null;
				imageBuffer = null;
				TargetFPS = 0;
				FPS = 0;
				lastVideoFilePath = null;
				fpsCounter.Reset();
				if (StreamSource != StreamType.None) { //Only fire event if the stream is closing, and wasnt already closed.
					StreamSource = StreamType.None;
					OnStreamEnded?.Invoke(this);
				}
			}
		}
		#endregion

		#region Stream Controls
		/// <summary> Starts or resumes the selected stream and starts grabbing images. When an image is grabbed, onNewImage is fired. </summary>
		public void Play() {
			isPaused = false;
		}

		/// <summary> Stops grabbing images from the source until resumed using Play(). Will continue firing onNewImage with the last grabbed image. </summary>
		public void Pause() {
			isPaused = true;
		}

		/// <summary> Closes the input and fires onStreamEnded event. </summary>
		public void Stop() {
			endStream();
		}
		#endregion

		#region Input Source Selection

		#region Select Camera

		/// <summary> Select a camera with the specified index as the source. </summary>
		/// <param name="index">Index of camera to be selected.</param>
		public bool SelectCamera(FlirCamera camera) {
			lock (captureLock) {
				lock (streamLock) {
					if (grabbingThread == null) return false;
					endStream();
					this.camera = camera;
					if (!setupCapture(true)) return false;
					StreamSource = StreamType.Camera;
					OnSourceChanged?.Invoke(this, StreamType.Camera);
					return true;
				}
			}
		}
		#endregion

		#region Load Files
		///<summary>Loads a gif image to read its frame counts to check if should load as an image or video.</summary>
		private static StreamType getGifStreamType(string filepath) {
			try {
				using (Image img = Image.FromFile(filepath)) { //Release resources once we are done reading the frame count.
					if (!img.RawFormat.Equals(ImageFormat.Gif)) return StreamType.None;
					FrameDimension dimension = new FrameDimension(img.FrameDimensionsList[0]);
					int frameCount = img.GetFrameCount(dimension); //Reads the number of frames in the gif

					if (frameCount == 1) return StreamType.Image; //If theres only one frame, it's just an image
					else if (frameCount > 1) return StreamType.Video; //If there are multiple frames, treat it as a video.
					else return StreamType.None;
				}
			} catch {
				return StreamType.None;
			}
		}

		/// <summary>Loops through all image and video extensions to determine what type of file it is.</summary>
		/// <param name="ext">The extension to look for. E.x. for bmp, pass ".bmp"</param>
		/// <returns>The type of stream the extension is.</returns>
		private static StreamType getExtensionStreamType(string ext) {
			ext = ext.ToLower(); //Ensure passed string is all lowercase
			for (int i = 0; i < imageFileExtensions.GetLength(0); i++) {
				//Loop through image extions
				if (ext == imageFileExtensions[i, 0]) return StreamType.Image;
			}

			foreach (string extName in videoFileExtensions) {
				//Loop through video extensions.
				if (ext == extName) return StreamType.Video;
			}

			return StreamType.None;
		}

		/// <summary> Loads a file to be used as the source. Supports most common image and video files. </summary>
		/// <param name="filepath">Full path to the file to be loaded.</param>
		/// <returns>true if the file was successfully loaded.</returns>
		public bool LoadFile(string filepath) {
			lock (captureLock) {
				lock (streamLock) {
					if (grabbingThread == null) return false; //Ensure not disposed
					if (filepath == null || !File.Exists(filepath)) {//Wait until here to check if file exists, in case we had to wait for the lock to be released.
						endStream(); //Failed to load, must end the current stream.
						return false;
					}

					string ext = Path.GetExtension(filepath).ToLower();
					StreamType streamType = (ext == ".gif") ? getGifStreamType(filepath) : getExtensionStreamType(ext); //Get the type of stream the file is

					endStream();
					if (streamType != StreamType.None) { //Setup the capture.
						capture = new VideoCapture(filepath);
						if (!setupCapture()) {
							return false;
						}
						StreamSource = streamType;
						if (streamType == StreamType.Video) lastVideoFilePath = filepath;
						OnSourceChanged?.Invoke(this, streamType);
						return true;
					} else {
						return false;
					}
				}
			}
		}

		/// <summary> Loads a file from the local solution files. </summary>
		/// <param name="filepath">Relative path to file from solution root file.</param>
		/// <returns>true if the file was successfully loaded.</returns>
		public bool LoadLocalFile(string filepath) {
			return LoadFile(System.IO.Directory.GetCurrentDirectory() + "\\" + filepath); //NOTE: '\\' translates to '\' in a string, because it is a special character.
		}

		/// <summary> Prompts the user to select a file, then attempts to load the selected file as the source. </summary>
		/// <returns>true if the file was successfully loaded, also returns false if user cancelled operation.</returns>
		public bool PromptUserLoadFile() {
			lock (streamLock) {
				if (grabbingThread == null) return false; //Ensure not disposed
			}
			if (openDialog.ShowDialog() == DialogResult.OK) { //Check if the user selected a file or pressed cancel instead.
				return LoadFile(openDialog.FileName);
			} else {
				return false;
			}
		}
		#endregion

		/// <summary>Sets up a capture so it is ready to use. Assumed to be called from inside a streamLock </summary>
		private bool setupCapture(bool isCamera = false) {
			if (!isCamera && !capture.IsOpened) return false;
			imageBuffer = null;
			isPaused = true;
			fpsCounter.Reset();
			FPS = 0;
			TargetFPS = 0;
			lastVideoFilePath = null;
			return true;
		}
		#endregion

		#region Save Screenshots
		/// <summary>Captures a screenshot.</summary>
		/// <returns>The captured screenshot, null if not able to capture</returns>
		private Bitmap captureScreenshot() {
			Bitmap screenshot = imageBuffer; //Atomic thread-safe grab of the buffer
			if (screenshot == null) return null;
			else return new Bitmap((Image)screenshot.Clone());
		}

		/// <summary> Take a screenshot and save it to the file specified. The path should include the file name and extension.</summary>
		/// <param name="filepath">The full path to where the file should be saved.</param>
		/// <returns>true if the screenshot was successfully saved.</returns>
		public bool SaveScreenshot(string filepath) {
			Bitmap screenshot = captureScreenshot();
			return SaveScreenshot(screenshot, filepath);
		}

		/// <summary> Saves the given image to the full path given. Path must include extension.</summary>
		/// <param name="img">Image to be saved</param>
		/// <param name="filepath">Full path to be saved.</param>
		/// <returns>true if saved</returns>
		public static bool SaveScreenshot(Bitmap img, string filepath) {
			if (img == null || filepath == null) return false;
			img.Save(filepath);
			return true;
		}

		/// <summary> Takes a screenshot and saves it to relative local solution files. Path must include extension.</summary>
		/// <param name="filepath">Relative path to save location in solution files.</param>
		/// <returns>true if successfully saved.</returns>
		public static bool SaveLocalScreenshot(string filepath) {
			return SaveLocalScreenshot(System.IO.Directory.GetCurrentDirectory() + "\\" + filepath); //NOTE: '\\' translates to '\' in a string, because it is a special character.
		}

		/// <summary> Saves the given image to relative local solution files. Path must include extension. </summary>
		/// <param name="img">Image to save</param>
		/// <param name="filepath">Relative path to save to.</param>
		/// <returns>true if saved</returns>
		public static bool SaveLocalScreenshot(Bitmap img, string filepath) {
			return SaveScreenshot(img, System.IO.Directory.GetCurrentDirectory() + "\\" + filepath); //NOTE: '\\' translates to '\' in a string, because it is a special character.
		}

		/// <summary>Prompts the user to select a save location and extension.</summary>
		/// <param name="img">Image to be saved.</param>
		/// <returns>true if saved</returns>
		public static bool PromptUserSaveScreenshot(Bitmap img) {
			if (img == null) return false;

			if (saveDialog.ShowDialog() == DialogResult.OK) {
				img.Save(saveDialog.FileName);
				return true;
			} else {
				return false;
			}
		}

		/// <summary> Takes a screenshot and prompts the user to select a save location and extension. </summary>
		/// <returns>true if successfully saved, also returns false if user cancelled operation.</returns>
		public bool PromptUserSaveScreenshot() {
			return PromptUserSaveScreenshot(captureScreenshot());
		}
		#endregion

		/// <summary>Represents type of stream selected. </summary>
		public enum StreamType {
			None,
			Camera,
			Image,
			Video
		}

	}

}