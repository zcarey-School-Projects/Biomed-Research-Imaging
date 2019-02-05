using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearch.Flir;
using UndergradResearch.Flir.Nodes;
using UndergradResearch.UI.Options;
using UndergradResearch.Util;

namespace UndergradResearch.UI.OptionsCategories.Options {
	public class ExposureUI : IOptionsUI {

		public ExposureUI(CameraOptionsUI options, OptionsPanel panel) : base(options, panel, null) {
		}

		protected override List<IOptionEntry> generateEntries(CameraOptionsUI options, string libraryVersion) {
			List<IOptionEntry> entries = new List<IOptionEntry>();

			OptionsCategory ExposureCategory = new OptionsCategory("Exposure");
			entries.Add(ExposureCategory);

			EnumEntry<ExposureAutoEnums> ExposureAutoEntry = new EnumEntry<ExposureAutoEnums>("Auto Exposure", ExposureAutoEnums.Continuous, ExposureAutoEnums.NUM_EXPOSUREAUTO, new Property<FlirProperties, EnumNode<ExposureAutoEnums>>(nameof(options.FakeProperties.ExposureAuto)), options.Stream);
			ExposureAutoEntry.Parent = ExposureCategory;

			FloatEntry UpperExposureEntry = new FloatEntry("  - Upper Limit", new Property<FlirProperties, FloatNode>(nameof(options.FakeProperties.ExposureAutoUpperLimit)), options.Stream);
			UpperExposureEntry.Parent = ExposureCategory;

			FloatEntry LowerExposureEntry = new FloatEntry("  - Lower Limit", new Property<FlirProperties, FloatNode>(nameof(options.FakeProperties.ExposureAutoLowerLimit)), options.Stream);
			LowerExposureEntry.Parent = ExposureCategory;

			FloatEntry ExposureTimeEntry = new FloatEntry("Exposure Time", new Property<FlirProperties, FloatNode>(nameof(options.FakeProperties.ExposureTime)), options.Stream);
			ExposureTimeEntry.Parent = ExposureCategory;

			FloatEntry ExposureTimeAbsEntry = new FloatEntry("Absolute Exposure Time", new Property<FlirProperties, FloatNode>(nameof(options.FakeProperties.ExposureTimeAbs)), options.Stream);
			ExposureTimeAbsEntry.Parent = ExposureCategory;

			return entries;
			/*
			 ExposureMode = new EnumNode<ExposureModeEnums>(camera, "ExposureMode");
			 */
		}
	}
}
