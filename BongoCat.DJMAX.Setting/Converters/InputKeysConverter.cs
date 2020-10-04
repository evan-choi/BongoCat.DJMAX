using System.Globalization;
using BongoCat.DJMAX.Common;
using BongoCat.DJMAX.Common.Utilities;

namespace BongoCat.DJMAX.Setting.Converters
{
    internal sealed class InputKeysConverter : ValueConverterBase<InputKeys, string>
    {
        public override string Convert(InputKeys value, object parameter, CultureInfo culture)
        {
            return InputKeysUtility.ToFriendlyString(value);
        }

        public override InputKeys ConvertBack(string value, object parameter, CultureInfo culture)
        {
            return InputKeysUtility.FromFriendlyString(value);
        }
    }
}
