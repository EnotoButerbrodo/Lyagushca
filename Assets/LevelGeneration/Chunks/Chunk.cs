
using System;
using Lyaguska.ObjectPool;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public class Chunk : MonoBehaviour, IPoolable<Chunk>
    {
        public Vector2 StartPoint => _startPosition.position;
        public Vector2 EndPoint => _endPosition.position;
        public float DistanceLevel => _distanceLevel;
        public float HeightLevel => _heightLevel;

        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private float _distanceLevel;
        [SerializeField] private float _heightLevel;
        private Action<Chunk> _returnAction;

        public void Link(Vector2 point)
        {
            transform.position = point - (Vector2)_startPosition.localPosition;
        }

        public void Initialize(Action<Chunk> returnAction)
        {
            _returnAction = returnAction;
        }

        public void ReturnToPool()
        {
            _returnAction.Invoke(this);
        }

        private void OnDisable()
        {
            ReturnToPool();
        }
    }
}