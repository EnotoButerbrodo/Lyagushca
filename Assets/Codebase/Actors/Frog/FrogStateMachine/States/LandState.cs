using Codebase.Services.JumpComboService;
using Lyaguska.Handlers;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class LandState : FrogState
    {
        private readonly JumpHandler _jumpHandler;
        private readonly IJumpComboService _jumpCombo;

        public LandState(FrogStateMachine context
        , JumpHandler jumpHandler
        , IJumpComboService jumpCombo) : base(context)
        {
            _jumpHandler = jumpHandler;
            _jumpCombo = jumpCombo;
        }

        public override void Enter()
        {
            _jumpHandler.HardLand();
            Context.Animator.SetLand();
            Context.FrogSound.PlayLand();
            _jumpCombo.SetLand();
            
            Context.ChangeState(Context.IdleState);
        }
    }
}