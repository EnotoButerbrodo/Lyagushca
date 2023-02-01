using System.Collections.Generic;
using EnotoButerbrodo.LevelGeneration.Chunks;
using EnotoButerbrodo.LevelGeneration.Factory;
using EnotoButerbrodo.LevelGeneration.Placer;
using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration.LevelRepeater
{
    public class LevelLayerRepeater : ILevelLayerRepeater
    {
        private IChunkFactory _factory;
        private IChunkPlacer _placer;
        private ChunkType _startType;
        private ChunkType _type;

        private List<Chunk> _activeChunks;
        private float _despawnDistance;

        public LevelLayerRepeater(IChunkFactory factory
            , IChunkPlacer placer
            , ChunkType startType
            , ChunkType type
            , float despawnDistance = 3f)
        {
            _factory = factory;
            _placer = placer;
            _startType = startType;
            _type = type;
            _activeChunks = new List<Chunk>();
            _despawnDistance = despawnDistance;
        }

        public void SpawnStartChunks(Vector2 startPosition, int amount = 1)
        {
            SpawnStartChunk(startPosition);
            
            if(amount <= 1)
                return;
            
            for (int i = 0; i < amount - 1; i++)
            {
                SpawnChunk();
            }
        }
        
        public void CheckChunksRelevance(Vector2 currentPosition, float distance)
        {
            for (int i = _activeChunks.Count - 1; i >= 0; i--)
            {
                Chunk currentChunk = _activeChunks[i];
                Vector2 chunkPosition = currentChunk.EndPoint;

                bool chunkNotOnScreen =  currentPosition.x - chunkPosition.x >= _despawnDistance;
                if (chunkNotOnScreen)
                {
                    DespawnChunk(i);
                    SpawnChunk(distance);
                }
            }
        }

        private void SpawnStartChunk(Vector2 position)
        {
            _placer.PlaceStartChunk(GetChunk(_startType), position);
        }
        private void SpawnChunk(float distance = 0)
        {
            _placer.PlaceChunk(GetChunk(_type), distance);
        }

        private Chunk GetChunk(ChunkType type)
        {
            Chunk chunk = _factory.GetChunk(type);
            _activeChunks.Add(chunk);

            return chunk;
        }

        private void DespawnChunk(int position)
        {
            _activeChunks[position].ReturnToPool();
            _activeChunks.RemoveAt(position);
        }
    }
}