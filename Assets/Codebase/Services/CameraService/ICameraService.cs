using UnityEngine;

namespace Lyaguska.Services
{
    public interface ICameraService : IResetable
    {
        void SetTarget(Transform transform);
    }
}