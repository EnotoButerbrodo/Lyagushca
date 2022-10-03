using System.Collections;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2 StartPoint => _startPosition.position;
    public Vector2 EndPoint => _endPosition.position;
    public float Level => _level;

    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _level;

    public void Link(Vector2 point)
    {
        transform.position = point - (Vector2)_startPosition.localPosition;
    }
}
