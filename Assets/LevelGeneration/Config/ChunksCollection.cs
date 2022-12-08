using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    [CreateAssetMenu(menuName = "Config/LevelGeneration/ChunksCollection")]
    public class ChunksCollection : ScriptableObject
    {
        [SerializeField] private List<Chunk> _chunks;
        public IEnumerable<Chunk> Chunks => _chunks;
    }
}