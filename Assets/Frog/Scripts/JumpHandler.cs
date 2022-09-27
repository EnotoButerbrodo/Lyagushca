using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    public Action JumpChargeBegin;
    public Action<float> JumpPercentChanged; 
    public Action JumpChargeEnd;
    public Action<float> Jumping;

    [SerializeField][Range(0, 10f)] private float _maxChargeTimeInSeconds = 1f;
    [SerializeField][Range(0, 100f)] private float _jumpForceKoeff;
    [SerializeField] private AnimationCurve _jumpForceCurve;
    [SerializeField] private Rigidbody2D _rigidbody;

    private bool _jumpChargeCancelRequst;
    private bool _performJumpCancelRequest;
    private float _jumpPercent;

    private float JumpPercent
    {
        get => _jumpPercent;
        set
        {
            _jumpPercent = value;
            JumpPercentChanged?.Invoke(value);
        }
    }

    private bool _jumping;
    private Vector2 _jumpForce;

    public void InitialJump()
    {
        StartCoroutine(JumpChargeHadler());
    }

    public void PerformJump()
    {
        _jumpChargeCancelRequst = true;
        StartCoroutine(PerformJumpHandler());
    }

    private IEnumerator JumpChargeHadler()
    {
        _jumpChargeCancelRequst = false;
        JumpChargeBegin?.Invoke();

        for (float i = 0; i < _maxChargeTimeInSeconds; i += Time.deltaTime)
        {
            if (_jumpChargeCancelRequst)
            {
                break;
            }

            JumpPercent = i / _maxChargeTimeInSeconds;

            yield return null;
        }

        if (_jumpChargeCancelRequst == false)
        {
            JumpPercent = 1;
        }
        JumpChargeEnd?.Invoke();

    }
    private IEnumerator PerformJumpHandler()
    {
        _jumping = true;
        _performJumpCancelRequest = false;
        _jumpForce = Vector2.zero;

        for (float i = 0; i < _jumpPercent; i += Time.deltaTime)
        {
            if (_performJumpCancelRequest)
            {
                break;
            }

            _jumpForce += Vector2.up * _jumpForceCurve.Evaluate(i/_jumpPercent) * _jumpForceKoeff * Time.deltaTime;
            yield return null;
        }

        _jumping = false;
    }

    private void FixedUpdate()
    {
        if (_jumping)
        {
            _rigidbody.MovePosition(_rigidbody.position + _jumpForce);
            Jumping?.Invoke(_rigidbody.velocity.y);
        }
    }

}

