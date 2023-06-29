using Codebase.Services.JumpComboService;
using Codebase.Services.ScoreService;
using Lyaguska.Handlers;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class LandState : FrogState
    {
        private readonly JumpHandler _jumpHandler;
        private readonly IScoreService _scoreService;

        public LandState(FrogStateMachine context
        , JumpHandler jumpHandler
        , IScoreService scoreService) : base(context)
        {
            _jumpHandler = jumpHandler;
            _scoreService = scoreService;
        }

        public override void Enter()
        {
            _jumpHandler.HardLand();
            Context.Animator.SetLand();
            Context.FrogSound.PlayLand();
            _scoreService.SetLand();
            
            Context.ChangeState(Context.IdleState);
        }
    }
}