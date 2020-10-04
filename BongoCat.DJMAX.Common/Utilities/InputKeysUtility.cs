using System;
using System.Collections.Generic;
using System.Linq;

namespace BongoCat.DJMAX.Common.Utilities
{
    public static class InputKeysUtility
    {
        private static readonly Dictionary<InputKeys, string[]> _mapping =
            new Dictionary<InputKeys, string[]>
            {
                [InputKeys.Left] = new[] { "LEFT" },
                [InputKeys.Up] = new[] { "UP" },
                [InputKeys.Right] = new[] { "RIGHT" },
                [InputKeys.Down] = new[] { "DOWN" },
                [InputKeys.A] = new[] { "A" },
                [InputKeys.B] = new[] { "B" },
                [InputKeys.C] = new[] { "C" },
                [InputKeys.D] = new[] { "D" },
                [InputKeys.E] = new[] { "E" },
                [InputKeys.F] = new[] { "F" },
                [InputKeys.G] = new[] { "G" },
                [InputKeys.H] = new[] { "H" },
                [InputKeys.I] = new[] { "I" },
                [InputKeys.J] = new[] { "J" },
                [InputKeys.K] = new[] { "K" },
                [InputKeys.L] = new[] { "L" },
                [InputKeys.N] = new[] { "N" },
                [InputKeys.M] = new[] { "M" },
                [InputKeys.O] = new[] { "O" },
                [InputKeys.P] = new[] { "P" },
                [InputKeys.Q] = new[] { "Q" },
                [InputKeys.R] = new[] { "R" },
                [InputKeys.S] = new[] { "S" },
                [InputKeys.T] = new[] { "T" },
                [InputKeys.U] = new[] { "U" },
                [InputKeys.V] = new[] { "V" },
                [InputKeys.W] = new[] { "W" },
                [InputKeys.X] = new[] { "X" },
                [InputKeys.Y] = new[] { "Y" },
                [InputKeys.Z] = new[] { "Z" },
                [InputKeys.D1] = new[] { "1" },
                [InputKeys.D2] = new[] { "2" },
                [InputKeys.D3] = new[] { "3" },
                [InputKeys.D4] = new[] { "4" },
                [InputKeys.D5] = new[] { "5" },
                [InputKeys.D6] = new[] { "6" },
                [InputKeys.D7] = new[] { "7" },
                [InputKeys.D8] = new[] { "8" },
                [InputKeys.D9] = new[] { "9" },
                [InputKeys.D0] = new[] { "0" },
                [InputKeys.DMinus] = new[] { "-" },
                [InputKeys.DPlus] = new[] { "+" },
                [InputKeys.NumLock] = new[] { "NUM LOCK" },
                [InputKeys.NumSlash] = new[] { "Num/" },
                [InputKeys.NumMultiply] = new[] { "Num*" },
                [InputKeys.NumMinus] = new[] { "Num-" },
                [InputKeys.NumPlus] = new[] { "Num+" },
                [InputKeys.NumPeriod] = new[] { "Num." },
                [InputKeys.Num1] = new[] { "Num1" },
                [InputKeys.Num2] = new[] { "Num2" },
                [InputKeys.Num3] = new[] { "Num3" },
                [InputKeys.Num4] = new[] { "Num4" },
                [InputKeys.Num5] = new[] { "Num5" },
                [InputKeys.Num6] = new[] { "Num6" },
                [InputKeys.Num7] = new[] { "Num7" },
                [InputKeys.Num8] = new[] { "Num8" },
                [InputKeys.Num9] = new[] { "Num9" },
                [InputKeys.Num0] = new[] { "Num0" },
                [InputKeys.ScrollLock] = new[] { "SCROLL LOCK" },
                [InputKeys.OpenBrackets] = new[] { "[" },
                [InputKeys.CloseBrackets] = new[] { "]" },
                [InputKeys.Slash] = new[] { "/" },
                [InputKeys.BackSlash] = new[] { "\\" },
                [InputKeys.Semicolon] = new[] { ";" },
                [InputKeys.Quote] = new[] { "'" },
                [InputKeys.BackQuote] = new[] { "`" },
                [InputKeys.Comma] = new[] { "," },
                [InputKeys.Period] = new[] { "." },
                [InputKeys.Space] = new[] { "SPACE" },
                [InputKeys.BackSpace] = new[] { "BACK SPACE" },
                [InputKeys.Tab] = new[] { "TAB" },
                [InputKeys.CapsLock] = new[] { "CPAS LOCK" },
                [InputKeys.LShift] = new[] { "LEFT SHIFT" },
                [InputKeys.RShift] = new[] { "RIGHT SHIFT" },
                [InputKeys.LControl] = new[] { "LEFT CONTROL" },
                [InputKeys.LWindow] = new[] { "LEFT WINDOW" },
                [InputKeys.RWindow] = new[] { "RIGHT WINDOW" },
                [InputKeys.LAlt] = new[] { "LEFT ALT" },
                [InputKeys.RAlt] = new[] { "RIGHT ALT", "Hangeul" },
            };

