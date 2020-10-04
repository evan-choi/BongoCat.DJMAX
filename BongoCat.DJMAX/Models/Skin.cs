using System;
using System.Drawing;
using System.IO;
using System.Linq;
using BongoCat.DJMAX.Common;

namespace BongoCat.DJMAX.Models
{
    public class Skin
    {
        public Bitmap Background { get; }

        public Bitmap[] Effects { get; }

        public Skin(Bitmap background, Bitmap[] effects)
        {
            Background = background;
            Effects = effects;
        }

        public static Skin FromDirectory(Buttons buttons, string directory, Skin defaultSkin = null)
        {
            string keyName;
            int effectCount;

            switch (buttons)
            {
                case Buttons._4:
                    keyName = "4k";
                    effectCount = 6;
                    break;

                case Buttons._5:
                    keyName = "5k";
                    effectCount = 8;
                    break;

                case Buttons._6:
                    keyName = "6k";
                    effectCount = 8;
                    break;

                case Buttons._8:
                    keyName = "8k";
                    effectCount = 10;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(buttons), buttons, null);
            }

            if (defaultSkin?.Effects != null && defaultSkin.Effects.Length != effectCount)
                throw new ArgumentException(nameof(defaultSkin));

            var backgroundFile = Path.Combine(directory, $"bg_{keyName}.png");
            var effectFiles = Enumerable.Range(0, effectCount)
                .Select(i => Path.Combine(directory, $"fx_{keyName}_{i}.png"))
                .ToArray();

            var background = GetBitmap(backgroundFile) ?? defaultSkin?.Background ?? throw new Exception($"{Path.GetFileName(backgroundFile)} not found.");

            var effects = effectFiles
                .Select((x, i) => GetBitmap(x) ?? defaultSkin?.Effects[i] ?? throw new Exception($"{Path.GetFileName(x)} not found."))
                .ToArray();

            return new Skin(background, effects);
        }

        private static Bitmap GetBitmap(string file)
        {
            return !File.Exists(file) ? null : new Bitmap(file);
        }
    }
}