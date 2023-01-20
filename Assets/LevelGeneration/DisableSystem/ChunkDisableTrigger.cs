using System;
using Lyaguska.ObjectPool;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public class ChunkDisableTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<ChunkEndPoint>().Chunk.ReturnToPool();
        }
    }
}