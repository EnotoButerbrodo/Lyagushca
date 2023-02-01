using EnotoButerbrodo.LevelGeneration.Chunks;
using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration.Placer
{
    public interface IChunkPlacer
    {
        void PlaceStartChunk(Chunk chunk, Vector2 startPosition);
        void PlaceChunk(Chunk chunk, float distance);
    }
}