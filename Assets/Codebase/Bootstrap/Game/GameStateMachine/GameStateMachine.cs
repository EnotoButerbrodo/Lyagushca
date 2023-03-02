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
                [typeof(GameStartState)] = GetGameStartState(),
                [typeof(LevelCreateState)] = GetLevelCreateState(),
                [typeof(ActorSpawnState)] = GetActorSpawnState(),
                [typeof(GameLoopState)] = GetGameLoopState(),
                [typeof(GameResetState)] = GetGameResetState(),
                [typeof(GameOverState)] = GetGameOverState()
            };

        private IExitableState GetGameStartState()
            => new GameStartState(this
            , _container.Resolve<IScreenService>());
        

        private IExitableState GetGameOverState()
            => new GameOverState(this
                , _container.Resolve<IScreenService>());
                

        
        private IExitableState GetLevelCreateState() =>
             new LevelCreateState(this
                    , _container.Resolve<ILevelGenerationService>()
                    , _container.Resolve<StartupConfig>().GenerationStartPosition);

        private IExitableState GetActorSpawnState() =>
            new ActorSpawnState(this
                , _container.Resolve<ICameraService>()
                , _container.Resolve<IDistanceCountService>()
                , _container.Resolve<IActorSelectService>()
                , _container.Resolve<StartupConfig>().ActorStartPosition);

        private IExitableState GetGameLoopState() =>
            new GameLoopState(this
                , _container.Resolve<ILevelGenerationService>()
                , _container.Resolve<IActorSelectService>()
                , _container.Resolve<IDistanceCountService>()
                , _container.Resolve<IActorControllService>()
                , _container.Resolve<IGame>());

        private IExitableState GetGameResetState() =>
            new GameResetState(this
                , _container.Resolve<IResetService>());
    }
    
}