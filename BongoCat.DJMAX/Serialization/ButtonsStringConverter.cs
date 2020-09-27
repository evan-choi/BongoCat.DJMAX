using System;
using BongoCat.DJMAX.Models;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Serialization
{
    internal class ButtonsStringConverter : JsonConverter<Buttons>
    {
        public override void WriteJson(JsonWriter writer, Buttons value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value.ToString()[1]}K");
        }

        public override Buttons ReadJson(JsonReader reader, Type objectType, Buttons existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var value = $"_{((string)reader.Value)![0]}";
                return (Buttons)Enum.Parse(typeof(Buttons), value, true);
            }

            return default;
        }
    }
}