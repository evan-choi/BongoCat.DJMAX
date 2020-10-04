using System;
using System.IO;

namespace BongoCat.DJMAX.Common
{
    public static class BCEnvironment
    {
        public static readonly string ConfigFile = Path.Combine(Environment.CurrentDirectory, "config.json");

        public static readonly string SkinDirectory = Path.Combine(Environment.CurrentDirectory, "skins");
    }
}
