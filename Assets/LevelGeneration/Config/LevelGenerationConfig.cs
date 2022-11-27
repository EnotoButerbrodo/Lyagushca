using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    [CreateAssetMenu(menuName = "Config/LevelGenerationConfig")]
    public class LevelGenerationConfig : ScriptableObject
    {
        [Header("Сид")]
        [SerializeField] private int _seed;
        [SerializeField] private bool _useRandomSeed;

        public int Seed => _seed;
        public bool UseRandomSeed => _useRandomSeed;

        [Header("Чанки")]
        [SerializeField] List<Chunk> _chunkPrefabs;

        public IReadOnlyList<Chunk> ChunkPrefabs => _chunkPrefabs;
    }
}