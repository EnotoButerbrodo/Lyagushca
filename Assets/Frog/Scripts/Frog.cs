using System;
using Unity.VisualScripting;
using UnityEngine;
public class Frog : GameActor
{
    public override event Action Jump
    {
        add
        {
            _jumpHandler.Jump += value;
        }
        remove
        {
            _jumpHandler.Jump -= value;
        }
    }
    public override event Action GroundLand
    {
        add
        {
            _groundChecker.Landed += value;
        }
        remove
        {
            _groundChecker.Landed -= value;
        }
    }
    public override event Action Dead
    {
        add
        {
            _dieHandler.Dead += value;
        }
        remove
        {
            _dieHandler.Dead -= value;
        }
    }

    [SerializeField] private JumpHandler _jumpHandler;
    [SerializeField] private GroundCheckHandler _groundChecker;
    [SerializeField] private DieHandler _dieHandler;
    

    public override void ChargeJump()
    {
        if(_groundChecker.IsGrounded() == false)
        {
            return;
        }

        _jumpHandler.InitialJump();
    }

    public override void StopChargeJump()
    {
        _jumpHandler.StopCharge();
    }

    public override void ResetGameActor()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
