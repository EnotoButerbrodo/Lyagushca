using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration
{
    public interface IChunkRepeater
    {
        event Action<Chunk> ChunkSpawned;
        event Action<Chunk> ChunkDespawned;
        void SpawnStartChunks(Vector2 startPosition, int amount = 1);
        void CheckChunksRelevance(Vector2 currentPosition, float distance);

        void Reset();
        
        IReadOnlyList<Chunk> ActiveChunks { get; }
    }
}