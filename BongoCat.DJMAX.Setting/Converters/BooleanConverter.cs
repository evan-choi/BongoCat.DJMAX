using System;
using System.Globalization;

namespace BongoCat.DJMAX.Setting.Converters
{
    internal sealed class BooleanConverter : ValueConverterBase<bool, string>
    {
        public override string Convert(bool value, object parameter, CultureInfo culture)
        {
            return value ? "On" : "Off";
        }

        public override bool ConvertBack(string value, object parameter, CultureInfo culture)
        {
            return "On".Equals(value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
