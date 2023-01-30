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
        
        private IChunkFactory _factory;
        private Dictionary<ChunkType, IChunkPlacer> _placers;
        private Dictionary<ChunkType, List<Chunk>> _activeChunks;

        private bool _enabled;

        [Inject]
        private void Construct(LevelGenerationConfig config, IDistanceCounter distanceCounter)
        {
            _config = config;
            _distanceCounter = distanceCounter;
            _factory = new ChunkFactory(_config, transform);

            InitializePlacers(config);
            InitialChunksDictionary();
        }

        public void BeginGeneration(int startChunkCount)
        {
            PlaceStartChunk();
            PlaceDefaultChunks(startChunkCount);
            PlaceBackground();
            _enabled = true;
        }

        private void InitializePlacers(LevelGenerationConfig config)
        {
            var placer = new ChunkPlacer(config);
            var backgroundPlacer = new BackgroundPlacer();

            _placers = new Dictionary<ChunkType, IChunkPlacer>()
            {
                [ChunkType.Start] = placer,
                [ChunkType.Default] = placer,
                [ChunkType.Background] = backgroundPlacer
            };
        }

        private void InitialChunksDictionary()
        {
            List<Chunk> defaultChunks = new List<Chunk>();
            List<Chunk> backgroundChunks = new List<Chunk>();

            _activeChunks = new Dictionary<ChunkType, List<Chunk>>()
            {
                [ChunkType.Start] = defaultChunks,
                [ChunkType.Default] = defaultChunks,
                [ChunkType.Background] = backgroundChunks
            };
        }

        private void PlaceBackground()
        {
            SpawnStartChunk(ChunkType.Background);
            SpawnChunk(ChunkType.Background);
        }

        private void FixedUpdate()
        {
            if (!_enabled)
                return;

            CheckChunksDistance(ChunkType.Background);
            CheckChunksDistance(ChunkType.Default);
        }


        private void PlaceStartChunk()
        {
            SpawnStartChunk(ChunkType.Start);
        }

        private void PlaceDefaultChunks(int startChunkCount)
        {
            for (int i = 0; i < startChunkCount; i++)
            {
                SpawnChunk(ChunkType.Default);
            }
        }

        private void CheckChunksDistance(ChunkType type)
        {
            float currentDisableDistance = _distanceCounter.Distance + ChunkDisableDistance;
            for (int i = _activeChunks[type].Count - 1; i >= 0; i--)
            {
                Chunk currentChunk = _activeChunks[type][i];
                Vector2 chunkPosition = currentChunk.EndPoint;
                Vector2 currentActorPosition = _distanceCounter.Position;

                bool chunkNotOnScreen = currentActorPosition.x - chunkPosition.x > ChunkDisableDistance;
                if (chunkNotOnScreen)
                {
                    DespawnChunk(type, currentChunk);
                    SpawnChunk(type);
                }
            }
        }


        private void SpawnChunk(ChunkType type)
        {
            Chunk newChunk = _factory.GetChunk(type, _distanceCounter.Distance);
            _activeChunks[type].Add(newChunk);

            _placers[type].PlaceChunk(newChunk, _distanceCounter.Distance);
        }

        private void SpawnStartChunk(ChunkType type)
        {
            Chunk newChunk = _factory.GetChunk(type, _distanceCounter.Distance);
            _activeChunks[type].Add(newChunk);

            _placers[type].PlaceStartChunk(newChunk, _generationStartPoint.position);
        }

        private void DespawnChunk(ChunkType type, Chunk activeChunk)
        {
            _activeChunks[type].Remove(activeChunk);
            activeChunk.ReturnToPool();
        }
    }
}