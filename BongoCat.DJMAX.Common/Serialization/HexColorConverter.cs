using System;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Common.Serialization
{
    internal sealed class HexColorConverter : JsonConverter<Color?>
    {
        public override void WriteJson(JsonWriter writer, Color? value, JsonSerializer serializer)
        {
            if (value.HasValue)
                writer.WriteValue(value.Value.ToString());
            else
                writer.WriteNull();
        }

        public override Color? ReadJson(JsonReader reader, Type objectType, Color? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String && Color.TryParse((string)reader.Value, out var color))
                return color;

            return null;
        }
    }
}
