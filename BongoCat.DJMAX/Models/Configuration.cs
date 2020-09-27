using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BongoCat.DJMAX.Models
{
    public class Configuration
    {
        [JsonProperty("skin")]
        public string SkinName { get; set; }

        [JsonIgnore]
        public Skin Skin { get; set; }

        [JsonProperty("refreshRate")]
        public int? RefreshRate { get; set; }

        [JsonProperty("background")]
        public Color? Background { get; set; }

        [JsonProperty("mode", Required = Required.Always)]
        public Buttons Buttons { get; set; }

        [JsonProperty("4K")]
        public KeySet4 KeySet4 { get; set; }

        [JsonProperty("5K")]
        public KeySet5 KeySet5 { get; set; }

        [JsonProperty("6K")]
        public KeySet6 KeySet6 { get; set; }

        [JsonProperty("8K")]
        public KeySet8 KeySet8 { get; set; }
    }

    public abstract class KeySetBase
    {
        public abstract IEnumerable<Keys> GetKeys();

        protected IEnumerable<Keys> BuildEnumerable(params Keys?[] keys)
        {
            foreach (var key in keys)
            {
                if (!key.HasValue)
                    throw new Exception("Key mapping is lost.");

                yield return key.Value;
            }
        }
    }

    public class KeySet4 : KeySetBase
    {
        [JsonProperty("LSide")]
        public Keys? LeftSide { get; set; }

        [JsonProperty("Key1")]
        public Keys? Key1 { get; set; }

        [JsonProperty("Key2")]
        public Keys? Key2 { get; set; }

        [JsonProperty("Key3")]
        public Keys? Key3 { get; set; }

        [JsonProperty("Key4")]
        public Keys? Key4 { get; set; }

        [JsonProperty("RSide")]
        public Keys? RightSide { get; set; }

        public override IEnumerable<Keys> GetKeys()
        {
            return BuildEnumerable(LeftSide, Key1, Key2, Key3, Key4, RightSide);
        }
    }

    public class KeySet5 : KeySetBase
    {
        [JsonProperty("LSide")]
        public Keys? LeftSide { get; set; }

        [JsonProperty("Key1")]
        public Keys? Key1 { get; set; }

        [JsonProperty("Key2")]
        public Keys? Key2 { get; set; }

        [JsonProperty("Key3_1")]
        public Keys? Key3First { get; set; }

        [JsonProperty("Key3_2")]
        public Keys? Key3Second { get; set; }

        [JsonProperty("Key4")]
        public Keys? Key4 { get; set; }

        [JsonProperty("Key5")]
        public Keys? Key5 { get; set; }

        [JsonProperty("RSide")]
        public Keys? RightSide { get; set; }

        public override IEnumerable<Keys> GetKeys()
        {
            return BuildEnumerable(LeftSide, Key1, Key2, Key3First, Key3Second, Key4, Key5, RightSide);
        }
    }

    public class KeySet6 : KeySetBase
    {
        [JsonProperty("LSide")]
        public Keys? LeftSide { get; set; }

        [JsonProperty("Key1")]
        public Keys? Key1 { get; set; }

        [JsonProperty("Key2")]
        public Keys? Key2 { get; set; }

        [JsonProperty("Key3")]
        public Keys? Key3 { get; set; }

        [JsonProperty("Key4")]
        public Keys? Key4 { get; set; }

        [JsonProperty("Key5")]
        public Keys? Key5 { get; set; }

        [JsonProperty("Key6")]
        public Keys? Key6 { get; set; }

        [JsonProperty("RSide")]
        public Keys? RightSide { get; set; }

        public override IEnumerable<Keys> GetKeys()
        {
            return BuildEnumerable(LeftSide, Key1, Key2, Key3, Key4, Key5, Key6, RightSide);
        }
    }

    public class KeySet8 : KeySetBase
    {
        [JsonProperty("LSide")]
        public Keys? LeftSide { get; set; }

        [JsonProperty("Key1")]
        public Keys? Key1 { get; set; }

        [JsonProperty("Key2")]
        public Keys? Key2 { get; set; }

        [JsonProperty("Key3")]
        public Keys? Key3 { get; set; }

        [JsonProperty("LRed")]
        public Keys? LeftRed { get; set; }

        [JsonProperty("RRed")]
        public Keys? RightRed { get; set; }

        [JsonProperty("Key4")]
        public Keys? Key4 { get; set; }

        [JsonProperty("Key5")]
        public Keys? Key5 { get; set; }

        [JsonProperty("Key6")]
        public Keys? Key6 { get; set; }

        [JsonProperty("RSide")]
        public Keys? RightSide { get; set; }

        public override IEnumerable<Keys> GetKeys()
        {
            return BuildEnumerable(LeftSide, Key1, Key2, Key3, LeftRed, RightRed, Key4, Key5, Key6, RightSide);
        }
    }
}
