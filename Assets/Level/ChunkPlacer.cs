using UnityEditor;
using UnityEngine;
public class ChunkPlacer : MonoBehaviour
{
    [Header("Параметры расстановки")]
    [SerializeField] private float _minYOffset;
    [SerializeField] private float _maxYOffset;

    [Space]

    [SerializeField] private float _minXOffset;
    [SerializeField] private float _maxXOffset;

    public void PlaceChunk(Chunk chunk, Vector2 previousPoint)
    {
        chunk.Link(previousPoint + GetRandomOffset());
    }

    private Vector2 GetRandomOffset()
    {
        Vector2 xOffset = Random.Range(_minXOffset, _maxXOffset) * Vector2.right;
        Vector2 yOffset = Random.Range(_minYOffset, _maxYOffset) * Vector2.up;

        return xOffset + yOffset;
    }

}
