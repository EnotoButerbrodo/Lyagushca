using System;
using EnotoButerbrodo.LevelGeneration;
using Lyaguska.Actors;
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
        private Actor _actor;

        [Inject]
        private void Construct(LevelGenerationConfig config, ChunksCollection collection, IDistanceCounter distanceCounter, Actor actor)
        {
            _config = config;
            _collection = collection;
            _distanceCounter = distanceCounter;
            _actor = actor;
        }

        private void Awake()
        {
            var chunkFactory = new ChunkFactory(_collection, this.transform);
            var generationService = new LevelGenerationService(_config, chunkFactory, _distanceCounter);
            
            _stateMachine = new GameStateMachine(generationService, _actor);
            _stateMachine.Enter<LevelCreateState>();
        }

        private void Update()
        {
            _stateMachine.UpdateStates();
        }
    }
}