using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class LevelCreateState : State
    {
        private ILevelGenerationService _generationService;
        private Vector2 _startPosition;

        public LevelCreateState(StateMachine stateMachine, ILevelGenerationService generationService, Vector2 startPosition) : base(stateMachine)
        {
            _generationService = generationService;
            _startPosition = startPosition;
        }

        public override void Enter()
        {
            GenerateStartLevel();
            _stateMachine.Enter<GameLoopState>();
        }

        private void GenerateStartLevel()
        {
            _generationService.SpawnStartChunks(_startPosition);
        }
    }
}