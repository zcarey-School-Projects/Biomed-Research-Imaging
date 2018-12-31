using SpinnakerNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.UI.MenuStrip {
	public class TestPatternMenuStrip : EnumMenuStrip<TestPatternEnums> {

		public TestPatternMenuStrip(ImageStream input) : base(input, TestPatternEnums.NUM_TESTPATTERN, true) {
		}

		protected override string getDisplayText() {
			return "Test Pattern";
		}

		protected override string getEnumName() {
			return "TestPatternEnums";
		}

		protected override void setProperty(FlirCamera camera, TestPatternEnums newValue) {
			camera.Properties.TestPattern.TrySetValue(newValue);
		}
	}
}

//TODO remove
/*
			public void onClick(object sender, EventArgs e) {
				try {
					InputHandler input = form.input;
					if (!(input is FlirCameraInput)) throw new Exception("Could not find FlirCameraInput.");
					FlirCameraInput camInput = (FlirCameraInput)input;
					FlirCamera cam = camInput.Camera;
					if (cam == null) throw new Exception("Null FlirCamera.");
					Type type = cam.Properties.GetType();
					if (type == null) throw new Exception("Null type.");
					PropertyInfo property = type.GetProperty(propertyName);
					if (property == null) throw new Exception("Could not find property.");
					if (!property.CanRead) throw new Exception("Could not read property.");
					object value = property.GetValue(cam, null);
					if (value == null) throw new Exception("Property does not have a value.");
					if (!(value is EnumNode<TEnum>)) throw new Exception("Property value is not of the required type.");
					EnumNode<TEnum> node = (EnumNode<TEnum>)value;
					if (!node.TrySetValue(this.value)) {
						Console.WriteLine("Was unable to set enum value.");
					}
				}catch (Exception ex) {
					Console.WriteLine("\nCould not set value: '" + propertyName + "'.");
					Console.WriteLine(ex.Message);
					Console.WriteLine(ex.StackTrace);
					Console.WriteLine();
				}
			}*/
