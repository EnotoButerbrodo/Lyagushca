using System;
using System.Collections;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public class Chunk : MonoBehaviour
    {
        public event Action<Chunk> Used;
        public Vector2 StartPoint => _startPosition.position;
        public Vector2 EndPoint => _endPosition.position;
        public float DistanceLevel => _distanceLevel;
        public float HeightLevel => _heightLevel;

        public bool IsUsed { get; private set; }
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private float _distanceLevel;
        [SerializeField] private float _heightLevel;



        public void Link(Vector2 point)
        {
            transform.position = point - (Vector2)_startPosition.localPosition;
        }
    }
}