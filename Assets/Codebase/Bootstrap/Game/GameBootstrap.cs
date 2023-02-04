using System;
using EnotoButerbrodo.LevelGeneration;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        
        private LevelGenerationConfig _config;
        private ChunksCollection _collection;
        private IDistanceCounter _distanceCounter;

        [Inject]
        private void Construct(LevelGenerationConfig config, ChunksCollection collection, IDistanceCounter distanceCounter)
        {
            _config = config;
            _collection = collection;
            _distanceCounter = distanceCounter;
        }

        private void Awake()
        {
            var chunkFactory = new ChunkFactory(_collection, this.transform);
            var generationService = new LevelGenerationService(_config, chunkFactory, _distanceCounter);
            
            _stateMachine = new GameStateMachine(generationService);
            _stateMachine.Enter<LevelCreateState>();
        }
    }
}