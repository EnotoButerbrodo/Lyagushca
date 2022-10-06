using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    public event Action Jumped;

    public event Action<float> VertiacalVelocityChanged;

    [SerializeField][Range(0, 50f)] private float _jumpHeightKoeff;
    [SerializeField][Range(0, 50f)] private float _jumpRangeKoeff;

    [SerializeField] private AnimationCurve _jumpHeightCurve;
    [SerializeField] private AnimationCurve _jumpRangeCurve;
    [SerializeField] private Rigidbody2D _rigidbody;


    public void Jump(float jumpPercent)
    {
        Vector2 vericalDirection = _jumpHeightCurve.Evaluate(jumpPercent) * _jumpHeightKoeff * Vector2.up;
        Vector2 horizontalDirection = _jumpRangeCurve.Evaluate(jumpPercent) * _jumpRangeKoeff * Vector2.right;

        _rigidbody.AddForce(vericalDirection + horizontalDirection, ForceMode2D.Impulse);
        Jumped?.Invoke();

    }


    private void FixedUpdate()
    {
        VertiacalVelocityChanged?.Invoke(_rigidbody.velocity.y);
    }

}

