using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : State
    {
        private readonly ILevelGenerationService _generationService;
        private readonly IDistanceCountService _distanceCount;
        private readonly IActorControllService _controlls;
        private readonly IActorSelectService _actorSelectService;

        private Actor _actor;

        public GameLoopState(StateMachine stateMachine
            , ILevelGenerationService generationService
            , IActorSelectService actorSelectService
            , IDistanceCountService distanceCount
            , IActorControllService controlls) : base(stateMachine)
        {
            _generationService = generationService;
            _actorSelectService = actorSelectService;
            _distanceCount = distanceCount;
            _controlls = controlls;
        }

        public override void Enter()
        {
            _actor = _actorSelectService.SelectedActor;
            _controlls.Enable(_actor);
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