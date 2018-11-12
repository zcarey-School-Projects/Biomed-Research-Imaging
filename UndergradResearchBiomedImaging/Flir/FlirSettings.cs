﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearchBiomedImaging.Flir.Settings;

namespace UndergradResearchBiomedImaging.Flir {
	public class FlirSettings {

		public AcquisitionModeSetting AcquisitionMode { get; private set; }
		public PixelFormatSetting PixelFormat { get; private set; }
		public TestPatternSetting TestPattern { get; private set; }
		public TestPatternGeneratorSelectorSetting TestPatternGeneratorSelector { get; private set; }

		public FlirSettings(FlirCamera camera) {
			AcquisitionMode = new AcquisitionModeSetting(camera);
			PixelFormat = new PixelFormatSetting(camera);
			TestPattern = new TestPatternSetting(camera);
			TestPatternGeneratorSelector = new TestPatternGeneratorSelectorSetting(camera);
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
		//Height
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
		//Width
		//WidthMax
		//WrittenLengthFieldSupported

	}
}