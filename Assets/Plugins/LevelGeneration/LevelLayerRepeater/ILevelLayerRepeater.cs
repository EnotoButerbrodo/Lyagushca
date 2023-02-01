﻿using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration.LevelRepeater
{
    public interface ILevelLayerRepeater
    {
        void SpawnStartChunks(Vector2 startPosition, int amount = 1);
        void CheckChunksRelevance(Vector2 currentPosition, float distance);
    }
}