﻿using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Flir.Nodes;
using UndergradResearchBiomedImaging.UI.Options;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.UI.OptionsCategories.Options {
	public class GainUI : IOptionsUI {
		public GainUI(CameraOptionsUI options, OptionsPanel panel) : base(options, panel) {
		}

		protected override List<IOptionEntry> generateEntries(CameraOptionsUI options) {
			List<IOptionEntry> entries = new List<IOptionEntry>();

			OptionsCategory GainCategory = new OptionsCategory("Gain");
			entries.Add(GainCategory);

			FloatEntry GainEntry = new FloatEntry("Gain", new Property<FlirCamera, FloatNode>(nameof(options.FakeProperties.Gain)), options.Input);
			GainEntry.Parent = GainCategory;

			EnumEntry<GainAutoEnums> AutoGainEntry = new EnumEntry<GainAutoEnums>("Auto Gain", GainAutoEnums.Off, GainAutoEnums.NUM_GAINAUTO, new Property<FlirCamera, EnumNode<GainAutoEnums>>(nameof(options.FakeProperties.GainAuto)), options.Input);
			AutoGainEntry.Parent = GainCategory;

			FloatEntry UpperGainEntry = new FloatEntry("  - Upper Limit", new Property<FlirCamera, FloatNode>(nameof(options.FakeProperties.AutoGainUpperLimit)), options.Input);
			UpperGainEntry.Parent = GainCategory;

			FloatEntry LowerGainEntry = new FloatEntry("  - Lower Limit", new Property<FlirCamera, FloatNode>(nameof(options.FakeProperties.AutoGainLowerLimit)), options.Input);
			LowerGainEntry.Parent = GainCategory;

			return entries;
		}
	}
}
