using BongoCat.DJMAX.Common;
using BongoCat.DJMAX.Common.Utilities;

namespace BongoCat.DJMAX.Models
{
    internal sealed class KeyState
    {
        public InputKeys Key { get; }

        public bool IsPressed { get; private set; }

        private readonly int _virtualKey;

        public KeyState(InputKeys key)
        {
            Key = key;
            _virtualKey = InputKeysUtility.VirtualKeyFrom(key);
        }

        public bool Update()
        {
            return IsPressed = (Interop.User32.GetAsyncKeyState(_virtualKey) & 0x8000) != 0;
        }
    }
}
