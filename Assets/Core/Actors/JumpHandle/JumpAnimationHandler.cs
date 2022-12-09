using System;
using UnityEngine;
using Zenject;

namespace Lyaguska.Core
{


    public class JumpAnimationHandler : MonoBehaviour
    {
        private IJumpForceCharger _jumpChargeHandler;

        [SerializeField] private Animator _animator;

        [SerializeField] Actor _actor;

        [SerializeField] private string _JUMPCHARGE_TRIGGER;
        [SerializeField] private string _JUMP_TRIGGER;
        [SerializeField] private string _LAND_TRIGGER;
        [SerializeField] private string _VERTICALSPEED_TRIGGER;
        [SerializeField] private string _CHARGEPERCENT_TRIGGER;

        private int _jumpChargeHash;
        private int _jumpHash;
        private int _landHash;
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
            _landHash = Animator.StringToHash(_LAND_TRIGGER);
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
            _animator.ResetTrigger(_landHash);
            _animator.SetTrigger(_jumpHash);
        }

        private void OnLand()
        {
            _animator.SetTrigger(_landHash);
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