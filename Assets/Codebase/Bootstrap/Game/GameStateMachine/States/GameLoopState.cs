using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : State
    {
        private readonly ILevelGenerationService _generationService;
        private readonly IDistanceCountService _distanceCount;
        private readonly IActorControllService _controlls;
        private readonly IActorSelectService _actorSelectService;
        private readonly IScreenService _screenService;

        private Actor _actor;

        public GameLoopState(StateMachine stateMachine
            , ILevelGenerationService generationService
            , IActorSelectService actorSelectService
            , IDistanceCountService distanceCount
            , IActorControllService controlls
            , IScreenService screenService) : base(stateMachine)
        {
            _generationService = generationService;
            _actorSelectService = actorSelectService;
            _distanceCount = distanceCount;
            _controlls = controlls;
            _screenService = screenService;
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
           Time.timeScale = 1;
        }

        private void OnActorDeath()
        {
            float distance = _distanceCount.Distance;
            _screenService.ShowGameOverScreen(distance);
            Time.timeScale = 0;

        }

        public override void UpdateState()
        {
            _generationService.CheckChunksRelevance();
            _distanceCount.Update();
        }
    }
}