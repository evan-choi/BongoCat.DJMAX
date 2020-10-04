using BongoCat.DJMAX.Common.Serialization;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Common.Input
{
    public sealed class InputSetting4 : IInputSetting
    {
        [JsonProperty("TRACK 1")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys Track1 { get; set; }

        [JsonProperty("TRACK 2")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys Track2 { get; set; }

        [JsonProperty("TRACK 3")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys Track3 { get; set; }

        [JsonProperty("TRACK 4")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys Track4 { get; set; }

        [JsonProperty("L SIDE TRACK")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys LeftSideTrack { get; set; }

        [JsonProperty("R SIDE TRACK")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys RightSideTrack { get; set; }

        public InputKeys[] GetKeys()
        {
            return new[]
            {
                LeftSideTrack,
                Track1,
                Track2,
                Track3,
                Track4,
                RightSideTrack
            };
        }
    }
}
