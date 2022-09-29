using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;


    [SerializeField] private float _lerpSpeed;

    private Vector2 _targetOffset;
    private Transform _transform;

    private Vector2 _targetLastPosition;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _targetOffset = _target.position - _transform.position;
    }

    private void FixedUpdate()
    {
        _transform.position = _target.position + (Vector3)_targetOffset;
    }
}
