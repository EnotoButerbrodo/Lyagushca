using Lyaguska.Core;
using UnityEngine;
using Zenject;

public class DistanceCounter : MonoBehaviour, IResetable
{
    public float Distance => _distance;
    private float _distance;

    private Vector3 _startPosition;
    private Transform _target;

    [Inject]
    private void Construct(GameActor player)
    {
        _target = player.transform;
        _startPosition = _target.position;
    }

    private void Update()
    {
        _distance = _target.position.x - _startPosition.x;
    }

    void IResetable.Reset()
    {
        _distance = 0;
    }
}