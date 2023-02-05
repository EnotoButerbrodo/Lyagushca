using System.ComponentModel;
using EnotoButebrodo;
using EnotoButerbrodo.LevelGeneration;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class BootstrapState : State
    {
        private DiContainer _container;

        public BootstrapState(StateMachine stateMachine, DiContainer container) : base(stateMachine)
        {
            _container = container;

            Bind();
        }

        public override void Enter()
        {
            _stateMachine.Enter<LevelCreateState>();
        }

        private void Bind()
        {
            BindConfigs();
            BindActorFactory();
            BindDistanceCounter();
            BindLevelGeneration();
            BindTimer();
            BindControls();
            BindPlayerControlService();
        }

        private void BindPlayerControlService()
        {
            var playerControlService = _container
                .Bind<PlayerControllService>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private void BindLevelGeneration()
        {
            var factory = new ChunkFactory(_container.Resolve<ChunksCollection>(), null);
            LevelGenerationService service = new LevelGenerationService(_container.Resolve<LevelGenerationConfig>(),
                factory, _container.Resolve<IDistanceCounter>());

            _container
                .Bind<ILevelGenerationService>()
                .To<LevelGenerationService>()
                .FromInstance(service)
                .AsSingle();
        }

        private void BindConfigs()
        {
            foreach (ScriptableObject config in Resources.LoadAll<ScriptableObject>("Configs"))
            {
                _container
                    .Bind(config.GetType())
                    .FromInstance(config)
                    .AsSingle();
            }
        }

        private void BindActorFactory()
        {
            ActorFactory actorFactory = new ActorFactory();
            actorFactory.LoadActors();
            
            actorFactory.SelectActor<Frog>();
            
            _container
                .Bind<IActorFactory>()
                .To<ActorFactory>()
                .FromInstance(actorFactory)
                .AsSingle();
        }

        private void BindDistanceCounter()
        {
            _container
                .Bind<IDistanceCounter>()
                .To<DistanceCounter>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
        
        private void BindControls()
        {
            _container
                .Bind<Controls>()
                .FromInstance(new Controls())
                .AsSingle()
                .NonLazy();
        }
        
        private void BindTimer()
        {
            _container
                .BindInterfacesAndSelfTo<Timer>()
                .FromInstance(new Timer())
                .AsTransient();
        }
    }
}