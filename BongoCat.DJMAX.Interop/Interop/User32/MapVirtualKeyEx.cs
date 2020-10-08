using System;
using System.Runtime.InteropServices;

internal partial class Interop
{
    internal partial class User32
    {
        [DllImport(Libraries.User32)]
        internal static extern uint MapVirtualKeyEx(uint uCode, MapVirtualKeyMapTypes uMapType, IntPtr dwhkl);
    }
}
