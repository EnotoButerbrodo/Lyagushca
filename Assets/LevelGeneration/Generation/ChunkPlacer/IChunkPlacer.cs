using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    internal interface IChunkPlacer
    {
        void PlaceChunk(Chunk chunk, Vector2 previousPoint, float distance);
    }
}