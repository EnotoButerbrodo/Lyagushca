using System;
using UnityEngine;

namespace Lyaguska.Services
{
    public class DistanceCountService : IDistanceCountService
    {
        public event Action<int> DistanceChanged;

        public int Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                DistanceChanged?.Invoke(value);
            }
        }

        public Vector2 Position => _target.position;

        private int _distance;
 
        private Vector3 _startPosition;
        private Transform _target;

        public void SetTarget(Transform targetTransform)
        {
            _target = targetTransform;
            _startPosition = targetTransform.position;
            Distance = 0;
        }

        public void Update()
        {
            var newDistance = Mathf.FloorToInt(_target.position.x - _startPosition.x);
            if(newDistance == _distance)
                return;

            Distance = newDistance;
        }

        void IResetable.Reset()
        {
            Distance = 0;
        }
    }
}