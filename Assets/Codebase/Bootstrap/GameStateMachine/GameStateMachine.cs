using System;
using System.Collections.Generic;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class GameStateMachine : StateMachine
    {
        private ILevelGenerationService _generationService;

        public GameStateMachine(ILevelGenerationService generationService)
        {
            _generationService = generationService;
            _states = InitialStates();
        }

        protected override Dictionary<Type, IExitableState> InitialStates()
        {
            return new Dictionary<Type, IExitableState>()
            {
                [typeof(LevelCreateState)] = new LevelCreateState(this, _generationService, new Vector2(-15, -2)),
                [typeof(GameLoopState)] = new GameLoopState(this, _generationService)
            };
        }
    }
    
}