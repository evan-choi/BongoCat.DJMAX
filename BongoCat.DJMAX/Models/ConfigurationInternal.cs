using System.IO;
using System.Text;
using BongoCat.DJMAX.Common;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Models
{
    // TOOD: refactoring
    internal sealed class ConfigurationInternal : Configuration
    {
        private string _path;

        public new void Save(string path)
        {
            _path = path;
            base.Save(path);
        }

        public void Save()
        {
            Save(_path);
        }

        public new static ConfigurationInternal FromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            var json = File.ReadAllText(path, Encoding.UTF8);
            var config = JsonConvert.DeserializeObject<ConfigurationInternal>(json);
            config._path = path;

            return config;
        }
    }
}
