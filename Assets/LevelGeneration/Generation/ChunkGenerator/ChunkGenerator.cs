using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lyaguska.LevelGeneration
{
    internal class ChunkGenerator : IChunkGenerator
    {
        private LevelGenerationConfig _config;

        public ChunkGenerator(LevelGenerationConfig config)
        {
            _config = config;
            SetSeed(_config.UseRandomSeed ? System.DateTime.Now.Millisecond : _config.Seed);
        }

        public Chunk GetStartChunk()
        {
            var startChunkIndex = Random.Range(0, _config.StartChunks.Count - 1);
            return GameObject.Instantiate(_config.StartChunks[startChunkIndex]);
        }
        
        public Chunk GetChunk(float distance)
        {
            int chunkNumber = Random.Range(0, _config.Chunks.Count);
            return GameObject.Instantiate(_config.Chunks[chunkNumber]);
        }

        private void SetSeed(int seed)
        {
            Random.InitState(seed);
        }

    }
}