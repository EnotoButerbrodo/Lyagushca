using Lyaguska.Core;
using System;
using UnityEngine;
using Zenject;

public class DistanceCounter : MonoBehaviour, IResetable
{
    public Action<float> DistanceChanged;
    public float Distance
    {
        get => _distance;
        set
        {
            _distance = value;
            DistanceChanged?.Invoke(value);
        }
    }
    private float _distance;

    private Vector3 _startPosition;
    private Transform _target;

    [Inject]
    private void Construct(Actor player)
    {
        _target = player.transform;
        _startPosition = _target.position;
    }

    private void Update()
    {
        Distance = _target.position.x - _startPosition.x;
    }

    void IResetable.Reset()
    {
        Distance = 0;
    }
}