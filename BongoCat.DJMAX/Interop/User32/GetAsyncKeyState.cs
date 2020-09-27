using System.Runtime.InteropServices;
using System.Windows.Forms;

internal partial class Interop
{
    internal partial class User32
    {
        [DllImport(Libraries.User32)]
        internal static extern short GetAsyncKeyState(Keys keys);
    }
}
