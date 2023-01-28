using System;
using System.Collections.Generic;
using System.Linq;
using Lyaguska.LevelGeneration;
using UnityEngine;
using Zenject;

namespace LevelGeneration.Generation.LevelGenerationService
{
    public class LevelGenerationService : MonoBehaviour
    {
        [Range(0f, 10f)] public float ChunkDisableDistance;
        
        [SerializeField] private Transform _generationStartPoint;

        private LevelGenerationConfig _config;
        private IDistanceCounter _distanceCounter;

        private IChunkPlacer _placer;
        private IChunkFactory _factory;
        
        private List<Chunk> _activeChunks;

        private bool _enabled;
        
        [Inject]
        private void Construct(LevelGenerationConfig config, IDistanceCounter distanceCounter)
        {
            _config = config;
            _distanceCounter = distanceCounter;
            _factory = new ChunkFactory(_config, transform);
            _placer = new ChunkPlacer(_config);
            _activeChunks = new List<Chunk>();
        }

        public void BeginGeneration(int startChunkCount)
        {
            PlaceStartChunk();
            for (int i = 0; i < startChunkCount; i++)
            {
                SpawnChunk();
            }
            _enabled = true;
        }

        private void FixedUpdate()
        {
            if (!_enabled)
                return;

            CheckChunksDistance();
        }

        private void CheckChunksDistance()
        {
            float currentDisableDistance = _distanceCounter.Distance + ChunkDisableDistance;
            foreach (var activeChunk in _activeChunks.ToList())
            {
                Vector2 chunkPosition = activeChunk.EndPoint;
                Vector2 currentActorPosition = _distanceCounter.Position;

                bool chunkNotOnScreen = currentActorPosition.x - chunkPosition.x > ChunkDisableDistance;
                if (chunkNotOnScreen)
                {
                    DespawnChunk(activeChunk);
                    SpawnChunk();
                }
            }
        }

        private void DespawnChunk(Chunk activeChunk)
        {
            _activeChunks.Remove(activeChunk);
            activeChunk.ReturnToPool();
        }

        private void PlaceStartChunk()
        {
            Chunk startChunk = _factory.GetStartChunk();
            
            _activeChunks.Add(startChunk);
            _placer.PlaceStartChunk(startChunk, _generationStartPoint.position);
        }
        
        private void SpawnChunk()
        {
            Chunk newChunk = _factory.GetChunk(_distanceCounter.Distance);
            _activeChunks.Add(newChunk);
                
            _placer.PlaceChunk(newChunk, _distanceCounter.Distance);
        }
    }
}