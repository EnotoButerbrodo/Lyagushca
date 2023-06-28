using Lyaguska.Handlers;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class LandState : FrogState
    {
        private readonly JumpHandler _jumpHandler;

        public LandState(FrogStateMachine context
        , JumpHandler jumpHandler) : base(context)
        {
            _jumpHandler = jumpHandler;
        }

        public override void Enter()
        {
            if(!Context.Actor.IsDead)
                _jumpHandler.HardLand();
            
            Context.Animator.SetLand();
            Context.ChangeState(Context.IdleState);
        }
    }
}