using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lyaguska.LevelGeneration
{
    public class ChunkFactory : IChunkFactory 
    {
        private LevelGenerationConfig _config;
        
        private List<ChunkPool> _chunks;
        private List<ChunkPool> _startChunks;

        public ChunkFactory(LevelGenerationConfig config, Transform parent)
        {
            _config = config;

            CreatePoolForChunks(parent);
            CreatePoolForStartChunks(parent);
        }

        private void CreatePoolForChunks(Transform parent)
        {
            _chunks = new List<ChunkPool>(_config.Chunks.Count);
            foreach (Chunk chunk in _config.Chunks)
            {
                _chunks.Add(new ChunkPool(chunk, 4, parent));
            }
        }

        private void CreatePoolForStartChunks(Transform parent)
        {
            _startChunks = new List<ChunkPool>(_config.StartChunks.Count);
            foreach (Chunk startChunk in _config.StartChunks)
            {
                _startChunks.Add(new ChunkPool(startChunk, 4,  parent));
            }
        }

        public Chunk GetStartChunk()
        {
            int startChunkIndex = Random.Range(0, _startChunks.Count);

            return _startChunks[startChunkIndex].Get();
        }
        
        public Chunk GetChunk(float distance)
        {
            int chunkIndex = Random.Range(0, _chunks.Count);

            return _chunks[chunkIndex].Get();
        }

    }
}