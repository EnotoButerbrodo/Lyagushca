﻿using Codebase.Services.JumpComboService;
using Codebase.Services.ScoreService;
using Lyaguska.Handlers;
using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class JumpState : FrogState
    {
        private IJumpChargeService _charger;
        private readonly JumpHandler _jumpHandler;
        private readonly ScoreService _scoreService;

        public JumpState(FrogStateMachine context
            , IJumpChargeService charger
            , JumpHandler jumpHandler
            , ScoreService scoreService) : base(context)
        {
            _charger = charger;
            _jumpHandler = jumpHandler;
            _scoreService = scoreService;
        }

        public override void Enter()
        {
            if (_charger.ChargePercent == 0)
            {
                Context.ChangeState(Context.IdleState);
                return;
            }

            var percent = _charger.ChargePercent;
            
            _jumpHandler.Jump(percent);
            Context.Animator.SetJump();
            Context.FrogSound.PlayJump();
            _scoreService.SetJump();
            _charger.Reset();
            
            Context.ChangeState(Context.AirState);
        }
        
        

      
    }

    
}
