using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public interface IChunkPlacer
    {
        void PlaceStartChunk(Chunk chunk, Vector2 startPosition);
        void PlaceChunk(Chunk chunk, float distance);
    }
}