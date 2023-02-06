using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : PayloadedState<Actor>
    {
        private ILevelGenerationService _generationService;
        private IActorFactory _actorFactory;
        private IDistanceCountService _distanceCount;
        private IActorControllService _controlls;
        private Actor _actor;

        public GameLoopState(StateMachine stateMachine
            , ILevelGenerationService generationService
            , IDistanceCountService distanceCount
            , IActorControllService controlls) : base(stateMachine)
        {
            _generationService = generationService;
            _distanceCount = distanceCount;
            _controlls = controlls;
        }

        public override void Enter(Actor actor)
        {
            _actor = actor;
            
            _controlls.Enable(_actor);
            _distanceCount.SetTarget(_actor.transform);
            _actor.Dead += OnActorDeath;
        }

        public override void Exit()
        {
           _actor.Dead -= OnActorDeath;
           _controlls.Disable();
        }

        private void OnActorDeath()
        {
            _stateMachine.Enter<GameResetState>();
            
        }

        public override void UpdateState()
        {
            _generationService.CheckChunksRelevance();
            _distanceCount.Update();
        }
    }
}