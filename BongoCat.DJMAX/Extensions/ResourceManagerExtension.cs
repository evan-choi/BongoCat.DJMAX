using System.Drawing;
using System.Resources;

namespace BongoCat.DJMAX.Extensions
{
    internal static class ResourceManagerExtension
    {
        public static Bitmap GetBitmap(this ResourceManager manager, string name)
        {
            return (Bitmap)manager.GetObject(name);
        }
    }
}
