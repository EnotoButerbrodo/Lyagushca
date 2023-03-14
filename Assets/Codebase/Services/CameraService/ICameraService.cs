using UnityEngine;

namespace Lyaguska.Services
{
    public interface ICameraService : IResetable
    {
        void Enable();
        void SetTarget(Transform transform);
        void Disable();
    }
}