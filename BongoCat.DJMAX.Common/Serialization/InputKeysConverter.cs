using System;
using BongoCat.DJMAX.Common.Utilities;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Common.Serialization
{
    internal sealed class InputKeysConverter : JsonConverter<InputKeys>
    {
        public override void WriteJson(JsonWriter writer, InputKeys value, JsonSerializer serializer)
        {
            writer.WriteValue(InputKeysUtility.ToFriendlyString(value));
        }

        public override InputKeys ReadJson(JsonReader reader, Type objectType, InputKeys existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return InputKeysUtility.FromFriendlyString((string)reader.Value);
        }
    }
}
