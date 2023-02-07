using System;

namespace Codebase.Services
{
    public interface IInputService
    {
        event Action Pressed;
        event Action Released;

        void Enable();
        void Disable();
    }
}