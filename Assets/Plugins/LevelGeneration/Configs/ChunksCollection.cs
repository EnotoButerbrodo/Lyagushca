using System.Collections.Generic;
using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration
{
    [CreateAssetMenu(menuName = "Config/LevelGeneration/ChunksCollection")]
    public class ChunksCollection : ScriptableObject
    {
        [SerializeField] private List<Chunk> _chunks;
        public List<Chunk> Chunks => _chunks;
    }
}