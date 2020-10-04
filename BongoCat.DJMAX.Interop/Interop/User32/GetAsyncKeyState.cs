using System.Runtime.InteropServices;

internal partial class Interop
{
    internal partial class User32
    {
        [DllImport(Libraries.User32)]
        internal static extern short GetAsyncKeyState(int vk);
    }
}
