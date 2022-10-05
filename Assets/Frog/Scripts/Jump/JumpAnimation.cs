using UnityEngine;
public class JumpAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private JumpChargeHandler _jumpChargeHandler;
    [SerializeField] private JumpHandler _jumpHandler;
    [SerializeField] private GroundCheckHandler _groundChecker;

    [SerializeField] private string _JUMPCHARGE_TRIGGER;
    [SerializeField] private string _JUMP_TRIGGER;
    [SerializeField] private string _LAND_TRIGGER;
    [SerializeField] private string _VERTICALSPEED_TRIGGER;

    private int _jumpChargeHash;
    private int _jumpHash;
    private int _landHash;
    private int _verticalSpeedHash;

    private void Awake()
    {
        _jumpChargeHash = Animator.StringToHash(_JUMPCHARGE_TRIGGER);
        _jumpHash = Animator.StringToHash(_JUMP_TRIGGER);
        _landHash = Animator.StringToHash(_LAND_TRIGGER);
        _verticalSpeedHash = Animator.StringToHash(_VERTICALSPEED_TRIGGER);
    }


    private void OnJumpInitiated()
    {
        _animator.SetTrigger(_jumpChargeHash);
        _animator.SetFloat(_verticalSpeedHash, 0);
    }
    private void OnJump()
    {
        _animator.ResetTrigger(_landHash);
        _animator.SetTrigger(_jumpHash);
    }

    private void OnLand()
    {
        _animator.SetTrigger(_landHash);
        _animator.ResetTrigger(_jumpChargeHash);
        _animator.ResetTrigger(_jumpHash);
    }

    private void OnVerticalVelocityChanged(float verticalVelocity)
    {
        _animator.SetFloat(_verticalSpeedHash, verticalVelocity);
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

