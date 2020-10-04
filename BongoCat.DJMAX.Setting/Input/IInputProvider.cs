using System;
using BongoCat.DJMAX.Common;

namespace BongoCat.DJMAX.Setting.Input
{
    internal interface IInputProvider : IDisposable
    {
        event EventHandler<InputKeys> KeyDown;
    }
}
