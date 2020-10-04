using System;
using System.IO;
using System.Windows.Forms;
using BongoCat.DJMAX.Common;
using BongoCat.DJMAX.Common.Input;
using BongoCat.DJMAX.Models;
using Newtonsoft.Json;

namespace BongoCat.DJMAX
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ConfigurationInternal configuration = null;
            var defaultConfiguration = CreateDefaultConfiguration();

            WriteDefaultSkins();

            try
            {
                configuration = ConfigurationInternal.FromFile(BCEnvironment.ConfigFile);

                if (string.IsNullOrEmpty(configuration.Skin) || "default".Equals(configuration.Skin, StringComparison.OrdinalIgnoreCase))
                {
                    configuration.Skin = "Lisrim";
                }

                BlendConfiguration(configuration, defaultConfiguration);
                ValidateConfiguration(configuration);
            }
            catch (FileNotFoundException)
            {
                // Skip
            }
            catch (JsonException e)
            {
                if (!e.Message.StartsWith("Required property 'version' not found"))
                {
                    MessageBox.Show("Invalid config format.", "BongoCat DJMAX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "BongoCat DJMAX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            configuration ??= defaultConfiguration;
            configuration.Save(BCEnvironment.ConfigFile);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(configuration));
        }

        private static void WriteDefaultSkins()
        {
            var dir = Path.Combine(BCEnvironment.SkinDirectory, "Lisrim");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var keyNames = new[] { "4k", "5k", "6k", "8k" };
            var resKeys = new[] { "4k", "6k", "6k", "8k" };
            var resFxCounts = new[] { 6, 8, 8, 10 };

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

        private static ConfigurationInternal CreateDefaultConfiguration()
        {
            return new ConfigurationInternal
            {
                RefreshRate = 60,
                Background = new Color(255, 255, 255),
                Buttons = Buttons._6,
                Skin = "Lisrim",
                Input4 = new InputSetting4
                {
                    Track1 = InputKeys.A,
                    Track2 = InputKeys.S,
                    Track3 = InputKeys.Semicolon,
                    Track4 = InputKeys.Quote,
                    LeftSideTrack = InputKeys.LShift,
                    RightSideTrack = InputKeys.RShift
                },
                Input5 = new InputSetting5
                {
                    Track1 = InputKeys.A,
                    Track2 = InputKeys.S,
                    Track3 = InputKeys.D,
                    Track4 = InputKeys.L,
                    Track5 = InputKeys.Semicolon,
                    Track6 = InputKeys.Quote,
                    LeftSideTrack = InputKeys.LShift,
                    RightSideTrack = InputKeys.RShift
                },
                Input6 = new InputSetting6
                {
                    Track1 = InputKeys.A,
                    Track2 = InputKeys.S,
                    Track3 = InputKeys.D,
                    Track4 = InputKeys.L,
                    Track5 = InputKeys.Semicolon,
                    Track6 = InputKeys.Quote,
                    LeftSideTrack = InputKeys.LShift,
                    RightSideTrack = InputKeys.RShift
                },
                Input8 = new InputSetting8
                {
                    Track1 = InputKeys.A,
                    Track2 = InputKeys.S,
                    Track3 = InputKeys.D,
                    Track4 = InputKeys.L,
                    Track5 = InputKeys.Semicolon,
                    Track6 = InputKeys.Quote,
                    TrackLeft = InputKeys.C,
                    TrackRight = InputKeys.Comma,
                    LeftSideTrack = InputKeys.LShift,
                    RightSideTrack = InputKeys.RShift
                }
            };
        }

        private static void BlendConfiguration(Configuration target, Configuration source)
        {
            target.RefreshRate ??= source.RefreshRate;
            target.Background ??= source.Background;
            target.Input4 ??= source.Input4;
            target.Input5 ??= source.Input5;
            target.Input6 ??= source.Input6;
            target.Input8 ??= source.Input8;
        }

        private static void ValidateConfiguration(Configuration config)
        {
            if (config.RefreshRate < 1 || config.RefreshRate > 1000)
                throw new Exception("RefreshRate must be between 1 and 1000.");
        }
    }
}
