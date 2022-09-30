using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    public event Action JumpChargeBegin;
    public event Action<float> JumpPercentChanged; 
    public event Action JumpChargeEnd;
    public event Action Jump;

    public event Action<float> VertiacalVelocityChanged;

    [SerializeField][Range(0, 10f)] private float _maxChargeTimeInSeconds = 1f;
    [SerializeField][Range(0, 50f)] private float _jumpHeightKoeff;
    [SerializeField][Range(0, 50f)] private float _jumpRangeKoeff;

    [SerializeField] private AnimationCurve _jumpHeightCurve;
    [SerializeField] private AnimationCurve _jumpRangeCurve;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundCheckHandler _groundChecker;

    private bool _jumpChargeCancelRequst;
    private float _jumpForcePercent;

    private float JumpPercent
    {
        get => _jumpForcePercent;
        set
        {
            _jumpForcePercent = value;
            JumpPercentChanged?.Invoke(value);
        }
    }

    private bool _jumping;
    private Vector2 _jumpForce;

    private bool _inited;
    public void InitialJump()
    {
        if (_groundChecker.IsGrounded() == false)
        {
            return;
        }
        StartCoroutine(JumpChargeHadler());
        _inited = true;
        
    }

    public void StopCharge()
    {
        if (_groundChecker.IsGrounded() == false || _inited == false)
        {
            return;
        }
        _jumpChargeCancelRequst = true;
        Jump?.Invoke();
        _jumpForce = Vector2.up * _jumpHeightCurve.Evaluate(_jumpForcePercent) * _jumpHeightKoeff;
        _jumpForce += Vector2.right * _jumpRangeCurve.Evaluate(_jumpForcePercent) * _jumpRangeKoeff;

        _rigidbody.AddForce(_jumpForce, ForceMode2D.Impulse);
        
        _inited = false;
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



    private void FixedUpdate()
    {
        VertiacalVelocityChanged?.Invoke(_rigidbody.velocity.y);
    }

}

