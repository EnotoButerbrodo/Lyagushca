using System;
using System.Collections.Generic;
using Codebase.Bootstrap.Config;
using Codebase.Services;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;
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

        protected override Dictionary<Type, IExitableState> InitialStates() =>
            new Dictionary<Type, IExitableState>()
            {
                [typeof(LevelCreateState)] = GetLevelCreateState(),
                [typeof(ActorSpawnState)] = GetActorSpawnState(),
                [typeof(GameLoopState)] = GetGameLoopState(),
                [typeof(GameResetState)] = GetGameResetState(),
                [typeof(PauseState)] = GetPauseState()
            };

        private PauseState GetPauseState() 
            => new PauseState(this,
                _container.Resolve<IInputService>());

        private LevelCreateState GetLevelCreateState() =>
             new LevelCreateState(this
                    , _container.Resolve<ILevelGenerationService>()
                    , _container.Resolve<StartupConfig>().GenerationStartPosition);

        private ActorSpawnState GetActorSpawnState() =>
            new ActorSpawnState(this
                , _container.Resolve<IActorFactory>()
                , _container.Resolve<ICameraService>()
                , _container.Resolve<IDistanceCountService>()
                , _container.Resolve<StaticData>()
                , _container.Resolve<StartupConfig>().ActorStartPosition);

        private GameLoopState GetGameLoopState() =>
            new GameLoopState(this
                , _container.Resolve<ILevelGenerationService>()
                , _container.Resolve<StaticData>()
                , _container.Resolve<IDistanceCountService>()
                , _container.Resolve<IActorControllService>());

        private GameResetState GetGameResetState() =>
            new GameResetState(this
                , _container.Resolve<IResetService>());
    }
    
}