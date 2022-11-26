using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("Генератор чанков")]
        [SerializeField] private ChunkGenerator _generator;

        [Header("Растановщик чанков")]
        [SerializeField] private ChunkPlacer _placer;
        [SerializeField] private Transform _startPosition;


        private List<Chunk> _spawnedChunks = new List<Chunk>();

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                GenerateChunk();
            }
        }

        private void GenerateChunk()
        {
            Chunk spawnedChunk = _generator.GetChunk(0);
            Vector2 previousPosition = _spawnedChunks.Count == 0
                    ? _startPosition.position
                    : _spawnedChunks.Last().EndPoint;

            _placer.PlaceChunk(spawnedChunk, previousPosition, 0);
            _spawnedChunks.Add(spawnedChunk);
            spawnedChunk.Used += OnChunkUsed;


        }


        private void OnChunkUsed(Chunk chunk)
        {
            var usedChunks = _spawnedChunks.Where(x => x.IsUsed);

            if (usedChunks.Count() > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    GenerateChunk();
                    Destroy(_spawnedChunks[0].gameObject);
                    _spawnedChunks.RemoveAt(0);
                }
            }
        }
    }
}