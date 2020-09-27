using System.Drawing;

namespace BongoCat.DJMAX.Models
{
    internal readonly struct SpriteGroup
    {
        public readonly int GroupId;

        public readonly Bitmap Bitmap;

        public SpriteGroup(int groupId, Bitmap bitmap)
        {
            GroupId = groupId;
            Bitmap = bitmap;
        }
    }
}
