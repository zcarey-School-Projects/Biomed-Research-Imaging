using Emgu.CV;
using Emgu.CV.Structure;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging {
	public class FlirCamera : IDisposable {

		public Integer Width { get => camera.Width; set => camera.Width = value; }
		public Integer Height { get => camera.Height; set => camera.Height = value; }
		public bool Streaming { get; private set; }

		private IManagedCamera camera;
		private bool initialized = false;

		public FlirCamera(IManagedCamera cam) {
			this.camera = cam;
		}

		public void Dispose() {
			Streaming = false;
			initialized = false;
			camera.Dispose();
		}

		public void Init() {
			camera.Init();
			if (camera.IsInitialized() && TrySetAcquisitionMode(AcquisitionModeEnums.Continuous)) {
				initialized = true;
				Console.WriteLine("Camera initialized: " + camera.DeviceModelName);
			} else {
				Console.WriteLine("Camera could not be initialized.");
			}
		}

		public void StartStream() {
			if (!initialized) return;
			camera.BeginAcquisition();
			Streaming = true;
		}

		public void EndStream() {
			if (!Streaming) return;
			Streaming = false;
			camera.EndAcquisition();
		}

		public Image<Bgr, byte> GetNextImage() {
			if (Streaming == false) return null;
			using (IManagedImage rawImage = camera.GetNextImage()) {
				try {
					if (rawImage.IsIncomplete) return null;
					using (IManagedImage deepCopy = rawImage.Convert(PixelFormatEnums.BGR8)) {
						Bitmap img = deepCopy.bitmap;
						if (img == null) return null;
						return new Image<Bgr, byte>(img);
					}
				} catch (SpinnakerException ex) {
					Console.WriteLine("Error: " + ex.Message);
					return null;
				}
			}
		}

		private string convertStringNode(StringNode node) {
			try {
				return node;
			} catch (SpinnakerException) {
				return "N/A";
			}
		}

		/////////////////////// PROPERTIES
		public string GetVendorName() {
			return convertStringNode(camera.DeviceVendorName);
		}

		public string GetDeviceName() {
			return convertStringNode(camera.DeviceModelName); //TODO more model names
		}

		public bool TrySetAcquisitionMode(AcquisitionModeEnums mode) {
			try {
				camera.AcquisitionMode.Value = mode.ToString();
				return true;
			} catch (SpinnakerException) {
				return false;
			}
		}

		public AcquisitionModeEnums? GetAcquisitionMode() {
			try {
				return (AcquisitionModeEnums)Enum.Parse(typeof(AcquisitionModeEnums), camera.AcquisitionMode.Value.String);
			} catch (Exception) {
				return null;
			}
		}

		public bool TrySetPixelFormat(PixelFormatEnums format) {
			try {
				camera.PixelFormat.Value = format.ToString();
				return true;
			} catch (SpinnakerException) {
				return false;
			}
		}

		public PixelFormatEnums? GetPixelFormat() {
			try {
				return (PixelFormatEnums)Enum.Parse(typeof(PixelFormatEnums), camera.PixelFormat.Value.String);
			} catch (Exception) {
				return null;
			}
		}
		
		public bool TrySetTestPatternGeneratorSelector(TestPatternGeneratorSelectorEnums selector) {
			try {
				camera.TestPatternGeneratorSelector.Value = selector.ToString();
				return true;
			} catch (SpinnakerException) {
				return false;
			}
		}

		public TestPatternGeneratorSelectorEnums? GetTestPatternGeneratorSelector() {
			try {
				return (TestPatternGeneratorSelectorEnums)Enum.Parse(typeof(TestPatternGeneratorSelectorEnums), camera.TestPatternGeneratorSelector.Value.String);
			} catch (Exception) {
				return null;
			}
		}

		public bool TrySetTestPattern(TestPatternEnums pattern) {
			try {
				camera.TestPattern.Value = pattern.ToString();
				return true;
			} catch (SpinnakerException) {
				return false;
			}
		}

		public TestPatternEnums? GetTestPattern() {
			try {
				return (TestPatternEnums)Enum.Parse(typeof(TestPatternEnums), camera.TestPattern.Value.String);
			} catch (Exception) {
				return null;
			}
		}
	
	}

	//AccessPrivilegeAvailable
	//AcquisitionFrameCount
	//AcquisitionFrameRate
	//AcquisitionFrameRateAuto
	//AcquisitionFrameRateEnabled
	//AcquisitionStart
	//AcquisitionStatus
	//AcquisitionStatusSelector
	//AcquisitionStop
	//ActivePageNumber
	//ActivePageOffset
	//ActivePageSave
	//ActivePageValue
	//AutoExposureTimeLowerLimit
	//AutoExposureTimeUpperLimit
	//AutoFunctionAOIHeight
	//AutoFunctionAOIOffsetX
	//AutoFunctionAOIOffsetY
	//AutoFunctionAOIsControl
	//AutoFunctionAOIWidth
	//AutoGainLowerLimit
	//AutoGainUpperLimit
	//BalanceRatio
	//BalanceRatioSelector
	//BalanceWhiteAuto
	//BinningHorizontal
	//BinningVertical
	//BlackLevel
	//BlackLevelAuto
	//BlackLevelEnabled
	//BufferHandlingControl
	//ChunkBlackLevel
	//ChunkCRC
	//ChunkEnable
	//ChunkExposureTime
	//ChunkFrameCounter
	//ChunkGain
	//ChunkHeight
	//ChunkImage
	//ChunkModeActive
	//ChunkOffsetX
	//ChunkOffsetY
	//ChunkPixelDynamicRangeMax
	//ChunkPixelDynamicRangeMin
	//ChunkPixelFormat
	//ChunkSelector
	//ChunkTimestamp
	//ChunkWidth
	//DataFlashBaseAddress
	//DataFlashPageCount
	//DataFlashPageSize
	//DecimationHorizontal
	//DecimationHorizontalLocked
	//DecimationVertical
	//DeviceFamilyName
	//DeviceFirmwareVersion
	//DeviceGenCpVersionMajor
	//DeviceGenCPVersionMinor
	//DeviceID
	//DeviceLinkThroughputLimit
	//DeviceMaxThroughput
	//DeviceModelName
	//DeviceReset
	//DeviceScanType
	//DeviceSerialNumber
	//DeviceSVNVersion
	//DeviceTemperature
	//DeviceUserID
	//DeviceVendorName
	//DeviceVersion
	//EndianessRegistersSupported
	//EventAcquisitionEnd
	//EventAcquisitionEndData
	//EventAcquisitionEndFrameID
	//EventAcquisitionEndPort
	//EventAcquisitionEndTimestamp
	//EventAcquisitionStart
	//EventAcquisitionStartData
	//EventAcquisitionStartFrameID
	//EventAcquisitionStartTimestamp
	//EventExposureEnd
	//EventExposureEndData
	//EventExposureEndFrameID
	//EventExposureEndPort
	//EventExposureEndTimestamp
	//EventExposureStart
	//EventExposureStartFrameID
	//EventExposureStartPort
	//EventExposureStartTimestamp
	//EventNotification
	//EventSelector
	//EventTest
	//EventTestData
	//EventTestFrameID
	//EventTestTimestamp
	//ExposureAuto
	//ExposureMode
	//ExposureTime
	//ExposureTimeAbs
	//FamilyRegisterAvailable
	//Gain
	//Gamma
	//GammaEnabled
	//HeightMax
	//Hue
	//HueAuto
	//HueEnabled
	//LineDebouncerTimeRaw
	//LineInverter
	//LineMode
	//LineSelector
	//LineSource
	//LineStatus
	//LineStatusAll
	//LUTEnable
	//LUTIndex
	//LUTSelector
	//LUTValue
	//LUTValueAll
	//MessageChannelSupported
	//OffsetX
	//OffsetY
	//OnBoardColorProcessEnabled
	//ParameterSelector
	//PayloadSize
	//pgrAutoExposureCompensationLowerLimit
	//pgrAutoExposureCompensationUpperLimit
	//pgrCurrentCorrectedPixelCount
	//pgrCurrentCorrectedPixelIndex
	//pgrCurrentCorrectedPixelOffsetX
	//pgrCurrentCorrectedPixelOffsetY
	//pgrCurrentCorrectedPixelSave
	//pgrDefectPixelCorrectionEnable
	//pgrDefectPixelCorrectionTestMode
	//pgrDevicePowerSupplySelector
	//pgrDeviceUptime
	//pgrExposureCompensation
	//pgrExposureCompensationAuto
	//pgrPowerSourcePresent
	//pgrPowerSupplyCurrent
	//pgrPowerSupplyEnable
	//pgrPowerSupplyVoltage
	//pgrSensorDescription
	//PixelCoding
	//PixelColorFilter
	//PixelDefectControl
	//PixelDynamicRangeMax
	//PixelDynamicRangeMin
	//PixelSize
	//RemoveLimits
	//ReverseX
	//Saturation
	//SaturationAuto
	//SaturationEnabled
	//SBRMSupported
	//SensorHeight
	//SensorWidth
	//Sharpness
	//SharpnessAuto
	//SharpnessEnabled
	//SingleFrameAcquisitionMode
	//StreamBlockTransferSize
	//StreamBufferCountAuto
	//StreamBufferCountManual
	//StreamBufferCountMax
	//StreamBufferCountMode
	//StreamBufferCountResult
	//StreamBufferHandlingMode
	//StreamBufferUnderrunCount
	//StreamCRCCheckEnable
	//StreamDefaultBufferCount
	//StreamDefaultBufferCountMax
	//StreamDefaultBufferCountMode
	//StreamDiagnostics
	//StreamFailedBufferCount
	//StreamID
	//StreamInformation
	//StreamTotalBufferCount
	//StreamType
	//StringEncoding
	//StrobeDelay
	//StrobeDuration
	//TestImageSelector
	//TestPendingAck
	//Timestamp
	//TimestampIncrement
	//TimestampLatch
	//TimestampSupported
	//TransmitFailureCount
	//TransmitFailureCountReset
	//TriggerActivation
	//TriggerDelay
	//TriggerDelayEnabled
	//TriggerEventTest
	//TriggerMode
	//TriggerOverlap
	//TriggerSelector
	//TriggerSoftware
	//TriggerSource
	//U3VCPEIRMAvailable
	//U3VCPIIDC2Available
	//U3VCPSIRMAvailable
	//U3VCurrentSpeed
	//U3VDeviceCapability
	//U3VMaxAcknowledgeTransferLength
	//U3VMaxCommandTransferLength
	//U3VMaxDeviceResponseTime
	//U3VNumberOfStreamChannels
	//U3VVersionMajor
	//U3VVersionMinor
	//USB3LinkRecoveryCount
	//UserNameAvailable
	//UserOutputSelector
	//UserOutputValue
	//UserSetCurrent
	//UserSetDefault
	//UserSetDefaultSelector
	//UserSetLoad
	//UserSetSave
	//UserSetSelector
	//VideoMode
	//WidthMax
	//WrittenLengthFieldSupported

}
