using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lyaguska.LevelGeneration
{


    public class DefaultChunkGenerator : MonoBehaviour, IChunkGenerator
    {
        private LevelGenerationConfig _config;

        private Transform _chunksParent;

        [Inject]
        private void Construct(LevelGenerationConfig config)
        {
            _config = config;
            SetSeed(_config.UseRandomSeed ? System.DateTime.Now.Millisecond : _config.Seed);
            _chunksParent = transform;
        }

        public Chunk GetChunk(int score)
        {
            int chunkNumber = Random.Range(0, _config.ChunkPrefabs.Count);
            return Instantiate(_config.ChunkPrefabs[chunkNumber], _chunksParent);
        }

        private void SetSeed(int seed)
        {
            Random.InitState(seed);
        }

    }
}