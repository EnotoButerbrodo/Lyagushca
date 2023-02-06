using Cinemachine;
using EnotoButebrodo;
using EnotoButerbrodo.LevelGeneration;
using Lyaguska.Services;
using UnityEngine;
using Zenject;
using Unity.VisualScripting;
using Timer = EnotoButebrodo.Timer;

namespace Lyaguska.Bootstrap.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private string _chunksRootName = "-----Level-----";
        private IResetService _resetService;
        
        public override void InstallBindings()
        {
            _resetService = BindResetService();
            
            BindActorFactory();
            BindPlayerControlService();
            BindDistanceCountService();
            BindTimer();
            BindLevelGeneration();
            BindJumpForceCharger();
            BindCameraService();
            
        }

        private IResetService BindResetService()
        {
            ResetService resetService = new ResetService();
            Container
                .Bind<IResetService>()
                .To<ResetService>()
                .FromInstance(resetService)
                .AsSingle();

            return resetService;
        }

        private void BindCameraService()
        {
            var camera = Container.InstantiatePrefabForComponent<CinemachineVirtualCamera>(_camera);
            Camera.main.AddComponent<CinemachineBrain>();
            
            CameraService cameraService = new CameraService(camera);

            Container
                .Bind<ICameraService>()
                .To<CameraService>()
                .FromInstance(cameraService)
                .AsSingle();
            
            _resetService.Register(cameraService);
        }

        private void BindActorFactory()
        {
            var factory = new ActorFactory(Container);
            factory.Load();

            Container
                .Bind<IActorFactory>()
                .To<ActorFactory>()
                .FromInstance(factory)
                .AsSingle();
        }

        private void BindDistanceCountService()
        {
            var distanceCount = new DistanceCountService();

            Container
                .Bind<IDistanceCountService>()
                .To<DistanceCountService>()
                .FromInstance(distanceCount)
                .AsSingle();
            
            _resetService.Register(distanceCount);
        }

        private void BindTimer()
        {
            Container
                .BindInterfacesAndSelfTo<Timer>()
                .FromInstance(new Timer())
                .AsTransient();
        }
        
        private void BindLevelGeneration()
        {
            Transform chunksRoot = new GameObject(_chunksRootName).transform;
            ChunkFactory factory = new ChunkFactory(Container.Resolve<ChunksCollection>(), chunksRoot);
            LevelGenerationService generationService = new LevelGenerationService(Container.Resolve<LevelGenerationConfig>(),
                factory, Container.Resolve<IDistanceCountService>());

            Container
                .Bind<ILevelGenerationService>()
                .To<LevelGenerationService>()
                .FromInstance(generationService)
                .AsSingle();
            
            _resetService.Register(generationService);
        }
        
        private void BindPlayerControlService()
        {
            Container
                .Bind<IActorControllService>()
                .To<ActorControllService>()
                .FromNew()
                .AsSingle();
        }
        
        private void BindJumpForceCharger()
        {

            var jumpChargeService = Container
                    .InstantiateComponentOnNewGameObject<JumpChargeService>();

            Container
                .Bind<IJumpChargeService>()
                .To<JumpChargeService>()
                .FromInstance(jumpChargeService)
                .AsSingle();
            
            _resetService.Register(jumpChargeService);
        }
    }
}