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

        public Chunk GetChunk(float distance)
        {
            int chunkNumber = Random.Range(0, _config.ChunkPrefabs.Count);
            return GameObject.Instantiate(_config.ChunkPrefabs[chunkNumber]);
        }

        private void SetSeed(int seed)
        {
            Random.InitState(seed);
        }

    }
}