using System;
using System.Runtime.InteropServices;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Actors
{
    public class FrogAnimator : MonoBehaviour, IResetable, IPauseable
    {
        [SerializeField] private Animator _animator;

        public string IsJumpChargingName = "IsJumpCharging";
        public string JumpChargePercentName = "JumpChargePercent";
        public string JumpName = "Jump";
        public string GroundedName = "Grounded";
        public string FallName = "Fall";
        public string FallVelocityName = "FallVelocity";
        
        private int _isJumpCharging;
        private int _jumpChargePercent;
        private int _jump;
        private int _grounded;
        private int _fall;
        private int _fallVelocity;


        public void SetJumpCharging(bool state)
        {
            _animator.SetBool(_isJumpCharging, state);
        }

        public void SetJumpChargePercent(float value)
        {
            _animator.SetFloat(_jumpChargePercent, value);
        }

        public void SetJump()
        {
            _animator.ResetTrigger(_fall);
            _animator.SetTrigger(_jump);
        }

        public void SetGrounded(bool state)
        {
            _animator.SetBool(_grounded, state);
        }

        public void SetFallVelocity(float value)
        {
            _animator.SetFloat(_fallVelocity, value);
        }

        public void SetFall()
        {
            _animator.SetTrigger(_fall);
        }

        private void Awake()
        {
            _isJumpCharging = Animator.StringToHash(IsJumpChargingName);
            _jumpChargePercent = Animator.StringToHash(JumpChargePercentName);
            _jump = Animator.StringToHash(JumpName);
            _grounded = Animator.StringToHash(GroundedName);
            _fall = Animator.StringToHash(FallName);
            _fallVelocity = Animator.StringToHash(FallVelocityName);
        }

        public void Reset()
        {
            _animator.Rebind();
            _animator.Update(0f);
        }

        public void Pause()
        {
            _animator.speed = 0;
        }

        public void Resume()
        {
            _animator.speed = 1;
            _isJumpCharging = Animator.StringToHash(IsJumpChargingName);
        }
    }
}