using System;
using System.Collections.Generic;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class GameStateMachine : StateMachine
    {
        private DiContainer _container;

        public GameStateMachine(DiContainer container)
        {
            _container = container; 
            _states = InitialStates();
        }

        protected override Dictionary<Type, IExitableState> InitialStates()
        {
            return new Dictionary<Type, IExitableState>()
            {
                [typeof(LevelCreateState)] 
                    = new LevelCreateState(this, _container.Resolve<ILevelGenerationService>(), new Vector2(-15, -2)),
                [typeof(ActorSpawnState)] 
                    = new ActorSpawnState(this, _container.Resolve<IActorFactory>(), _container.Resolve<ICameraService>() ,new Vector2(-10, -2)) ,
                [typeof(GameLoopState)] 
                    = new GameLoopState(this, _container.Resolve<ILevelGenerationService>(), _container.Resolve<IDistanceCountService>(), _container.Resolve<IActorControllService>()),
                [typeof(GameResetState)] 
                    = new GameResetState(this)
            };
        }
    }
    
}