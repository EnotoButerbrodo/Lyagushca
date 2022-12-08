using System;
using Zenject;

namespace Lyaguska.Core.Actors.StateMachine
{
    public class JumpChargeState : ActorState
    {
        private IJumpForceCharger _charger;
        public JumpChargeState(ActorStateMachine stateMachine, IJumpForceCharger charger) : base(stateMachine)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            if(_charger.ChargePercent == 0)
            {
                _charger.StartCharge();
            }
        }

        //public override void HandleButtonPress()
        //{
        //    _charger.StartCharge();

        //}

        public override void HandleButtonRelease()
        {
            _charger.StopCharge();
            if (_stateMachine.Actor.Grounded)
            {
                _stateMachine.SetState(_stateMachine.JumpState);
            }else
            {
                _stateMachine.SetState(_stateMachine.BufferedJumpState);
            }
        }
    }



}