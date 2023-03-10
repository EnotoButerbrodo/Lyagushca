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

        private readonly IGame _game;
        private Actor _actor;

        public GameLoopState(StateMachine stateMachine
            , ILevelGenerationService generationService
            , IActorSelectService actorSelectService
            , IDistanceCountService distanceCount
            , IActorControllService controlls
            , IGame game) : base(stateMachine)
        {
            _generationService = generationService;
            _actorSelectService = actorSelectService;
            _distanceCount = distanceCount;
            _controlls = controlls;
            _game = game;
        }

        public override void Enter()
        {
            _actor = _actorSelectService.SelectedActor;
            _controlls.SetActor(_actor);
            _controlls.Enable();
            _actor.Dead += OnActorDeath;
        }

        public override void Exit()
        {
           _actor.Dead -= OnActorDeath;
           _controlls.Disable();
        }

        private void OnActorDeath()
        {
            _game.Pause();
            _stateMachine.Enter<GameOverState, float>(_distanceCount.Distance);

        }

        public override void UpdateState()
        {
            if(_game.IsPaused)
                return;
            
            _generationService.CheckChunksRelevance();
            _distanceCount.Update();
        }
    }
}