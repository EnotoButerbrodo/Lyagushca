using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public class ChunkPlacer : MonoBehaviour
    {
        [Header("Параметры расстановки")]

        [Header("Отступы Y")]
        [SerializeField] private float _minYOffset;
        [SerializeField] private float _maxYOffset;

        [Space]
        [Header("Отступы X")]
        [SerializeField] private float _minXOffset;
        [SerializeField] private float _maxXOffset;

        [Space]
        [Header("Ограничение позиции Y")]
        [SerializeField] private float _minChunkY;
        [SerializeField] private float _maxChunkY;



        public void PlaceChunk(Chunk chunk, Vector2 previousPoint, float score)
        {
            var chunkPosition = ClampPosition(previousPoint + GetRandomOffset(score));
            chunk.Link(chunkPosition);
        }

        private Vector2 GetRandomOffset(float score)
        {
            float scoreModificator = score / 100f;
            float xOffset = Mathf.Clamp(Random.Range(_minXOffset + scoreModificator, _maxXOffset), _minXOffset, _maxXOffset);
            float yOffset = Mathf.Clamp(Random.Range(_minYOffset + scoreModificator, _maxYOffset), _minYOffset, _maxYOffset);

            return xOffset * Vector2.right + yOffset * Vector2.up;
        }

        private Vector2 ClampPosition(Vector2 position)
        {
            return new Vector2(position.x,
                               Mathf.Clamp(position.y, _minChunkY, _maxChunkY));
        }

    }
}