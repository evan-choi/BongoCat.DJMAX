using BongoCat.DJMAX.Common.Serialization;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Common.Input
{
    public sealed class InputSetting8 : IInputSetting
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

        [JsonProperty("TRACK 5")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys Track5 { get; set; }

        [JsonProperty("TRACK 6")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys Track6 { get; set; }

        [JsonProperty("TRACK L")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys TrackLeft { get; set; }

        [JsonProperty("TRACK R")]
        [JsonConverter(typeof(InputKeysConverter))]
        public InputKeys TrackRight { get; set; }

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
                TrackLeft,
                TrackRight,
                Track4,
                Track5,
                Track6,
                RightSideTrack
            };
        }
    }
}
