using System;

namespace BongoCat.DJMAX.Common
{
    public readonly struct Color
    {
        public byte Red => (byte)((ulong)(value >> 16) & byte.MaxValue);

        public byte Green => (byte)((ulong)(value >> 8) & byte.MaxValue);

        public byte Blue => (byte)((ulong)value & byte.MaxValue);

        private readonly long value;

        public Color(byte r, byte g, byte b)
        {
            value = (long)(uint)(r << 16 | g << 8 | b | 255 << 24) & uint.MaxValue;
        }

        public override string ToString()
        {
            return $"{Red:X2}{Green:X2}{Blue:X2}";
        }

        public static bool TryParse(string value, out Color color)
        {
            int offset = value[0] == '#' ? 1 : 0;

            string rPart;
            string gPart;
            string bPart;

            switch (value.Length)
            {
                case 8:
                    offset += 2;
                    goto case 6;

                case 3:
                    rPart = value[offset + 0].ToString();
                    gPart = value[offset + 1].ToString();
                    bPart = value[offset + 2].ToString();
                    break;

                case 6:
                    rPart = value[offset..2];
                    gPart = value[(offset + 2)..(offset + 4)];
                    bPart = value[(offset + 4)..(offset + 6)];
                    break;

                default:
                    color = default;
                    return false;
            }

            if (!TryConvertToByte(rPart, out var r) ||
                !TryConvertToByte(gPart, out var g) ||
                !TryConvertToByte(bPart, out var b))
            {
                color = default;
                return false;
            }

            color = new Color(r, g, b);
            return true;
        }

        private static bool TryConvertToByte(string value, out byte result)
        {
            try
            {
                result = Convert.ToByte(value, 16);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }
    }
}
