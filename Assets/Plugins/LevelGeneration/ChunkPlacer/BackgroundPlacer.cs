using UnityEngine;

namespace EnotoButerbrodo.LevelGeneration
{
    public class BackgroundPlacer : IChunkPlacer
    {
        private Vector2 _lastChunkPosition;
        public void PlaceStartChunk(Chunk chunk, Vector2 startPosition)
        {
            chunk.Link(startPosition);
            _lastChunkPosition = chunk.EndPoint;
        }

        public void PlaceChunk(Chunk chunk, float distance)
        {
            chunk.Link(_lastChunkPosition);
            _lastChunkPosition = chunk.EndPoint;
        }
    }
}