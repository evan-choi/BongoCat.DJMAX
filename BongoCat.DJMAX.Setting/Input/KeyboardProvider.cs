using System;
using System.Diagnostics;
using System.Windows.Input;
using BongoCat.DJMAX.Common;

namespace BongoCat.DJMAX.Setting.Input
{
    internal class KeyboardProvider : IInputProvider
    {
        private const uint MASK_KEYDOWN = 0x40000000;
        private const int HC_NOREMOVE = 3;

        public event EventHandler<InputKeys> KeyDown;

        private Interop.User32.HookProc _proc;
        private IntPtr _hook;

        public KeyboardProvider()
        {
            _proc = HookProc;

            _hook = Interop.User32.SetWindowsHookEx(
                Interop.User32.HookType.WH_KEYBOARD,
                _proc,
                IntPtr.Zero,
                Interop.Kernel32.GetCurrentThreadId());
        }

        private IntPtr HookProc(int code, IntPtr wparam, IntPtr lparam)
        {
            if (code >= 0 && code != HC_NOREMOVE)
            {
                var flags = (uint)lparam;

                if ((flags & MASK_KEYDOWN) > 0)
                {
                    var key = KeyInterop.KeyFromVirtualKey(wparam.ToInt32());
                    KeyDown?.Invoke(this, ConvertToInputKeys(key));
                }
            }

            return Interop.User32.CallNextHookEx(_hook, code, wparam, lparam);
        }

        public void Dispose()
        {
            if (_hook != IntPtr.Zero)
            {
                Interop.User32.UnhookWindowsHookEx(_hook);
                _hook = IntPtr.Zero;
            }

            _proc = null;
        }

        private static InputKeys ConvertToInputKeys(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    return InputKeys.Left;

                case Key.Up:
                    return InputKeys.Up;

                case Key.Right:
                    return InputKeys.Right;

                case Key.Down:
                    return InputKeys.Down;

                case Key.A:
                    return InputKeys.A;

                case Key.B:
                    return InputKeys.B;

                case Key.C:
                    return InputKeys.C;

                case Key.D:
                    return InputKeys.D;

                case Key.E:
                    return InputKeys.E;

                case Key.F:
                    return InputKeys.F;

                case Key.G:
                    return InputKeys.G;

                case Key.H:
                    return InputKeys.H;

                case Key.I:
                    return InputKeys.I;

                case Key.J:
                    return InputKeys.J;

                case Key.K:
                    return InputKeys.K;

                case Key.L:
                    return InputKeys.L;

                case Key.N:
                    return InputKeys.N;

                case Key.M:
                    return InputKeys.M;

                case Key.O:
                    return InputKeys.O;

                case Key.P:
                    return InputKeys.P;

                case Key.Q:
                    return InputKeys.Q;

                case Key.R:
                    return InputKeys.R;

                case Key.S:
                    return InputKeys.S;

                case Key.T:
                    return InputKeys.T;

                case Key.U:
                    return InputKeys.U;

                case Key.V:
                    return InputKeys.V;

                case Key.W:
                    return InputKeys.W;

                case Key.X:
                    return InputKeys.X;

                case Key.Y:
                    return InputKeys.Y;

                case Key.Z:
                    return InputKeys.Z;

                case Key.D1:
                    return InputKeys.D1;

                case Key.D2:
                    return InputKeys.D2;

                case Key.D3:
                    return InputKeys.D3;

                case Key.D4:
                    return InputKeys.D4;

                case Key.D5:
                    return InputKeys.D5;

                case Key.D6:
                    return InputKeys.D6;

                case Key.D7:
                    return InputKeys.D7;

                case Key.D8:
                    return InputKeys.D8;

                case Key.D9:
                    return InputKeys.D9;

                case Key.D0:
                    return InputKeys.D0;

                case Key.OemMinus:
                    return InputKeys.DMinus;

                case Key.OemPlus:
                    return InputKeys.DPlus;

                case Key.NumLock:
                    return InputKeys.NumLock;

                case Key.Divide:
                    return InputKeys.NumSlash;

                case Key.Multiply:
                    return InputKeys.NumMultiply;

                case Key.Subtract:
                    return InputKeys.NumMinus;

                case Key.Add:
                    return InputKeys.NumPlus;

                case Key.Decimal:
                    return InputKeys.NumPeriod;

                case Key.NumPad1:
                    return InputKeys.Num1;

                case Key.NumPad2:
                    return InputKeys.Num2;

                case Key.NumPad3:
                    return InputKeys.Num3;

                case Key.NumPad4:
                    return InputKeys.Num4;

                case Key.NumPad5:
                    return InputKeys.Num5;

                case Key.NumPad6:
                    return InputKeys.Num6;

                case Key.NumPad7:
                    return InputKeys.Num7;

                case Key.NumPad8:
                    return InputKeys.Num8;

                case Key.NumPad9:
                    return InputKeys.Num9;

                case Key.NumPad0:
                    return InputKeys.Num0;

                case Key.Scroll:
                    return InputKeys.ScrollLock;

                case Key.OemOpenBrackets:
                    return InputKeys.OpenBrackets;

                case Key.Oem6:
                    return InputKeys.CloseBrackets;

                case Key.OemQuestion:
                    return InputKeys.Slash;

                case Key.Back:
                    return InputKeys.BackSlash;

                case Key.Oem1:
                    return InputKeys.Semicolon;

                case Key.OemQuotes:
                    return InputKeys.Quote;

                case Key.Oem3:
                    return InputKeys.BackQuote;

                case Key.OemComma:
                    return InputKeys.Comma;

                case Key.OemPeriod:
                    return InputKeys.Period;

                case Key.Space:
                    return InputKeys.Space;

                case Key.Oem5:
                    return InputKeys.BackSpace;

                case Key.Tab:
                    return InputKeys.Tab;

                case Key.CapsLock:
                    return InputKeys.CapsLock;

                case Key.LeftShift:
                    return InputKeys.LShift;

                case Key.RightShift:
                    return InputKeys.RShift;

                case Key.LeftCtrl:
                    return InputKeys.LControl;

                case Key.LWin:
                    return InputKeys.LWindow;

                case Key.RWin:
                    return InputKeys.RWindow;

                case Key.System:
                case Key.LeftAlt:
                    return InputKeys.LAlt;

                case Key.RightAlt:
                case Key.KanaMode:
                    return InputKeys.RAlt;

                case Key.Escape:
                    return InputKeys.Escape;
            }

            return InputKeys.None;
        }
    }
}
