using System.Collections;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2 StartPoint => _startPosition.position;
    public Vector2 EndPoint => _endPosition.position;
    public float DistanceLevel => _distanceLevel;
    public float HeightLevel => _heightLevel;

    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _distanceLevel;
    [SerializeField] private float _heightLevel;

    public void Link(Vector2 point)
    {
        transform.position = point - (Vector2)_startPosition.localPosition;
    }
}
