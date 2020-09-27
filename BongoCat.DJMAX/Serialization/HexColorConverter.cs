using System;
using System.Drawing;
using BongoCat.DJMAX.Utility;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Serialization
{
    internal class HexColorConverter : JsonConverter<Color?>
    {
        public override void WriteJson(JsonWriter writer, Color? value, JsonSerializer serializer)
        {
            if (value.HasValue)
                writer.WriteValue(ColorUtility.ToHexString(value.Value));
            else
                writer.WriteNull();
        }

        public override Color? ReadJson(JsonReader reader, Type objectType, Color? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                return ColorUtility.FromHexString((string)reader.Value);

            return null;
        }
    }
}