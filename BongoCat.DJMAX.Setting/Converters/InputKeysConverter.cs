using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using BongoCat.DJMAX.Common;
using BongoCat.DJMAX.Common.Utilities;

namespace BongoCat.DJMAX.Setting.Converters
{
    internal sealed class InputKeysConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is InputKeys keys)
                return InputKeysUtility.ToFriendlyString(keys);

            return InputKeysUtility.ToFriendlyString(InputKeys.None);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue)
                return InputKeysUtility.FromFriendlyString(strValue);

            return InputKeys.None;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
