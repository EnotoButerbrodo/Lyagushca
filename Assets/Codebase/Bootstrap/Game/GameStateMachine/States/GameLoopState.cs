using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : State, IUpdateableState
    {
        private readonly ILevelGenerationService _generationService;
        private readonly IDistanceCountService _distanceCount;
        private readonly IActorControllService _controlls;
        private readonly IActorSelectService _actorSelectService;
        private readonly IInterfaceService _interfaceService;

        private readonly IPauseService _pauseService;
        private Actor _actor;

        public GameLoopState(StateMachine stateMachine
            , ILevelGenerationService generationService
            , IActorSelectService actorSelectService
            , IDistanceCountService distanceCount
            , IActorControllService controlls
            , IPauseService pauseService
            , IInterfaceService interfaceService) : base(stateMachine)
        {
            _generationService = generationService;
            _actorSelectService = actorSelectService;
            _distanceCount = distanceCount;
            _controlls = controlls;
            _pauseService = pauseService;
            _interfaceService = interfaceService;
        }

        public override void Enter()
        {
            _actor = _actorSelectService.SelectedActor;
            _controlls.SetActor(_actor);
            _controlls.Enable();
            _actor.Dead += OnActorDeath;
            
            _interfaceService.ShowUI();
        }

        public override void Exit()
        {
           _actor.Dead -= OnActorDeath;
           _controlls.Disable();
           _interfaceService.HideUI();
        }

        private void OnActorDeath()
        {
            _stateMachine.Enter<GameOverState, int>(_distanceCount.Distance);

        }

        public void UpdateState()
        {
            if(_pauseService.IsPaused)
                return;
            
            _generationService.CheckChunksRelevance();
            _distanceCount.Update();
        }
    }
}