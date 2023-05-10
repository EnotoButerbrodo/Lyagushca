using System.Linq;
using EnotoButerbrodo.LevelGeneration;
using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Services
{
    public class ActorDieCheckService : IActorDieCheckService
    {
        private float _deadLevelOffset = -5f;
        
        private IChunkRepeater _chunkRepeater;
        private float _chunksMinLevel = 0f;
        private Actor _actor;

        public ActorDieCheckService(ILevelGenerationService levelGenerationService)
        {
            _chunkRepeater = levelGenerationService.MainChunkRepeater;
            _chunkRepeater.ChunkSpawned += UpdateChunksLevel;
        }

        private void UpdateChunksLevel(Chunk chunk)
        {
            _chunksMinLevel = _chunkRepeater.ActiveChunks
                .Select(x => x.transform.position.y)
                .Min();
        }

        public void SetActor(Actor actor)
        {
            _actor = actor;
        }
        
        public void CheckDeath()
        {
            if((_actor.IsDead))
                return;

            if (_actor.transform.position.y < _chunksMinLevel + _deadLevelOffset)
            {
                _actor.Die();
            }
        }
    }
}