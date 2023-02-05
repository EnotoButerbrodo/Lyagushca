using System;
using System.Collections.Generic;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class GameStateMachine : StateMachine
    {
        private ILevelGenerationService _generationService;
        private Actor _actor;

        public GameStateMachine(ILevelGenerationService generationService, Actor actor)
        {
            _generationService = generationService;
            _actor = actor;
            _states = InitialStates();
        }

        protected override Dictionary<Type, IExitableState> InitialStates()
        {
            return new Dictionary<Type, IExitableState>()
            {
                [typeof(LevelCreateState)] = new LevelCreateState(this, _generationService, new Vector2(-15, -2)),
                [typeof(GameLoopState)] = new GameLoopState(this, _generationService, _actor),
                [typeof(GameResetState)] = new GameResetState(this)
            };
        }
    }
    
}