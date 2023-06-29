using Codebase.Services.JumpComboService;
using Codebase.Services.ScoreService;
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
        [SerializeField] private Collider2D _frogCollider;
        
        [Inject] private DiContainer _container;

        public FrogState GetIdleState(FrogStateMachine context)
            => new IdleState(context
                , _container.Resolve<IJumpChargeService>());

        public FrogState GetJumpChargeState(FrogStateMachine context)
            => new JumpChargeState(context
                , _container.Resolve<IJumpChargeService>());

        public FrogState GetJumpState(FrogStateMachine context)
            => new JumpState(context
                , _container.Resolve<IJumpChargeService>()
                , _jumpHandler
                , _container.Resolve<IScoreService>());

        public FrogState GetAirState(FrogStateMachine context)
            => new AirState(context
                , _container.Resolve<IJumpChargeService>()
                , _container.Resolve<ITimersService>()
                , _container.Resolve<JumpsConfig>());

        public FrogState GetLandState(FrogStateMachine context)
            => new LandState(context
                , _jumpHandler
                , _container.Resolve<IScoreService>());

        public FrogState GetDeadState(FrogStateMachine context)
            => new DeadState(context
                , _container.Resolve<IJumpChargeService>()
                , _frogCollider);
    }
}