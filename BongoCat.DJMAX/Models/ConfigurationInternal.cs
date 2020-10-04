using System.IO;
using System.Text;
using BongoCat.DJMAX.Common;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Models
{
    // TOOD: refactoring
    internal sealed class ConfigurationInternal : Configuration
    {
        [JsonIgnore]
        public Skin SkinInternal { get; set; }

        public new static ConfigurationInternal FromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            var json = File.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<ConfigurationInternal>(json);
        }
    }
}
