using Cinemachine;
using UnityEngine;

namespace Lyaguska.Services
{
    public class CameraService : ICameraService
    {
        private CinemachineVirtualCamera _camera;
        private CinemachineFramingTransposer _cameraTransposer;
        private Vector3 _startPosition;
        private Transform _target;

        public CameraService(CinemachineVirtualCamera camera)
        {
            _camera = camera;
            _cameraTransposer = _camera.GetCinemachineComponent<CinemachineFramingTransposer>();
            _startPosition = camera.transform.position;
        }

        public void Enable()
        {
            _camera.Follow = _target;
        }

        public void SetTarget(Transform transform)
        {
            _target = transform;
        }

        public void Disable()
        {
            _camera.Follow = null;
        }

        public void Reset()
        {
            _camera.enabled = false;
            _camera.Follow = null;
            _cameraTransposer.ForceCameraPosition(_startPosition, Quaternion.identity);
            _camera.enabled = true;
        }
    }
}