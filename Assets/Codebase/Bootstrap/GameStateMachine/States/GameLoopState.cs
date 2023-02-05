using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : State
    {
        private ILevelGenerationService _generationService;
        private IActorFactory _actorFactory;
        private Actor _currentActor;

        public GameLoopState(StateMachine stateMachine, ILevelGenerationService generationService, IActorFactory actorFactory) : base(stateMachine)
        {
            _generationService = generationService;
            _actorFactory = actorFactory;
            _currentActor = _actorFactory.CurrentActor;
        }

        public override void Enter()
        {
            _currentActor.Dead += OnActorDeath;
        }

        private void OnActorDeath()
        {
            _stateMachine.Enter<GameResetState>();
            
        }

        public override void UpdateState()
        {
            _generationService.CheckChunksRelevance();
        }

        public override void Exit()
        {
            _currentActor.Dead -= OnActorDeath;
        }
    }
}