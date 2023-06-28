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
        [SerializeField] private FrogAnimator _animation;
        [SerializeField] private FrogStateMachine _stateMachine;
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

        public override event Action Dead;

        public override bool IsDead => _isDead;

        public override bool Grounded => _groundChecker.IsGrounded();
        
        private bool _isDead;

        public override void HandleButtonPress()
        {
            _stateMachine.ButtonPressHandler();
        }

        public override void HandleButtonRelease()
        {
            _stateMachine.ButtonReleaseHandler();
        }

        public override void Die()
        {
            _stateMachine.ChangeState(_stateMachine.DeadState);
            Dead?.Invoke();
            _isDead = true;
        }

        public override void Reset()
        {
            _rigidbody2D.velocity = Vector2.up;
            _isDead = false;
            _animation.Reset();
            _stateMachine.Reset();
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
    }
}