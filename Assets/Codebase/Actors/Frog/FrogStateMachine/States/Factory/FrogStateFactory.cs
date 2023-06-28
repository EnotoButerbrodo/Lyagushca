using EnotoButebrodo;
using Lyaguska.Handlers;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Actors.StateMachine
{
    public class FrogStateFactory : MonoBehaviour
    {
        [SerializeField] private JumpHandler _jumpHandler;
        [SerializeField] private FrogSoundHandler _frogSound;
        [Inject] private DiContainer _container;

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

        public FrogState GetLandState(FrogStateMachine context)
            => new LandState(context, _jumpHandler);
    }
}