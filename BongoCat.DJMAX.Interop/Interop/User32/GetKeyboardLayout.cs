using System;
using System.Runtime.InteropServices;

internal partial class Interop
{
    internal partial class User32
    {
        [DllImport(Libraries.User32, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetKeyboardLayout(uint threadId);
    }
}
