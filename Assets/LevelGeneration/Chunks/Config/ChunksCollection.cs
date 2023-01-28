using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    [CreateAssetMenu(menuName = "Config/LevelGeneration/ChunksCollection")]
    public class ChunksCollection : ScriptableObject
    {
        [SerializeField] private List<Chunk> _chunks;
        [SerializeField] private List<Chunk> _startChunks;
        [SerializeField] private List<Chunk> _backgrounds;
        public List<Chunk> Chunks => _chunks;
        public List<Chunk> StartChunks => _startChunks;
        public List<Chunk> Backgrounds => _backgrounds;

    }
}