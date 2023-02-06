using System;
using Lyaguska.Actors;
using UnityEngine;
using Zenject;

namespace Lyaguska.Services
{
    public class DistanceCountService : IDistanceCountService, IResetable
    {
        public event Action<float> DistanceChanged;

        public float Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                DistanceChanged?.Invoke(value);
            }
        }

        public Vector2 Position => _target.position;

        private float _distance;

        private Vector3 _startPosition;
        private Transform _target;

        public void SetTarget(Transform targetTransform)
        {
            _target = targetTransform;
            _startPosition = targetTransform.position;
        }

        public void Update()
        {
            Distance = _target.position.x - _startPosition.x;
        }

        void IResetable.Reset()
        {
            Distance = 0;
        }
    }
}