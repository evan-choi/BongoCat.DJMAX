using System;
using System.Windows.Markup;

namespace BongoCat.DJMAX.Setting.Converters
{
    internal abstract class MarkupSupport : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
