using UnityEngine;

namespace Lyaguska.Services
{
    public interface ICameraFollowService : IResetable
    {
        void Enable();
        void SetTarget(Transform transform);
        void Disable();
    }
}