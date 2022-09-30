using System;
using UnityEngine;

public class Frog : GameActor
{
    public override event Action Jump;
    public override event Action Land;

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

    private void OnJump()
    {
        Jump?.Invoke();
    }

    private void OnLand()
    {
        Land?.Invoke();
    }

    private void OnEnable()
    {
        _jumpHandler.Jump += OnJump;
        _groundChecker.Landed += OnLand;
    }

    private void OnDisable()
    {
        _jumpHandler.Jump -= OnJump;
        _groundChecker.Landed -= OnLand;
    }


}
