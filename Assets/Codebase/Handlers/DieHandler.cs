using System;
using UnityEngine;

namespace Lyaguska.Handlers
{
    public class DieHandler : MonoBehaviour
    {
        public event Action Dead;
        [SerializeField] private float _deadLevelY;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            if (_transform.position.y < _deadLevelY)
            {
                Die();
            }
        }

        public void Die()
        {
            Dead?.Invoke();
        }

    }
}