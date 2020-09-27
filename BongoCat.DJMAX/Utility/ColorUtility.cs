using System;
using System.Drawing;

namespace BongoCat.DJMAX.Utility
{
    public static class ColorUtility
    {
        public static Color FromHexString(string hexString)
        {
            if (hexString[0] == '#')
                hexString = hexString.Substring(1);

            if (hexString.Length != 6)
                throw new Exception("Invalid color format.");

            return Color.FromArgb(
                Convert.ToByte(hexString.Substring(0, 2), 16),
                Convert.ToByte(hexString.Substring(2, 2), 16),
                Convert.ToByte(hexString.Substring(4, 2), 16)
            );
        }

        public static string ToHexString(Color color)
        {
            var alpha = string.Empty;

            if (color.A != 255)
            {
                alpha = color.A.ToString("X2");
            }

            return $"{alpha}{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}