        public static string ToFriendlyString(InputKeys value)
        {
            if (_mapping.TryGetValue(value, out string[] result))
                return result[0];

            return nameof(InputKeys.None);
        }

        public static InputKeys FromFriendlyString(string value)
        {
            foreach (KeyValuePair<InputKeys, string[]> kv in _mapping)
            {
                if (kv.Value.Contains(value, StringComparer.OrdinalIgnoreCase))
                    return kv.Key;
            }

            return InputKeys.None;
        }

        public static int VirtualKeyFrom(InputKeys keys)
        {
            switch (keys)
            {
                case InputKeys.Left:
                    return 37;

                case InputKeys.Up:
                    return 38;

                case InputKeys.Right:
                    return 39;

                case InputKeys.Down:
                    return 40;

                case InputKeys.A:
                    return 65;

                case InputKeys.B:
                    return 66;

                case InputKeys.C:
                    return 67;

                case InputKeys.D:
                    return 68;

                case InputKeys.E:
                    return 69;

                case InputKeys.F:
                    return 70;

                case InputKeys.G:
                    return 71;

                case InputKeys.H:
                    return 72;

                case InputKeys.I:
                    return 73;

                case InputKeys.J:
                    return 74;

                case InputKeys.K:
                    return 75;

                case InputKeys.L:
                    return 76;

                case InputKeys.N:
                    return 78;

                case InputKeys.M:
                    return 77;

                case InputKeys.O:
                    return 79;

                case InputKeys.P:
                    return 80;

                case InputKeys.Q:
                    return 81;

                case InputKeys.R:
                    return 82;

                case InputKeys.S:
                    return 83;

                case InputKeys.T:
                    return 84;

                case InputKeys.U:
                    return 85;

                case InputKeys.V:
                    return 86;

                case InputKeys.W:
                    return 87;

                case InputKeys.X:
                    return 88;

                case InputKeys.Y:
                    return 89;

                case InputKeys.Z:
                    return 90;

                case InputKeys.D1:
                    return 49;

                case InputKeys.D2:
                    return 50;

                case InputKeys.D3:
                    return 51;

                case InputKeys.D4:
                    return 52;

                case InputKeys.D5:
                    return 53;

                case InputKeys.D6:
                    return 54;

                case InputKeys.D7:
                    return 55;

                case InputKeys.D8:
                    return 56;

                case InputKeys.D9:
                    return 57;

                case InputKeys.D0:
                    return 48;

                case InputKeys.DMinus:
                    return 189;

                case InputKeys.DPlus:
                    return 187;

                case InputKeys.NumLock:
                    return 144;

                case InputKeys.NumSlash:
                    return 111;

                case InputKeys.NumMultiply:
                    return 106;

                case InputKeys.NumMinus:
                    return 109;

                case InputKeys.NumPlus:
                    return 107;

                case InputKeys.NumPeriod:
                    return 110;

                case InputKeys.Num1:
                    return 97;

                case InputKeys.Num2:
                    return 98;

                case InputKeys.Num3:
                    return 99;

                case InputKeys.Num4:
                    return 100;

                case InputKeys.Num5:
                    return 101;

                case InputKeys.Num6:
                    return 102;

                case InputKeys.Num7:
                    return 103;

                case InputKeys.Num8:
                    return 104;

                case InputKeys.Num9:
                    return 105;

                case InputKeys.Num0:
                    return 96;

                case InputKeys.ScrollLock:
                    return 145;

                case InputKeys.OpenBrackets:
                    return 219;

                case InputKeys.CloseBrackets:
                    return 221;

                case InputKeys.Slash:
                    return 191;

                case InputKeys.BackSlash:
                    return 8;

                case InputKeys.Semicolon:
                    return 186;

                case InputKeys.Quote:
                    return 222;

                case InputKeys.BackQuote:
                    return 192;

                case InputKeys.Comma:
                    return 188;

                case InputKeys.Period:
                    return 190;

                case InputKeys.Space:
                    return 32;

                case InputKeys.BackSpace:
                    return 220;

                case InputKeys.Tab:
                    return 9;

                case InputKeys.CapsLock:
                    return 20;

                case InputKeys.LShift:
                    return 160;

                case InputKeys.RShift:
                    return 161;

                case InputKeys.LControl:
                    return 162;

                case InputKeys.LWindow:
                    return 91;

                case InputKeys.RWindow:
                    return 92;

                case InputKeys.LAlt:
                    return 164;

                case InputKeys.RAlt:
                    return 21;

                default:
                    throw new ArgumentOutOfRangeException(nameof(keys), keys, null);
            }

            return 0;
        }
    }
}
