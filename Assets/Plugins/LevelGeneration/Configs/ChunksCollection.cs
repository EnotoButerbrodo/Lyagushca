using System.Collections.Generic;
using UnityEngine;
using EnotoButerbrodo.LevelGeneration.Chunks;

namespace EnotoButerbrodo.LevelGeneration.Configs
{
    [CreateAssetMenu(menuName = "Config/LevelGeneration/ChunksCollection")]
    public class ChunksCollection : ScriptableObject
    {
        [SerializeField] private List<Chunk> _chunks;
        public List<Chunk> Chunks => _chunks;
    }
}