using System;
using System.Collections.Generic;
using EnotoButerbrodo.LevelGeneration;
using UnityEngine;

namespace Lyaguska.Services
{
    public interface ILevelGenerationService : IResetable
    {
        void SpawnStartChunks(Vector2 startPosition);
        void CheckChunksRelevance();

        void LoadResources();
        IChunkRepeater MainChunkRepeater { get; }
    }
}