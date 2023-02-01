using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration
{
    public interface IChunkPlacer
    {
        void PlaceStartChunk(Chunk chunk, Vector2 startPosition);
        void PlaceChunk(Chunk chunk, float distance);
    }
}