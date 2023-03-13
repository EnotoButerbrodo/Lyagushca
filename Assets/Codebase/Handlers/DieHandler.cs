using System;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Handlers
{
    
    public class DieHandler : MonoBehaviour, IResetable
    {
        public event Action Dead;
        [SerializeField] private float _deadLevelY;

        private Transform _transform;
        private bool _dead;

        private void Awake()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            if(_dead)
                return;
            
            if (_transform.position.y < _deadLevelY)
            {
                _dead = true;
                Dead?.Invoke();
            }
        }
        public void Reset()
        {
            _dead = false;
        }
    }
}