using System;
using Lyaguska.Actors.Frog.StateMachine;
using Lyaguska.Core;
using UnityEngine;

namespace Lyaguska.Actors.Frog
{
    public class Frog : Actor
    {
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
            add => _dieHandler.Dead += value;
            remove => _dieHandler.Dead -= value;
        }

        public override bool Grounded => _groundChecker.IsGrounded();

        [SerializeField] private JumpHandler _jumpHandler;
        [SerializeField] private GroundCheckHandler _groundChecker;
        [SerializeField] private DieHandler _dieHandler;

        private Rigidbody2D _rigidbody2D;

        private FrogStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = GetComponent<FrogStateMachine>();
            _groundChecker.Grounded += OnLand;
            _rigidbody2D = GetComponent<Rigidbody2D>();
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

        public override void Reset()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        private void OnLand()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

  


    }
}