using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lyaguska.LevelGeneration
{
    public class LevelGenerator : ILevelGenerator
    {
        private readonly Vector3 _startPosition;
        
        private readonly IChunkFactory _factory;

        private List<Chunk> _spawnedChunks = new List<Chunk>();

        private IReadOnlyList<Chunk> _startChunks;
        private readonly LevelGenerationConfig _config;

        public LevelGenerator(LevelGenerationConfig config, Vector3 startPosition, Transform chunksParent)
        {
            _startPosition = startPosition;
            _startChunks = config.StartChunks;

            _config = config;
            _factory = new ChunkFactory(config, chunksParent);
        }

        public void SpawnStartChunk()
        {
            var startChunk = _factory.GetStartChunk();
            
            PlaceChunk(startChunk, _startPosition, Vector2.zero);
        }

        public void PlaceNewChunk(float distance)
        {
            Chunk newChunk = _factory.GetChunk(distance);
            Vector2 previousPosition = _spawnedChunks.Last().EndPoint;
            var offset = GetRandomOffset(distance);
            
            PlaceChunk(newChunk, previousPosition, offset);
        }

        private void PlaceChunk(Chunk chunk, Vector2 previousPosition, Vector2 offset)
        {
            var newChunkPosition = ClampPosition(previousPosition + offset);
            chunk.Link(newChunkPosition);
            _spawnedChunks.Add(chunk);
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