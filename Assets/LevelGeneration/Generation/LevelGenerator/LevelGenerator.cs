using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Lyaguska.LevelGeneration
{
    public class LevelGenerator : ILevelGenerator
    {
        private Vector3 _startPosition;

        private IChunkPlacer _placer;
        private IChunkGenerator _generator;

        private List<Chunk> _spawnedChunks = new List<Chunk>();
        
        public LevelGenerator(LevelGenerationConfig config, Vector3 startPosition)
        {
            _startPosition = startPosition;

            _placer = new ChunkPlacer(config);
            _generator = new ChunkGenerator(config);
        }

        public void SpawnStart()
        {
            for (int i = 0; i < 10; i++)
            {
                PlaceNewChunk(0);
            }
        }

        public void PlaceNewChunk(float distance)
        {
            Chunk spawnedChunk = _generator.GetChunk(distance);
            Vector2 previousPosition = _spawnedChunks.Count == 0
                    ? _startPosition
                    : _spawnedChunks.Last().EndPoint;

            _placer.PlaceChunk(spawnedChunk, previousPosition, distance);
            _spawnedChunks.Add(spawnedChunk);
        }
    }
}