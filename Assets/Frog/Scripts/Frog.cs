using System;
using Unity.VisualScripting;
using UnityEngine;
public class Frog : GameActor
{
    public override event Action JumpChargeBegin
    {
        add => _jumpChargeHandler.Charged += value;
        remove => _jumpChargeHandler.Charged -= value;
    }
    public override event Action Jumped
    {
        add => _jumpHandler.Jumped += value;
        remove => _jumpHandler.Jumped -= value;
    }
    public override event Action GroundLand
    {
        add => _groundChecker.Landed += value;
        remove => _groundChecker.Landed -= value;
    }
    public override event Action Dead
    {
        add => _dieHandler.Dead += value;
        remove => _dieHandler.Dead -= value;
    }

    public override bool Grounded => _groundChecker.IsGrounded();

    [SerializeField] private JumpChargeHandler _jumpChargeHandler;
    [SerializeField] private JumpHandler _jumpHandler;
    [SerializeField] private GroundCheckHandler _groundChecker;
    [SerializeField] private DieHandler _dieHandler;

    //Буффер действий

    private Rigidbody2D _rigidbody2D => GetComponent<Rigidbody2D>();
   

    public override void ChargeJump()
    {
        _state = GameActorState.JumpCharging;

        _jumpChargeHandler.StartCharge();
    }

    public override void Jump()
    {
        _jumpChargeHandler.StopCharge();

        if (_groundChecker.IsGrounded() == false || _state != GameActorState.JumpCharging)
        {
            return;
        }
        _jumpHandler.Jump(_jumpChargeHandler.ChargePercent);
        _jumpChargeHandler.Reset();
    }

    public override void ResetGameActor()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnLand()
    {
        _rigidbody2D.velocity = Vector2.zero;
        if(_jumpChargeHandler.ChargePercent > 0)
        {
            Jump();
        }
    }

    private void Awake()
    {
        _groundChecker.Landed += OnLand;
    }
}
