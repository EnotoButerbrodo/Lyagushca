using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private int seed;
    [SerializeField] private Transform _startPosition;
    [SerializeField] List<Chunk> _chunkPrefabs;
    
    private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        Random.InitState(seed);

    }

    [ContextMenu("Generate")]
    private void Generate()
    {
        for (int i = 0; i < 2; i++)
        {
            SpawnChunk();
        }
    }
    private void SpawnChunk()
    {
        int chunkNumber = Random.Range(0, _chunkPrefabs.Count - 1);
        Chunk spawnedChunk = Instantiate(_chunkPrefabs[chunkNumber]);

        Vector2 previousPoint = _spawnedChunks.Count == 0 ? _startPosition.position : _spawnedChunks.Last().EndPoint;

        spawnedChunk.Link(previousPoint);
        _spawnedChunks.Add(spawnedChunk);
    }

}
