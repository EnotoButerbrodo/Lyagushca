using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class DeadState : FrogState
    {
        private readonly IJumpChargeService _charger;
        private readonly Collider2D _frogCollider;
        
        public DeadState(FrogStateMachine context
            , IJumpChargeService charger
            , Collider2D frogCollider) : base(context)
        {
            _charger = charger;
            _frogCollider = frogCollider;
        }

        public override void Enter()
        {
            Context.Animator.SetHurt();
            Context.FrogSound.PlayDead();
            SetColliderActiveTo(false);
            _charger.Reset();
        }

        public override void Exit()
        {
            SetColliderActiveTo(true);
        }

        private void SetColliderActiveTo(bool state)
        {
            _frogCollider.enabled = state;
        }
    }
}