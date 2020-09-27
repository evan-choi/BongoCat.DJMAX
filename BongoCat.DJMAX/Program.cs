using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BongoCat.DJMAX.Models;
using BongoCat.DJMAX.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BongoCat.DJMAX
{
    internal static class Program
    {
        private const string ConfigFile = "config.json";

        private static readonly string _skinDirectory = Path.Combine(Environment.CurrentDirectory, "skins");

        [STAThread]
        private static void Main()
        {
            Configuration configuration;
            var defaultConfiguration = CreateDefaultConfiguration();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters =
                {
                    new HexColorConverter(),
                    new ButtonsStringConverter(),
                    new StringEnumConverter()
                }
            };

            WriteDefaultSkins();

            try
            {
                if (!File.Exists(ConfigFile))
                    throw new FileNotFoundException();

                var json = File.ReadAllText(ConfigFile, Encoding.UTF8);
                configuration = JsonConvert.DeserializeObject<Configuration>(json, jsonSerializerSettings) ??
                                throw new JsonException();

                if (string.IsNullOrEmpty(configuration.SkinName) || "default".Equals(configuration.SkinName, StringComparison.OrdinalIgnoreCase))
                {
                    configuration.SkinName = "Lisrim";
                }

                BlendConfiguration(configuration, defaultConfiguration);
                ValidateConfiguration(configuration);
            }
            catch (FileNotFoundException)
            {
                configuration = defaultConfiguration;

                var json = JsonConvert.SerializeObject(configuration, Formatting.Indented, jsonSerializerSettings);
                File.WriteAllText(ConfigFile, json, Encoding.UTF8);
            }
            catch (JsonException)
            {
                MessageBox.Show("Invalid config format.", "BongoCat DJMAX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "BongoCat DJMAX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var skinDir = Path.Combine(_skinDirectory, configuration.SkinName);
                configuration.Skin = Skin.FromDirectory(configuration.Buttons, skinDir);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "BongoCat DJMAX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(configuration));
        }

        private static void WriteDefaultSkins()
        {
            var dir = Path.Combine(_skinDirectory, "Lisrim");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var keyNames = new[] {"4k", "5k", "6k", "8k"};
            var resKeys = new[] { "4k", "6k", "6k", "8k" };
            var resFxCounts = new[] {6, 8, 8, 10};

            for (var i = 0; i < 4; i++)
            {
                WriteToFile($"bg_{resKeys[i]}.png", $"bg_{keyNames[i]}.png");

                for (var j = 0; j < resFxCounts[i]; j++)
                {
                    WriteToFile($"fx_{resKeys[i]}_{j}.png", $"fx_{keyNames[i]}_{j}.png");
                }
            }

            void WriteToFile(string name, string file)
            {
                var path = Path.Combine(dir, file);

                if (File.Exists(path))
                    return;

                var assembly = typeof(Program).Assembly;
                var resourceStream = assembly.GetManifestResourceStream($"BongoCat.DJMAX.Resources.{name}");

                using var fileStream = File.OpenWrite(path);
                resourceStream!.CopyTo(fileStream);
            }
        }

        private static Configuration CreateDefaultConfiguration()
        {
            return new Configuration
            {
                RefreshRate = 60,
                Background = Color.White,
                Buttons = Buttons._6,
                KeySet4 = new KeySet4
                {
                    LeftSide = Keys.LShiftKey,
                    Key1 = Keys.A,
                    Key2 = Keys.S,
                    Key3 = Keys.Oem1,
                    Key4 = Keys.Oem7,
                    RightSide = Keys.RShiftKey
                },
                KeySet5 = new KeySet5
                {
                    LeftSide = Keys.LShiftKey,
                    Key1 = Keys.A,
                    Key2 = Keys.S,
                    Key3First = Keys.D,
                    Key3Second = Keys.L,
                    Key4 = Keys.Oem1,
                    Key5 = Keys.Oem7,
                    RightSide = Keys.RShiftKey
                },
                KeySet6 = new KeySet6
                {
                    LeftSide = Keys.LShiftKey,
                    Key1 = Keys.A,
                    Key2 = Keys.S,
                    Key3 = Keys.D,
                    Key4 = Keys.L,
                    Key5 = Keys.Oem1,
                    Key6 = Keys.Oem7,
                    RightSide = Keys.RShiftKey
                },
                KeySet8 = new KeySet8
                {
                    LeftSide = Keys.CapsLock,
                    Key1 = Keys.Q,
                    Key2 = Keys.W,
                    Key3 = Keys.E,
                    LeftRed = Keys.Space,
                    RightRed = Keys.NumPad0,
                    Key4 = Keys.NumPad7,
                    Key5 = Keys.NumPad8,
                    Key6 = Keys.NumPad9,
                    RightSide = Keys.Add
                },
                SkinName = "Lisrim"
            };
        }

        private static void BlendConfiguration(Configuration target, Configuration source)
        {
            target.RefreshRate ??= source.RefreshRate;
            target.Background ??= source.Background;
            target.KeySet4 ??= source.KeySet4;
            target.KeySet5 ??= source.KeySet5;
            target.KeySet6 ??= source.KeySet6;
            target.KeySet8 ??= source.KeySet8;
        }

        private static void ValidateConfiguration(Configuration config)
        {
            if (config.RefreshRate < 1 || config.RefreshRate > 1000)
                throw new Exception("RefreshRate must be between 1 and 1000.");

            var keySets = new KeySetBase[]
            {
                config.KeySet4,
                config.KeySet5,
                config.KeySet6,
                config.KeySet8
            };

            if (keySets.Any(s => s.GetKeys()?.ToArray() == null))
            {
                throw new Exception("Unknown error in key set.");
            }
        }
    }
}