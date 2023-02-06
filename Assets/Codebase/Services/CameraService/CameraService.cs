using Cinemachine;
using UnityEngine;

namespace Lyaguska.Services
{
    public class CameraService : ICameraService
    {
        private CinemachineVirtualCamera _camera;
        private CinemachineFramingTransposer _cameraTransposer;
        private Vector3 _startPosition;

        public CameraService(CinemachineVirtualCamera camera)
        {
            _camera = camera;
            _cameraTransposer = _camera.GetCinemachineComponent<CinemachineFramingTransposer>();
            _startPosition = camera.transform.position;
        }

        public void SetTarget(Transform transform)
        {
            _camera.Follow = transform;
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