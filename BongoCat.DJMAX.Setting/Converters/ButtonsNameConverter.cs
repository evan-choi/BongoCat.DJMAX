using System;
using System.Globalization;
using BongoCat.DJMAX.Common;

namespace BongoCat.DJMAX.Setting.Converters
{
    internal sealed class ButtonsNameConverter : ValueConverterBase<Buttons, string>
    {
        public override string Convert(Buttons value, object parameter, CultureInfo culture)
        {
            return $"{value.ToString()[1]}B TUNES";
        }

        public override Buttons ConvertBack(string value, object parameter, CultureInfo culture)
        {
            return (Buttons)Enum.Parse(typeof(Buttons), $"_{value[0]}");
        }
    }
}
