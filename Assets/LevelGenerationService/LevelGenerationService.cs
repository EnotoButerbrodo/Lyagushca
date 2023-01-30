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
        private void Construct(LevelGenerationConfig config, IDistanceCounter distanceCounter)
        {
            _config = config;
            _distanceCounter = distanceCounter;
            _factory = new ChunkFactory(_config, transform);
            _backgroundsRepeaters = new List<ILevelLayerRepeater>(4);
            
            _levelRepeater = new LevelLayerRepeater(_factory
                , new ChunkPlacer(config)
                , ChunkType.Start
                , ChunkType.Default);

            var backgroudFarRepeater = new LevelLayerRepeater(_factory
                , new BackgroundPlacer()
                , ChunkType.Background_Far
                , ChunkType.Background_Far);
            _backgroundsRepeaters.Add(backgroudFarRepeater);
            
        }
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
                repeater.SpawnStartChunks(_generationStartPoint.position, StartBackgroundsAmount);
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