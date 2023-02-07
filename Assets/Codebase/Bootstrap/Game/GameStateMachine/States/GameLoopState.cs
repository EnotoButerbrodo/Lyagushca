using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : State
    {
        private ILevelGenerationService _generationService;
        private StaticData _staticData;
        private IDistanceCountService _distanceCount;
        private IActorControllService _controlls;
        private Actor _actor;

        public GameLoopState(StateMachine stateMachine, ILevelGenerationService generationService, StaticData staticData, IDistanceCountService distanceCount, IActorControllService controlls) : base(stateMachine)
        {
            _generationService = generationService;
            _staticData = staticData;
            _distanceCount = distanceCount;
            _controlls = controlls;
        }

        public override void Enter()
        {
            _actor = _staticData.CurrentActor;
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