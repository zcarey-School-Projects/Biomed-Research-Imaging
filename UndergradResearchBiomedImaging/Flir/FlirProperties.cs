using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearchBiomedImaging.Flir.Nodes;

namespace UndergradResearchBiomedImaging.Flir {

	public class FlirProperties { 

		public string SpinnakerLibraryVersion { get; private set; }

		public EnumNode<PixelFormatEnums> PixelFormat { get; private set; }
		public EnumNode<AcquisitionModeEnums> AcquisitionMode { get; private set; }
		public EnumNode<TestPatternEnums> TestPattern { get; private set; }
		public EnumNode<TestPatternGeneratorSelectorEnums> TestPatternGeneratorSelector { get; private set; }
		public EnumNode<GainSelectorEnums> GainSelector { get; private set; }
		public EnumNode<GainAutoEnums> GainAuto { get; private set; }
		public FloatNode AutoGainUpperLimit { get; private set; }
		public FloatNode AutoGainLowerLimit { get; private set; }
		public FloatNode Gain { get; private set; }
		public EnumNode<ExposureModeEnums> ExposureMode { get; private set; }
		public EnumNode<ExposureAutoEnums> ExposureAuto { get; private set; }
		public FloatNode ExposureAutoUpperLimit { get; private set; }
		public FloatNode ExposureAutoLowerLimit { get; private set; }
		public FloatNode ExposureTime { get; private set; } //In Milliseconds
		public FloatNode ExposureTimeAbs { get; private set; } //In Millisecond
		public StringNode DeviceVendorName { get; private set; }
		public StringNode DeviceModelName { get; private set; }
		public StringNode DeviceVersion { get; private set; }
		public StringNode DeviceSerialNumber { get; private set; }
		public StringNode DeviceID { get; private set; }
		public StringNode DeviceUserID { get; private set; }
		public StringNode DeviceGenCpVersionMajor { get; private set; }
		public StringNode DeviceGenCPVersionMinor { get; private set; }
		public StringNode DeviceFamilyName { get; private set; }
		public EnumNode<DeviceTemperatureSelectorEnums> DeviceTemperatureSelector { get; private set; }
		public FloatNode DeviceTemperature { get; private set; }
		public IntegerNode Width { get; private set; }
		public IntegerNode Height { get; private set; }

		public FlirProperties(string spinnakerLibraryVersion, IManagedCamera camera) {
			SpinnakerLibraryVersion = spinnakerLibraryVersion;

			PixelFormat = new EnumNode<PixelFormatEnums>(camera, "PixelFormat");
			AcquisitionMode = new EnumNode<AcquisitionModeEnums>(camera, "AcquisitionMode");
			TestPattern = new EnumNode<TestPatternEnums>(camera, "TestPattern");
			TestPatternGeneratorSelector = new EnumNode<TestPatternGeneratorSelectorEnums>(camera, "TestPatternGeneratorSelector");
			GainSelector = new EnumNode<GainSelectorEnums>(camera, "GainSelector");
			GainAuto = new EnumNode<GainAutoEnums>(camera, "GainAuto");
			AutoGainUpperLimit = new FloatNode(camera, "AutoGainUpperLimit");
			AutoGainLowerLimit = new FloatNode(camera, "AutoGainLowerLimit");
			Gain = new FloatNode(camera, "Gain");
			ExposureMode = new EnumNode<ExposureModeEnums>(camera, "ExposureMode");
			ExposureAuto = new EnumNode<ExposureAutoEnums>(camera, "ExposureAuto");
			ExposureAutoUpperLimit = new FloatNode(camera, "AutoExposureTimeUpperLimit");
			ExposureAutoLowerLimit = new FloatNode(camera, "AutoExposureTimeLowerLimit");
			ExposureTime = new FloatNode(camera, "ExposureTime");
			ExposureTimeAbs = new FloatNode(camera, "ExposureTimeAbs");
			DeviceVendorName = new Flir.Nodes.StringNode(camera, "DeviceVendorName");
			DeviceModelName = new Flir.Nodes.StringNode(camera, "DeviceModelName");
			DeviceVersion = new Flir.Nodes.StringNode(camera, "DeviceVersion");
			DeviceSerialNumber = new Flir.Nodes.StringNode(camera, "DeviceSerialNumber");
			DeviceID = new Flir.Nodes.StringNode(camera, "DeviceID");
			DeviceUserID = new Flir.Nodes.StringNode(camera, "DeviceUserID");
			DeviceGenCpVersionMajor = new Flir.Nodes.StringNode(camera, "DeviceGenCpVersionMajor");
			DeviceGenCPVersionMinor = new Flir.Nodes.StringNode(camera, "DeviceGenCpVersionMinor");
			DeviceFamilyName = new Flir.Nodes.StringNode(camera, "DeviceFamilyName");
			DeviceTemperatureSelector = new EnumNode<DeviceTemperatureSelectorEnums>(camera, "DeviceTemperatureSelector");
			DeviceTemperature = new FloatNode(camera, "DeviceTemperature");
			Width = new IntegerNode(camera, "Width");
			Height = new IntegerNode(camera, "Height");
		}

	}

	//TODO properties
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
	//BalanceWhiteAuto-------------------------------------------------------------------------------
	//BalanceRatioSelector
	//BalanceRatio
	//U3VDeviceCapability
	//Timestamp
	//TimestampLatch
	//TimestampIncrement
	//pgrSensorDescription
	//DeviceSVNVersion
	//DeviceFirmwareVersion
	//DeviceScanType
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
	//TriggerSelector
	//TriggerMode
	//TriggerSoftware
	//TriggerSource
	//TriggerActivation
	//TriggerOverlap
	//TriggerDelay
	//TriggerDelayEnabled
	//pgrExposureCompensationAuto
	//pgrExposureCompensation
	//pgrAutoExposureCompensationLowerLimit
	//pgrAutoExposureCompensationUpperLimit
	//AcquisitionMode
	//AcquisitionStart
	//AcquisitionStop
	//AcquisitionFrameRateAuto
	//AcquisitionFrameRateEnabled
	//AcquisitionFrameRate-------------------------------------------------------------------------------
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
