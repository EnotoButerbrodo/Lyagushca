﻿using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration
{
    public class ChunksPool : ObjectsPool<Chunk>
    {
        public ChunksPool(Chunk objectReference, int startCapacity = 8, Transform parent = null) : base(objectReference, startCapacity, parent)
        {
        }
    }
}