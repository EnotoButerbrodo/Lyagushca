using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using EnotoButebrodo;

namespace EnotoButerbrodo.LevelGeneration
{
    public class ChunkFactory : IChunkFactory 
    {
        private ChunksCollection _chunksCollection;

        private Dictionary<ChunkType, List<ChunksPool>> _chunks;

        private IRandomService _random;

        public ChunkFactory(ChunksCollection chunksCollection, Transform parent, IRandomService random)
        {
            _chunksCollection = chunksCollection;
            _chunks = new Dictionary<ChunkType, List<ChunksPool>>();
            _random = random;

            CreatePools(parent);
        }

        private void CreatePools(Transform parent)
        {
            foreach (Chunk chunk in _chunksCollection.Chunks)
            {
                if (_chunks.ContainsKey(chunk.Type) == false)
                {
                    int count = _chunksCollection.Chunks.Count(x => x.Type == chunk.Type);
                    List<ChunksPool> poolList = new List<ChunksPool>(count);
                    
                    _chunks.Add(key: chunk.Type, value: poolList);
                }

                _chunks[chunk.Type].Add(new ChunksPool(chunk, startCapacity: 4, parent));
            }
        }

        public Chunk GetChunk(ChunkType type, float distance)
        {
            var chunksPool = _chunks[type];
            int chunkIndex = _random.Range(0, chunksPool.Count - 1);

            return chunksPool[chunkIndex].Get();
        }


    }
}