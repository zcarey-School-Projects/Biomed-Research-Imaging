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
	public class FlirCamera : IDisposable{

		private IManagedCamera camera;
		private bool initialized = false;
		private bool streaming = false;

		public FlirCamera(IManagedCamera cam) {
			this.camera = cam;
			camera.Init();
			if (camera.IsInitialized()) {
				initialized = true;
				Console.WriteLine("Camera initialized: " + camera.DeviceModelName);
			} else {
				Console.WriteLine("Camera could not be initialized.");
			}
		}

		public void Dispose() {
			streaming = false;
			initialized = false;
			camera.Dispose();
		}

		public void StartStream() {
			camera.BeginAcquisition();
			streaming = true;
		}

		public void EndStream() {
			streaming = false;
			camera.EndAcquisition();
		}

		public Image<Bgr, byte> GetNextImage() {
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

		private bool trySetNodeValue(string nodeName, string nodeValue) {
			try {
				IEnum node = camera.GetNodeMap().GetNode<IEnum>(nodeName);
				node.Value = nodeValue;
				return true;
			}catch(SpinnakerException e) {
				Console.WriteLine("Could not set node '{0}' to value '{1}'.", nodeName, nodeValue);
				return false;
			}
		}

		public bool SetAcquisitionMode(AcquisitionModeEnums mode) { return trySetNodeValue("AcquisitionNode", mode.ToString()); }
		public bool SetPixelFormat(PixelFormatEnums format) { return trySetNodeValue("PixelFormat", format.ToString()); }
		public bool SetTestPatternGeneratorSelector(TestPatternGeneratorSelectorEnums gen) { return trySetNodeValue("TestPatternGeneratorSelector", gen.ToString()); }
		public bool SetTestPattern(TestPatternEnums pattern) { return trySetNodeValue("TestPattern", pattern.ToString()); }
		public bool SetGainSelector(GainSelectorEnums gain) { return trySetNodeValue("GainSelector", gain.ToString()); }
		public bool SetGainAuto(GainAutoEnums gain) { return trySetNodeValue("GainAuto", gain.ToString()); }
		//Gain
		//AutoGainLowerLimit
		//AutoGainUpperLimit
		//BlackLevel
		//BlackLevelEnabled
		//BlackLevelAuto
		//Gamma
		//GammaEnabled
		//Sharpness
		//SharpnessEnabled
		//SharpnessAuto
		//Hue
		//HueEnabled
		//HueAuto
		//Saturation
		//SaturationEnabled
		//SaturationAuto
		//BalanceWhiteAuto
		//BalanceRatioSelector
		//BalanceRatio
		//PixelFormat
		//DeviceVendorName
		//DeviceModelName
		//DeviceVersion
		//DeviceSerialNumber
		//DeviceID
		//DeviceUserID
		//DeviceGenCpVersionMajor
		//DeviceGenCPVersionMinor
		//DeviceFamilyName
		//U3VDeviceCapability
		//Timestamp
		//TimestampLatch
		//TimestampIncrement
		//pgrSensorDescription
		//DeviceSVNVersion
		//DeviceFirmwareVersion
		//DeviceScanType
		//DeviceTemperature
		//DeviceReset
		//pgrDeviceUptime
		//AutoFunctionAOIsControl
		//AutoFunctionAOIWidth
		//AutoFunctionAOIHeight
		//AutoFunctionAOIOffsetX
		//AutoFunctionAOIOffsetY
		//pgrDevicePowerSupplySelector
		//pgrPowerSourcePresent
		//pgrPowerSupplyEnable
		//pgrPowerSupplyVoltage
		//pgrPowerSupplyCurrent
		//DeviceMaxThroughput
		//DeviceLinkThroughputLimit
		//TestPendingAck
		//UserNameAvailable
		//AccessPrivilegeAvailable
		//MessageChannelSupported
		//TimestampSupported
		//StringEncoding
		//FamilyRegisterAvailable
		//SBRMSupported
		//EndianessRegistersSupported
		//WrittenLengthFieldSupported
		//Width
		//Height
		//TriggerSelector
		//TriggerMode
		//TriggerSoftware
		//TriggerSource
		//TriggerActivation
		//TriggerOverlap
		//TriggerDelay
		//TriggerDelayEnabled
		//ExposureMode
		//ExposureAuto
		//ExposureTime
		//ExposureTimeAbs
		//AutoExposureTimeLowerLimit
		//AutoExposureTimeUpperLimit
		//pgrExposureCompensationAuto
		//pgrExposureCompensation
		//pgrAutoExposureCompensationLowerLimit
		//pgrAutoExposureCompensationUpperLimit
		//AcquisitionMode
		//AcquisitionStart
		//AcquisitionStop
		//AcquisitionFrameRateAuto
		//AcquisitionFrameRateEnabled
		//AcquisitionFrameRate
		//AcquisitionFrameCount
		//AcquisitionStatusSelector
		//AcquisitionStatus
		//SingleFrameAcquisitionMode
		//LineMode
		//PixelCoding
		//OnBoardColorProcessEnabled
		//OffsetX
		//OffsetY
		//SensorWidth
		//SensorHeight
		//WidthMax
		//HeightMax
		//VideoMode
		//BinningHorizontal
		//BinningVertical
		//DecimationHorizontal
		//DecimationVertical
		//ReverseX
		//PixelSize
		//PixelColorFilter
		//PixelDynamicRangeMin
		//PixelDynamicRangeMax
		//TestImageSelector
		//TestPattern
		//PixelDefectControl
		//pgrDefectPixelCorrectionEnable
		//pgrDefectPixelCorrectionTestMode
		//pgrCurrentCorrectedPixelCount
		//pgrCurrentCorrectedPixelIndex
		//pgrCurrentCorrectedPixelOffsetX
		//pgrCurrentCorrectedPixelOffsetY
		//pgrCurrentCorrectedPixelSave
		//DecimationHorizontalLocked
		//UserSetCurrent
		//UserSetSelector
		//UserSetLoad
		//UserSetSave
		//UserSetDefault
		//UserSetDefaultSelector
		//DataFlashPageSize
		//DataFlashPageCount
		//ActivePageNumber
		//ActivePageOffset
		//ActivePageValue
		//ActivePageSave
		//DataFlashBaseAddress
		//LineSelector
		//LineSource
		//LineInverter
		//StrobeDelay
		//StrobeDuration
		//LineDebouncerTimeRaw
		//LineStatus
		//LineStatusAll
		//UserOutputSelector
		//UserOutputValue
		//LUTSelector
		//LUTEnable
		//LUTIndex
		//LUTValue
		//	LUTValueAll
		//U3VMaxDeviceResponseTime
		//U3VVersionMajor
		//U3VVersionMinor
		//U3VCPSIRMAvailable
		//U3VCPEIRMAvailable
		//U3VCPIIDC2Available
		//U3VMaxCommandTransferLength
		//U3VMaxAcknowledgeTransferLength
		//U3VNumberOfStreamChannels
		//U3VCurrentSpeed
		//PayloadSize
		//TransmitFailureCount
		//TransmitFailureCountReset
		//USB3LinkRecoveryCount
		//ChunkModeActive
		//ChunkSelector
		//ChunkEnable
		//ChunkImage
		//ChunkCRC
		//ChunkFrameCounter
		//ChunkOffsetX
		//ChunkOffsetY
		//ChunkWidth
		//ChunkHeight
		//ChunkExposureTime
		//ChunkGain
		//ChunkBlackLevel
		//ChunkPixelFormat
		//ChunkPixelDynamicRangeMin
		//ChunkPixelDynamicRangeMax
		//ChunkTimestamp
		//EventSelector
		//EventNotification
		//EventAcquisitionStartData
		//EventAcquisitionEndData
		//EventExposureEndData
		//TriggerEventTest
		//EventTestData
		//EventExposureEnd
		//EventExposureEndTimestamp
		//EventExposureEndFrameID
		//EventAcquisitionEnd
		//EventAcquisitionEndTimestamp
		//EventAcquisitionEndFrameID
		//EventAcquisitionStart
		//EventAcquisitionStartTimestamp
		//EventAcquisitionStartFrameID
		//EventAcquisitionEndPort
		//EventExposureStartPort
		//EventExposureEndPort
		//EventExposureStart
		//EventExposureStartTimestamp
		//EventExposureStartFrameID
		//EventTest
		//EventTestTimestamp
		//EventTestFrameID
		//ParameterSelector
		//RemoveLimits
		//StreamInformation
		//BufferHandlingControl
		//StreamDiagnostics
		//StreamID
		//StreamType
		//StreamTotalBufferCount
		//StreamBufferCountManual
		//StreamBufferCountResult
		//StreamBufferCountMax
		//StreamBufferCountMode
		//StreamDefaultBufferCount
		//StreamDefaultBufferCountMax
		//StreamDefaultBufferCountMode
		//StreamBufferHandlingMode
		//StreamCRCCheckEnable
		//StreamBlockTransferSize
		//StreamFailedBufferCount
		//StreamBufferUnderrunCount
		//StreamBufferCountAuto
	}

}
