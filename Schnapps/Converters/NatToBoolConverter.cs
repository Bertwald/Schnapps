using System.Globalization;

namespace Schnapps.Converters {

    // A version of this with two way conversions exist in .NET MAUI Community Toolkit as IntToBoolConverter,
    // but sometimes it is good to have crashing behaviour when testing application,
    // and the ability get true on negative values is not logical (even if it will never happen)
    public class NatToBoolConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is not null && (int)value > 0 ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            // We generally do not want to convert bools to ints, if there is a two way conversion a design error has most likely occured
            throw new NotSupportedException();
        }
    }
}
