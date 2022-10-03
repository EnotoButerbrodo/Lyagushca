using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [Header("Сид")]
    [SerializeField] private int seed;
    [SerializeField] private bool _randomSeed;

    [Header("Чанки")]
    [SerializeField] private Transform _chunksParent;
    [SerializeField] List<Chunk> _chunkPrefabs;

    private void Start()
    {
        SetSeed(_randomSeed ? System.DateTime.Now.Millisecond : seed);
    }

    public void SetSeed(int seed)
    {
        Random.InitState(seed);
    }

    public Chunk GetChunk(int score)
    {
        int chunkNumber = Random.Range(0, _chunkPrefabs.Count);
        return Instantiate(_chunkPrefabs[chunkNumber], _chunksParent);
    }

}
