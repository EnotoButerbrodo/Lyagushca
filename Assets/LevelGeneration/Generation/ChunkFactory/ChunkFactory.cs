using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lyaguska.LevelGeneration
{
    public class ChunkFactory : IChunkFactory 
    {
        private LevelGenerationConfig _config;

        private Dictionary<ChunkType, List<ChunkPool>> _chunks;

        public ChunkFactory(LevelGenerationConfig config, Transform parent)
        {
            _config = config;
            _chunks = new Dictionary<ChunkType, List<ChunkPool>>();
            
            CreatePool(poolType: ChunkType.Start
                ,poolCollection: _config.StartChunks
                ,objectsParent: parent);
            
            CreatePool(poolType: ChunkType.Default
                ,poolCollection: _config.Chunks
                ,objectsParent: parent);
            
            CreatePool(poolType: ChunkType.Background
                ,poolCollection: _config.BackgroundChunks
                ,objectsParent: parent);
        }
        
          
        public Chunk GetChunk(ChunkType type, float distance)
        {
            var chunksPool = _chunks[type];
            int chunkIndex = Random.Range(0, chunksPool.Count);

            return chunksPool[chunkIndex].Get();
        }

        private void CreatePool(ChunkType poolType, IReadOnlyList<Chunk> poolCollection, Transform objectsParent)
        {
            List<ChunkPool> poolList = new List<ChunkPool>(poolCollection.Count);
            foreach (Chunk chunk in poolCollection)
            {
                poolList.Add(new ChunkPool(chunk, 4, objectsParent));
            }
            _chunks.Add(poolType, poolList);
        }



      
    }

    public enum ChunkType
    {
        Start,
        Default,
        Background
    }
}