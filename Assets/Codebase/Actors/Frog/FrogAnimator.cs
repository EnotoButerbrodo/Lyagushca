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
        public string LandName = "Land";
        public string FallName = "Fall";
        public string FallVelocityName = "FallVelocity";
        public string HopName = "Hop";
        public string HurtName = "Hurt";
        
        private int _isJumpCharging;
        private int _jumpChargePercent;
        private int _jump;
        private int _land;
        private int _fall;
        private int _fallVelocity;
        private int _hop;
        private int _hurt;


        private void Awake()
        {
            _isJumpCharging = Animator.StringToHash(IsJumpChargingName);
            _jumpChargePercent = Animator.StringToHash(JumpChargePercentName);
            _jump = Animator.StringToHash(JumpName);
            _land = Animator.StringToHash(LandName);
            _fall = Animator.StringToHash(FallName);
            _fallVelocity = Animator.StringToHash(FallVelocityName);
            _hop = Animator.StringToHash(HopName);
            _hurt = Animator.StringToHash(HurtName);
        }

        public void SetJumpCharging(bool state) 
            => _animator.SetBool(_isJumpCharging, state);

        public void SetJumpChargePercent(float value) 
            => _animator.SetFloat(_jumpChargePercent, value);

        public void SetJump() 
            => _animator.SetTrigger(_jump);

        public void SetLand() 
            => _animator.SetTrigger(_land);

        public void SetFallVelocity(float value) 
            => _animator.SetFloat(_fallVelocity, value);

        public void SetFall() 
            => _animator.SetTrigger(_fall);

        public void SetHop() 
            => _animator.SetTrigger(_hop);

        public void SetHurt()
            => _animator.SetTrigger(_hurt);

        public void Reset()
        {
            _animator.Rebind();
            _animator.Update(-1f);
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