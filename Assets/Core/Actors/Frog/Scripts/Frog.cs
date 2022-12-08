using Lyaguska.Core.Actors.StateMachine;
using System;
using UnityEngine;

namespace Lyaguska.Core
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
            add => _groundChecker.Landed += value;
            remove => _groundChecker.Landed -= value;
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

        //Буффер действий

        private Rigidbody2D _rigidbody2D => GetComponent<Rigidbody2D>();

        private FrogStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = GetComponent<FrogStateMachine>();
            _groundChecker.Landed += OnLand;
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