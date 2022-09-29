using System;
using UnityEngine;

public class Frog : GameActor
{
    [SerializeField] private JumpHandler _jumpHandler;
    [SerializeField] private GroundCheckHandler _groundChecker;


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



}
