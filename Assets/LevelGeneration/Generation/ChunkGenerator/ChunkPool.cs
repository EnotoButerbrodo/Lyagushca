using Lyaguska.ObjectPool;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public class ChunkPool : ObjectPool<Chunk>
    {
        public ChunkPool(Chunk objectReference, int startCapacity = 8, Transform parent = null) : base(objectReference, startCapacity, parent)
        {
        }
    }
}