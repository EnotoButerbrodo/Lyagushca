using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public class ChunkPlacer : IChunkPlacer
    {
        private readonly LevelGenerationConfig _config;
        private Vector2 _lastChunkPosition;
        
        public ChunkPlacer(LevelGenerationConfig config)
        {
            _config = config;
        }

        public void PlaceStartChunk(Chunk chunk, Vector2 startPosition)
        {
            chunk.Link(startPosition);
            _lastChunkPosition = chunk.EndPoint;
        }
        
        public void PlaceChunk(Chunk chunk, float distance)
        {
            var newChunkPosition = ClampPosition(_lastChunkPosition + GetRandomOffset(distance));
            chunk.Link(newChunkPosition);
            _lastChunkPosition = chunk.EndPoint;
        }

        private Vector2 GetRandomOffset(float distance)
        {
            float scoreModificator = distance / 100f;
            float xOffset = Mathf.Clamp(Random.Range(_config.MinXOffset + scoreModificator, _config.MaxXOffset), _config.MinXOffset, _config.MaxXOffset);
            float yOffset = Mathf.Clamp(Random.Range(_config.MinYOffset + scoreModificator, _config.MaxYOffset), _config.MinYOffset, _config.MaxYOffset);

            return xOffset * Vector2.right + yOffset * Vector2.up;
        }
        
        private Vector2 ClampPosition(Vector2 position)
        {
            return new Vector2(position.x,
                Mathf.Clamp(position.y, _config.MinChunkY, _config.MaxChunkY));
        }
    }
}