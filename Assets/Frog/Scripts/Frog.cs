using System;
using Unity.VisualScripting;
using UnityEngine;
public class Frog : GameActor
{
    public override event Action Jump;
    public override event Action Land;
    public override event Action Die;

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

    private void OnJump()
    {
        Jump?.Invoke();
    }

    private void OnLand()
    {
        Land?.Invoke();
    }

    private void OnDead()
    {
        Die?.Invoke();
        Debug.Log("Frog died");
    }

    private void OnEnable()
    {
        _jumpHandler.Jump += OnJump;
        _groundChecker.Landed += OnLand;
        _dieHandler.Dead += OnDead;
    }

    private void OnDisable()
    {
        _jumpHandler.Jump -= OnJump;
        _groundChecker.Landed -= OnLand;
        _dieHandler.Dead -= OnDead;
    }


}
