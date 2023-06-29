using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using EnotoButebrodo;
using Random = EnotoButebrodo.Random;

namespace EnotoButerbrodo.LevelGeneration
{
    public class ChunkFactory : IChunkFactory 
    {
        private ChunksCollection _chunksCollection;
        private readonly Transform _parent;
        private IDistinctRandom _random;

        private Dictionary<ChunkType, List<ChunksPool>> _chunks;
        private Dictionary<ChunkType, IDistinctRandom> _randoms;
 

        public ChunkFactory(ChunksCollection chunksCollection, Transform parent)
        {
            _chunksCollection = chunksCollection;
            _parent = parent;
        }
        
        public Chunk GetChunk(ChunkType type, float distance)
        {
            var chunksPool = _chunks[type];
            int chunkIndex = _randoms[type].GetDistinctNumber();

            return chunksPool[chunkIndex].Get();
        }
        
        public void Load()
        {
            CreatePools();
        }

        private void CreatePools()
        {
            _chunks = new Dictionary<ChunkType, List<ChunksPool>>();
            
            foreach (Chunk chunk in _chunksCollection.Chunks)
            {
                if (_chunks.ContainsKey(chunk.Type) == false)
                {
                    int count = _chunksCollection.Chunks.Count(x => x.Type == chunk.Type);
                    List<ChunksPool> poolList = new List<ChunksPool>(count);
                    
                    _chunks.Add(key: chunk.Type, value: poolList);
                }

                _chunks[chunk.Type].Add(new ChunksPool(chunk, startCapacity: 1, _parent));
            }

            _randoms = new Dictionary<ChunkType, IDistinctRandom>(_chunks.Count);
            
            foreach (var chunk in _chunks)
            {
                _randoms.Add(chunk.Key, new DistinctRandom(0, chunk.Value.Count));
            }
        }

        


    }
}