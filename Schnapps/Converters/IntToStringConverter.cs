using System.Globalization;

namespace Schnapps.Converters {
    // Is needed when we have default value with a non nullable type, by allowing nullability on type in viewmodel.
    // The view will want an empty string and not a null (which would crash the application)
    public class IntToStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value?.ToString()??"0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return int.Parse(value as string);
        }
    }
}
