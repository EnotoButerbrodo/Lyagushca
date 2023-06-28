using UnityEngine;
using Random = EnotoButebrodo.Random;

namespace EnotoButerbrodo.LevelGeneration
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
            float scoreModificator = distance / 1000f;
            float xOffset = Random.Range(_config.MinXOffset + scoreModificator, _config.MaxXOffset);
            float xOffsetClamp = Mathf.Clamp(xOffset, _config.MinXOffset, _config.MaxXOffset);
            
            float yOffset = Random.Range(_config.MinYOffset, _config.MaxYOffset);
            float yOffsetClamp = Mathf.Clamp(yOffset, _config.MinChunkY, _config.MaxChunkY);

            return xOffsetClamp * Vector2.right 
                   + yOffsetClamp * Vector2.up;
        }
        
        private Vector2 ClampPosition(Vector2 position)
        {
            return new Vector2(position.x,
                Mathf.Clamp(position.y, _config.MinChunkY, _config.MaxChunkY));
        }
    }
}