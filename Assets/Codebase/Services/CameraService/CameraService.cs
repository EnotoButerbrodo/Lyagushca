using Cinemachine;
using UnityEngine;

namespace Lyaguska.Services
{
    public class CameraService : ICameraService
    {
        private CinemachineVirtualCamera _camera;

        public CameraService(CinemachineVirtualCamera camera)
        {
            _camera = camera;
        }

        public void SetTarget(Transform transform)
        {
            _camera.Follow = transform;
        }
    }
}