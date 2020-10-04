using System;
using System.IO;
using System.Text;
using BongoCat.DJMAX.Common.Input;
using BongoCat.DJMAX.Common.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BongoCat.DJMAX.Common
{
    public class Configuration
    {
        [JsonProperty("version", Required = Required.Always)]
        [JsonConverter(typeof(VersionConverter))]
        public Version Version { get; set; }

        [JsonProperty("skin")]
        public string Skin { get; set; }

        [JsonProperty("refreshRate")]
        public int? RefreshRate { get; set; }

        [JsonProperty("background")]
        [JsonConverter(typeof(HexColorConverter))]
        public Color? Background { get; set; }

        [JsonProperty("mode", Required = Required.Always)]
        [JsonConverter(typeof(ButtonsConverter))]
        public Buttons Buttons { get; set; }

        [JsonProperty("4B")]
        public InputSetting4 Input4 { get; set; }

        [JsonProperty("5B")]
        public InputSetting5 Input5 { get; set; }

        [JsonProperty("6B")]
        public InputSetting6 Input6 { get; set; }

        [JsonProperty("8B")]
        public InputSetting8 Input8 { get; set; }

        public Configuration()
        {
            Version = typeof(Configuration).Assembly.GetName().Version;
        }

        public void Save(string path)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, json, Encoding.UTF8);
        }

        public static Configuration FromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            var json = File.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Configuration>(json);
        }
    }
}
