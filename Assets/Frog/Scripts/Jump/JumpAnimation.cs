using UnityEngine;
public class JumpAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private JumpChargeHandler _jumpChargeHandler;
    [SerializeField] private JumpHandler _jumpHandler;
    [SerializeField] private GroundCheckHandler _groundChecker;

    [SerializeField] private string _jumpChargeTriggerName;
    [SerializeField] private string _jumpTriggerName;
    [SerializeField] private string _landTriggerName;
    

    private void OnJumpInitiated()
    {
        _animator.SetTrigger(_jumpChargeTriggerName);
        _animator.SetFloat("VerticalSpeed", 0);
    }
    private void OnJump()
    {
        _animator.ResetTrigger(_landTriggerName);
    }

    private void OnLand()
    {
        _animator.SetTrigger(_landTriggerName);
        _animator.ResetTrigger(_jumpChargeTriggerName);
    }

    private void OnVerticalVelocityChanged(float verticalVelocity)
    {
        _animator.SetFloat("VerticalSpeed", verticalVelocity);
    }

    private void OnEnable()
    {
        _jumpChargeHandler.Started += OnJumpInitiated; 
        _jumpHandler.Jumped += OnJump;
        _groundChecker.Landed += OnLand;
        _jumpHandler.VertiacalVelocityChanged += OnVerticalVelocityChanged;

    }

    private void OnDisable()
    {
        _jumpChargeHandler.Started -= OnJumpInitiated;
        _jumpHandler.Jumped -= OnJump;
        _groundChecker.Landed -= OnLand;
        _jumpHandler.VertiacalVelocityChanged -= OnVerticalVelocityChanged;
    }
}

