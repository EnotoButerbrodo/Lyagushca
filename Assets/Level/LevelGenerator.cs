using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Генератор чанков")]
    [SerializeField] private ChunkGenerator _generator;

    [Header("Растановщик чанков")]
    [SerializeField] private ChunkPlacer _placer;
    [SerializeField] private Transform _startPosition;

    [Header("Счетчик очков")]
    [SerializeField] private ScoreCounter _scoreCounter;


    private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Chunk spawnedChunk = _generator.GetChunk(0);
            Vector2 previousPosition = _spawnedChunks.Count == 0
                ? _startPosition.position
                : _spawnedChunks.Last().EndPoint;

            _placer.PlaceChunk(spawnedChunk, previousPosition, _scoreCounter.Score);
            _spawnedChunks.Add(spawnedChunk);
        }
    }

}
