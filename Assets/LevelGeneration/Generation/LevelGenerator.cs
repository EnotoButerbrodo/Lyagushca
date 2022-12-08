using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Lyaguska.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        [Inject] private IChunkGenerator _generator;
        [Inject] private ChunkPlacer _placer;
        [Inject] private DistanceCounter _distanceCounter;
        [Inject] private LevelGenerationConfig _config;

        [SerializeField] private Transform _startPosition;

        private List<Chunk> _spawnedChunks = new List<Chunk>();

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                GenerateChunk(0);
            }
            _distanceCounter.DistanceChanged += OnDistanceChanged;
        }

        private void OnDistanceChanged(float distance)
        {

            GenerateChunk(distance);
        }

        private void GenerateChunk(float distance)
        {
            Chunk spawnedChunk = _generator.GetChunk(0);
            Vector2 previousPosition = _spawnedChunks.Count == 0
                    ? _startPosition.position
                    : _spawnedChunks.Last().EndPoint;

            _placer.PlaceChunk(spawnedChunk, previousPosition, distance);
            _spawnedChunks.Add(spawnedChunk);

        }
    }
}