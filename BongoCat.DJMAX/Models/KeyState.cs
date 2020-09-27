using System.Windows.Forms;

namespace BongoCat.DJMAX.Models
{
    internal sealed class KeyState
    {
        public Keys Key { get; }

        public bool IsPressed { get; private set; }

        public KeyState(Keys key)
        {
            Key = key;
        }

        public bool Update()
        {
            return IsPressed = (Interop.User32.GetAsyncKeyState(Key) & 0x8000) != 0;
        }
    }
}
