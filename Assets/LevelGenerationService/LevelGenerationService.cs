using System;
using System.Collections.Generic;
using Lyaguska.LevelGeneration;
using UnityEngine;
using Zenject;

namespace LevelGeneration.Generation.LevelGenerationService
{
    public class LevelGenerationService: MonoBehaviour
    {
        [Range(0f, 10f)] public float ChunkDisableDistance;
        
        public int StartChunksCount = 5;
        public int StartBackgroundsAmount = 3;
        
        [SerializeField] private Transform _generationStartPoint;

        private LevelGenerationConfig _config;
        private IDistanceCounter _distanceCounter;

        private IChunkFactory _factory;

        private ILevelLayerRepeater _levelRepeater;
        private List<ILevelLayerRepeater> _backgroundsRepeaters;

        private bool _enabled;

        [Inject]
        private void Construct(LevelGenerationConfig config, ChunksCollection chunksCollection, IDistanceCounter distanceCounter)
        {
            _config = config;
            _distanceCounter = distanceCounter;
            _factory = new ChunkFactory(chunksCollection, transform);
            _backgroundsRepeaters = new List<ILevelLayerRepeater>(4);
            
            _levelRepeater = GetLevelRepeater(config);
            CreateFarBackgroundRepeater();
            CreateMiddleBackgroundRepeater();
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

        public void BeginGeneration(int startChunkCount)
        {
            BeginGeneration();
            BeginBackgroundGeneration();
            _enabled = true;
        }

        private void BeginGeneration()
        {
            _levelRepeater.SpawnStartChunks(_generationStartPoint.position, StartChunksCount);
        }

        private void BeginBackgroundGeneration()
        {
            foreach (LevelLayerRepeater repeater in _backgroundsRepeaters)
            {
                repeater.SpawnStartChunks(_generationStartPoint.position - Vector3.right * 10, StartBackgroundsAmount);
            }
        }

        private void FixedUpdate()
        {
            if(!enabled)
                return;

            CheckChunksRelevance();
        }

        private void CheckChunksRelevance()
        {
            _levelRepeater.CheckChunksRelevance(_distanceCounter.Position, _distanceCounter.Distance);
            foreach (LevelLayerRepeater repeater in _backgroundsRepeaters)
            {
                repeater.CheckChunksRelevance(_distanceCounter.Position, _distanceCounter.Distance);
            }
            
        }
    }
}