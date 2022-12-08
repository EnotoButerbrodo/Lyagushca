using UnityEngine;
using Zenject;

namespace Lyaguska.LevelGeneration
{
    public class ChunkPlacer : MonoBehaviour
    {
        [Inject] private LevelGenerationConfig _config;

        public void PlaceChunk(Chunk chunk, Vector2 previousPoint, float distance)
        {
            var chunkPosition = ClampPosition(previousPoint + GetRandomOffset(distance));
            chunk.Link(chunkPosition);
        }

        private Vector2 GetRandomOffset(float score)
        {
            float scoreModificator = score / 100f;
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