using System;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Common.Serialization
{
    internal sealed class ButtonsConverter : JsonConverter<Buttons>
    {
        private const string _4B = "4B";
        private const string _5B = "5B";
        private const string _6B = "6B";
        private const string _8B = "8B";

        public override void WriteJson(JsonWriter writer, Buttons value, JsonSerializer serializer)
        {
            switch (value)
            {
                case Buttons._5:
                    writer.WriteValue(_5B);
                    break;

                case Buttons._6:
                    writer.WriteValue(_6B);
                    break;

                case Buttons._8:
                    writer.WriteValue(_8B);
                    break;

                default:
                    writer.WriteValue(_4B);
                    break;
            }
        }

        public override Buttons ReadJson(JsonReader reader, Type objectType, Buttons existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch ((string)reader.Value)
            {
                case _5B:
                    return Buttons._5;

                case _6B:
                    return Buttons._6;

                case _8B:
                    return Buttons._8;

                default:
                    return Buttons._4;
            }
        }
    }
}
