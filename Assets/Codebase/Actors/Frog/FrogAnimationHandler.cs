using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Actors
{
    public class FrogAnimationHandler : MonoBehaviour
    {
        private IJumpForceCharger _jumpChargeHandler;

        [SerializeField] private Animator _animator;

        [SerializeField] Actor _actor;

        [SerializeField] private string _JUMPCHARGE_TRIGGER;
        [SerializeField] private string _JUMP_TRIGGER;
        [SerializeField] private string _LAND_TRIGGER;
        [SerializeField] private string _GROUNDED = "Grounded";
        [SerializeField] private string _VERTICALSPEED_TRIGGER;
        [SerializeField] private string _CHARGEPERCENT_TRIGGER;

        [Header("Hop")]
        [SerializeField][Range(0, 1f)] private float _hopLevel = 0.25f;
        [SerializeField] private string _HOP_TRIGGER;

        private int _jumpChargeHash;
        private int _jumpHash;
        private int _hopHash;
        private int _groundedHash;
        private int _verticalSpeedHash;
        private int _chargePercentHash;

        [Inject]
        private void Construct(IJumpForceCharger charger)
        {
            _jumpChargeHandler = charger;
        }

        private void Awake()
        {
            _jumpChargeHash = Animator.StringToHash(_JUMPCHARGE_TRIGGER);
            _jumpHash = Animator.StringToHash(_JUMP_TRIGGER);
            _hopHash = Animator.StringToHash(_HOP_TRIGGER);
            _groundedHash = Animator.StringToHash(_GROUNDED);
            _verticalSpeedHash = Animator.StringToHash(_VERTICALSPEED_TRIGGER);
            _chargePercentHash = Animator.StringToHash(_CHARGEPERCENT_TRIGGER);
        }

        private void OnJumpInitiated(float percent)
        {
            _animator.SetTrigger(_jumpChargeHash);
            _animator.SetFloat(_verticalSpeedHash, 0);
        }
        private void OnJump()
        {
            _animator.SetBool(_groundedHash, false);
            _animator.SetTrigger(_jumpHash);
            
            if(_jumpChargeHandler.ChargePercent <= _hopLevel)
            {
                _animator.SetTrigger(_hopHash);
            }
        }

        private void OnLand()
        {
            _animator.SetFloat(_verticalSpeedHash, 0);
            _animator.SetBool(_groundedHash, true);
            _animator.ResetTrigger(_jumpChargeHash);
            _animator.ResetTrigger(_jumpHash);
        }

        private void OnVelocityChanged(Vector2 velocity)
        {
            _animator.SetFloat(_verticalSpeedHash, velocity.y);
        }

        private void OnChargePercentChanged(float chargePercent)
        {
            _animator.SetFloat(_chargePercentHash, chargePercent);
        }

        private void OnEnable()
        {
            _jumpChargeHandler.ChargeBegin += OnJumpInitiated;
            _jumpChargeHandler.ChargePercentChanged += OnChargePercentChanged;
            _actor.Jumped += OnJump;
            _actor.GroundLand += OnLand;
            _actor.VelocityChanged += OnVelocityChanged;

        }

        private void OnDisable()
        {
            _jumpChargeHandler.ChargeBegin -= OnJumpInitiated;
            _jumpChargeHandler.ChargePercentChanged -= OnChargePercentChanged;
            _actor.Jumped -= OnJump;
            _actor.GroundLand -= OnLand;
            _actor.VelocityChanged -= OnVelocityChanged;
        }
    }
}