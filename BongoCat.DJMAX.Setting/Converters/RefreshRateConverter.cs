using System.Globalization;

namespace BongoCat.DJMAX.Setting.Converters
{
    internal sealed class RefreshRateConverter : ValueConverterBase<int, string>
    {
        public override string Convert(int value, object parameter, CultureInfo culture)
        {
            return $"{value} fps";
        }

        public override int ConvertBack(string value, object parameter, CultureInfo culture)
        {
            return int.Parse(value[..^4]);
        }
    }
}
