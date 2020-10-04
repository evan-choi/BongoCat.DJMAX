using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BongoCat.DJMAX.Common;

namespace BongoCat.DJMAX.Setting.Converters
{
    internal sealed class FriendlyColorNameConverter : ValueConverterBase<Color, string>
    {
        private readonly Dictionary<Color, string> _mapping = new Dictionary<Color, string>
        {
            [new Color(255, 255, 255)] = "White",
            [new Color(255, 0, 0)] = "Red",
            [new Color(0, 255, 0)] = "Green",
            [new Color(0, 0, 255)] = "Blue"
        };

        public override string Convert(Color value, object parameter, CultureInfo culture)
        {
            return _mapping.TryGetValue(value, out var name) ? name : $"{value}";
        }

        public override Color ConvertBack(string value, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value))
                return _mapping.Keys.First();

            foreach (KeyValuePair<Color, string> kv in _mapping.Where(kv => kv.Value == value))
            {
                return kv.Key;
            }

            if (Color.TryParse(value, out var color))
                return color;

            throw new Exception();
        }
    }
}
