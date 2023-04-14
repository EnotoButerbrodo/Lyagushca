using System;

namespace Lyaguska.Services
{
    public interface IPauseService
    {
        void Register(IPauseable service);
        void Unregister(IPauseable service);
        void Pause();
        void Resume();
        bool IsPaused { get; }

        event Action Paused;
        event Action Resumed;
    }
}