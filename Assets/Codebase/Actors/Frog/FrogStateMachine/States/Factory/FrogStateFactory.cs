using EnotoButebrodo;
using Lyaguska.Services;
using Zenject;

namespace Lyaguska.Actors.StateMachine
{
    public class FrogStateFactory : IFrogStateFactory
    {
        private readonly DiContainer _container;

        public FrogStateFactory(DiContainer container)
        {
            _container = container;
        }
        
        public FrogState GetIdleState(FrogStateMachine context)
            => new IdleState(context
                , _container.Resolve<IJumpChargeService>());

        public FrogState GetJumpChargeState(FrogStateMachine context)
            => new JumpChargeState(context
                , _container.Resolve<IJumpChargeService>());

        public FrogState GetJumpState(FrogStateMachine context)
            => new JumpState(context
                , _container.Resolve<IJumpChargeService>());

        public FrogState GetAirState(FrogStateMachine context)
            => new AirState(context
                , _container.Resolve<IJumpChargeService>()
                , _container.Resolve<ITimersService>());
        
    }
}