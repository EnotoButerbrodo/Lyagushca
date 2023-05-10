using System;
using System.Collections.Generic;
using EnotoButerbrodo.LevelGeneration;
using UnityEngine;

namespace Lyaguska.Services
{
    public class LevelGenerationService : ILevelGenerationService
    {
        public IChunkRepeater MainChunkRepeater => _levelRepeater;

        private const int StartChunksCount = 5;
        private const int StartBackgroundsAmount = 3;


        private const float LevelDespawnDistance = 5f,
            MiddleBackgroundDespawnDistance = 15f,
            FarBackgroundDespawnDistance = 20f;

        private IDistanceCountService _distanceCountService;

        private IChunkFactory _factory;

        private IChunkRepeater _levelRepeater;
        private List<IChunkRepeater> _backgroundsRepeaters;
        private readonly LevelGenerationConfig _config;
        private readonly Vector2 _startBackgroundOffset = Vector2.left * 10f;


        public LevelGenerationService(LevelGenerationConfig config, IChunkFactory factory
            , IDistanceCountService distanceCountService)
        {
            _distanceCountService = distanceCountService;
            _factory = factory;
            _config = config;

            CreateLevelRepeaters();
        }

        public void SpawnStartChunks(Vector2 startPosition)
        {
            SpawnStartDefaultChunks(startPosition);
            SpawnStartBackground(startPosition);
        }

        public void CheckChunksRelevance()
        {
            _levelRepeater.CheckChunksRelevance(_distanceCountService.Position, _distanceCountService.Distance);
            foreach (ChunkRepeater repeater in _backgroundsRepeaters)
            {
                repeater.CheckChunksRelevance(_distanceCountService.Position, _distanceCountService.Distance);
            }
        }

        public void LoadResources() => _factory.Load();

        public void Reset()
        {
            _levelRepeater.Reset();
            _backgroundsRepeaters.ForEach(x => x.Reset());
        }

        private void CreateLevelRepeaters()
        {
            _levelRepeater = new ChunkRepeater(_factory
                , new ChunkPlacer(_config)
                , ChunkType.Start
                , ChunkType.Default
                , LevelDespawnDistance);
            _backgroundsRepeaters = new List<IChunkRepeater>(4);
            CreateMiddleBackgroundRepeater();
            CreateFarBackgroundRepeater();
        }

        private void SpawnStartBackground(Vector2 position)
        {
            foreach (ChunkRepeater repeater in _backgroundsRepeaters)
            {
                repeater.SpawnStartChunks(position + _startBackgroundOffset, StartBackgroundsAmount);
            }
        }

        private void CreateMiddleBackgroundRepeater()
        {
            var middleBackgroundRepeater = new ChunkRepeater(_factory
                , new BackgroundPlacer()
                , ChunkType.Background_Middle
                , ChunkType.Background_Middle
                , MiddleBackgroundDespawnDistance);
            _backgroundsRepeaters.Add(middleBackgroundRepeater);
        }

        private void CreateFarBackgroundRepeater()
        {
            var farBackgroundRepeater = new ChunkRepeater(_factory
                , new BackgroundPlacer()
                , ChunkType.Background_Far
                , ChunkType.Background_Far
                , FarBackgroundDespawnDistance);
            _backgroundsRepeaters.Add(farBackgroundRepeater);
        }

        private void SpawnStartDefaultChunks(Vector2 position)
            => _levelRepeater.SpawnStartChunks(position, StartChunksCount);
    }
}