using System.Collections.Generic;
using EnotoButerbrodo.LevelGeneration;
using UnityEngine;

namespace Lyaguska.Services
{
    public class LevelGenerationService : ILevelGenerationService
    {
        public int StartChunksCount = 5;
        public int StartBackgroundsAmount = 3;

        private IDistanceCounter _distanceCounter;

        private IChunkFactory _factory;

        private ILevelLayerRepeater _levelRepeater;
        private List<ILevelLayerRepeater> _backgroundsRepeaters;

        public LevelGenerationService(LevelGenerationConfig config, IChunkFactory factory
            , IDistanceCounter distanceCounter)
        {
            _distanceCounter = distanceCounter;
            _factory = factory;
            _levelRepeater = new LevelLayerRepeater(_factory, new ChunkPlacer(config), ChunkType.Start,
                ChunkType.Default, 3f);
            _backgroundsRepeaters = new List<ILevelLayerRepeater>(4);
            CreateMiddleBackgroundRepeater();
            CreateFarBackgroundRepeater();
        }

        public void SpawnStartChunks(Vector2 startPosition)
        {
            SpawnStartDefaultChunks(startPosition);
            SpawnStartBackground(startPosition);
        }

        public void CheckChunksRelevance()
        {
            _levelRepeater.CheckChunksRelevance(_distanceCounter.Position, _distanceCounter.Distance);
            foreach (LevelLayerRepeater repeater in _backgroundsRepeaters)
            {
                repeater.CheckChunksRelevance(_distanceCounter.Position, _distanceCounter.Distance);
            }
            
        }

        private void CreateMiddleBackgroundRepeater()
        {
            var middleBackgroundRepeater = new LevelLayerRepeater(_factory
                , new BackgroundPlacer()
                , ChunkType.Background_Middle
                , ChunkType.Background_Middle
                , 10f);
            _backgroundsRepeaters.Add(middleBackgroundRepeater);
        }

        private void CreateFarBackgroundRepeater()
        {
            var farBackgroundRepeater = new LevelLayerRepeater(_factory
                , new BackgroundPlacer()
                , ChunkType.Background_Far
                , ChunkType.Background_Far
                , 15f);
            _backgroundsRepeaters.Add(farBackgroundRepeater);
        }

        private LevelLayerRepeater GetLevelRepeater(LevelGenerationConfig config) =>
            new LevelLayerRepeater(_factory
                , new ChunkPlacer(config)
                , ChunkType.Start
                , ChunkType.Default);

        private void SpawnStartDefaultChunks(Vector2 position)
        {
            _levelRepeater.SpawnStartChunks(position, StartChunksCount);
        }

        private void SpawnStartBackground(Vector2 position)
        {
            foreach (LevelLayerRepeater repeater in _backgroundsRepeaters)
            {
                repeater.SpawnStartChunks(position - Vector2.right * 10, StartBackgroundsAmount);
            }
        }
    }
}