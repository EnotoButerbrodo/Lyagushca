using Lyaguska.ObjectPool;
using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration.Chunks
{
    public class ChunkPool : ObjectPool<Chunk>
    {
        public ChunkPool(Chunk objectReference, int startCapacity = 8, Transform parent = null) : base(objectReference, startCapacity, parent)
        {
        }
    }
}