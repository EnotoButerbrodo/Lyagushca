using System;
using System.Collections.Generic;
using Codebase.Bootstrap.Config;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class GameStateFactory : IStateFactory
    {
        private DiContainer _container;

        public GameStateFactory(DiContainer container)
        {
            _container = container;
        }

        public Dictionary<Type, IExitableState> GetStates(StateMachine owner) =>
            new Dictionary<Type, IExitableState>()
            {
                [typeof(TittleScreenState)] = GetGameStartState(owner),
                [typeof(LevelCreateState)] = GetLevelCreateState(owner),
                [typeof(ActorSpawnState)] = GetActorSpawnState(owner),
                [typeof(GameLoopState)] = GetGameLoopState(owner),
                [typeof(GameResetState)] = GetGameResetState(owner),
                [typeof(GameOverState)] = GetGameOverState(owner)
            };

        private IExitableState GetGameStartState(StateMachine owner)
            => new TittleScreenState(owner
                , _container.Resolve<IInterfaceService>()
                , _container.Resolve<IGame>()
                , _container.Resolve<BackgroundSound>());
        

        private IExitableState GetGameOverState(StateMachine owner)
            => new GameOverState(owner
                , _container.Resolve<IInterfaceService>()
                , _container.Resolve<IGame>()
                , _container.Resolve<BackgroundSound>()
                , _container.Resolve<ICameraService>()
                , _container.Resolve<IProgressService>());

        private IExitableState GetLevelCreateState(StateMachine owner) =>
            new LevelCreateState(owner
                , _container.Resolve<ILevelGenerationService>()
                , _container.Resolve<StartupConfig>().GenerationStartPosition);

        private IExitableState GetActorSpawnState(StateMachine owner) =>
            new ActorSpawnState(owner
                , _container.Resolve<ICameraService>()
                , _container.Resolve<IDistanceCountService>()
                , _container.Resolve<IActorSelectService>()
                , _container.Resolve<StartupConfig>().ActorStartPosition);

        private IExitableState GetGameLoopState(StateMachine owner) =>
            new GameLoopState(owner
                , _container.Resolve<ILevelGenerationService>()
                , _container.Resolve<IActorSelectService>()
                , _container.Resolve<IDistanceCountService>()
                , _container.Resolve<IActorControllService>()
                , _container.Resolve<IGame>()
                , _container.Resolve<IInterfaceService>());

        private IExitableState GetGameResetState(StateMachine owner) =>
            new GameResetState(owner
                , _container.Resolve<IResetService>());
    }
}