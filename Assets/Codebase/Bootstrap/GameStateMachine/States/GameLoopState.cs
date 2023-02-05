using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : State
    {
        private ILevelGenerationService _generationService;
        private Actor _currentActor;

        public GameLoopState(StateMachine stateMachine, ILevelGenerationService generationService, Actor currentActor) : base(stateMachine)
        {
            _generationService = generationService;
            _currentActor = currentActor;
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