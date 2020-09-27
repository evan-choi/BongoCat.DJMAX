namespace BongoCat.DJMAX.Models
{
    internal readonly struct KeyMotion
    {
        public int[] Keys { get; }

        public int Sprite { get; }

        public KeyMotion(int[] keys, int sprite)
        {
            Keys = keys;
            Sprite = sprite;
        }
    }
}