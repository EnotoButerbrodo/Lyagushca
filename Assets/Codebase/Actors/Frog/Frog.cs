using System;
using Lyaguska.Actors.StateMachine;
using Lyaguska.Handlers;
using UnityEngine;

namespace Lyaguska.Actors
{
    public class Frog : Actor 
    {
        [SerializeField] private JumpHandler _jumpHandler;
        [SerializeField] private GroundCheckHandler _groundChecker;
        [SerializeField] private FrogDieHandler _frogDie;
        [SerializeField] private FrogAnimator _animation;
        [SerializeField] private Rigidbody2D _rigidbody2D;


        public override event Action Jumped
        {
            add => _jumpHandler.Jumped += value;
            remove => _jumpHandler.Jumped -= value;
        }

        public override event Action GroundLand
        {
            add => _groundChecker.Grounded += value;
            remove => _groundChecker.Grounded -= value;
        }

        public override event Action<Vector2> VelocityChanged
        {
            add => _jumpHandler.VelocityChanged += value;
            remove => _jumpHandler.VelocityChanged -= value;
        }

        public override event Action Dead
        {
            add => _frogDie.Dead += value;
            remove => _frogDie.Dead -= value;
        }

        public override bool IsDead => _frogDie.IsDead;

        public override bool Grounded => _groundChecker.IsGrounded();


        private FrogStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = GetComponent<FrogStateMachine>();
            _groundChecker.Grounded += OnLand;
        }

        public override void HandleButtonPress()
        {
            _stateMachine.ButtonPressHandler();
        }

        public override void HandleButtonRelease()
        {
            _stateMachine.ButtonReleaseHandler();
        }

        public override void Jump(float chargePercent)
        {
            if (_groundChecker.IsGrounded() == false)
            {
                return;
            }
            _jumpHandler.Jump(chargePercent);
        }

        public override void Die()
        {
            _frogDie.Die();
        }

        public override void Reset()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _frogDie.Reset();
            _animation.Reset();
        }

        public override void Pause()
        {
            _rigidbody2D.simulated = false;
            _animation.Pause();
        }

        public override void Resume()
        {
            _rigidbody2D.simulated = true;
            _animation.Resume();
        }

        private void OnLand()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

    }
}