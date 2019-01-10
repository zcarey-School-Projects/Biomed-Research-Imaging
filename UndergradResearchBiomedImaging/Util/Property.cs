using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UndergradResearchBiomedImaging.Util {
	public class Property<ClassType, DataType> where ClassType : class {

		private PropertyInfo property;

		public Property(string SettingName) {
			property = parsePropertyFromName(SettingName);
		}

		public bool TryGet(ClassType obj, ref object readValue) {
			if (property == null) return false;
			try {
				if (!property.CanRead) throw new Exception("Property is not readable.");
				readValue = property.GetValue(obj);
				/*if (value == null) { 
					if (Nullable.GetUnderlyingType(typeof(DataType)) != null) {
						// T is a Nullable<>, Can't tell if caused by an error, or property is supposed to be null.
						readValue = default(DataType); //Since is nullable, will return null.
						return true;
					} else {
						throw new Exception("Value was null, but DataType is not a nullable type.");
					}
				}*/
				//if (!(value is DataType)) throw new Exception("Value is of wrong type.");
				//readValue = (DataType)value;

				return true;
			} catch (Exception e) {
				Console.Error.WriteLine("ERROR: Could not get property '" + property.Name + "': " + e.Message);
				return false;
			}
		}

		public bool TrySet(ClassType obj, DataType value) {
			if (property == null) return false;
			try {
				if (!property.CanWrite) throw new Exception("Property is not writable.");
				property.SetValue(obj, value);

				return true;
			} catch (Exception e) {
				Console.Error.WriteLine("ERROR: Could not set property '" + property.Name + "': " + e.Message);
				return false;
			}
		}

		private static PropertyInfo parsePropertyFromName(string name) {
			Type type = typeof(ClassType);
			if (type == null) {
				Console.Error.WriteLine("ERROR: Could not find property type with name '" + name + "'.");
				return null;
			}
			PropertyInfo property = type.GetProperty(name);
			if (property == null) Console.Error.WriteLine("ERROR: Could not find property with the name '" + name + "' inside of the class '" + type.FullName + "'.");

			return property;
		}

	}
}
