using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private int seed;
    [SerializeField] private Transform _startPosition;
    [SerializeField] List<Chunk> _chunkPrefabs;
    [SerializeField] private bool _randomSeed;
    
    private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        
        Random.InitState(_randomSeed ? System.DateTime.Now.Millisecond : seed);
        
        Generate();
        
    }

    private void Generate()
    {
        for (int i = 0; i < 50; i++)
        {
            SpawnChunk();
        }
    }
    private void SpawnChunk()
    {
        int chunkNumber = Random.Range(0, _chunkPrefabs.Count);
        Chunk spawnedChunk = Instantiate(_chunkPrefabs[chunkNumber]);

        Vector2 previousPoint = _spawnedChunks.Count == 0 ? _startPosition.position : _spawnedChunks.Last().EndPoint;

        spawnedChunk.Link(previousPoint + GetRandomOffset());
        _spawnedChunks.Add(spawnedChunk);
    }

    private Vector2 GetRandomOffset()
        => Random.Range(1, 3f) * Vector2.right + Random.Range(-1.5f, 1.5f) * Vector2.up;

}
