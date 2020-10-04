using System;

internal partial class Interop
{
    internal partial class User32
    {
        internal delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
    }
}
