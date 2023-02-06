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
        public override void InstallBindings()
        {
            BindActorFactory();
            BindPlayerControlService();
            BindDistanceCounter();
            BindTimer();
            BindLevelGeneration();
            BindJumpForceCharger();
            BindCameraService();
        }

        private void BindCameraService()
        {
            var camera = Container.InstantiatePrefabForComponent<CinemachineVirtualCamera>(_camera);
            Camera.main.AddComponent<CinemachineBrain>();
            
            CameraService service = new CameraService(camera);

            Container
                .Bind<ICameraService>()
                .To<CameraService>()
                .FromInstance(service)
                .AsSingle();
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

        private void BindDistanceCounter()
        {
            Container
                .Bind<IDistanceCountService>()
                .To<DistanceCountService>()
                .FromNew()
                .AsSingle();
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
            var factory = new ChunkFactory(Container.Resolve<ChunksCollection>(), null);
            LevelGenerationService service = new LevelGenerationService(Container.Resolve<LevelGenerationConfig>(),
                factory, Container.Resolve<IDistanceCountService>());

            Container
                .Bind<ILevelGenerationService>()
                .To<LevelGenerationService>()
                .FromInstance(service)
                .AsSingle();
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

            var jumpForceChargerInstance =
                Container
                    .InstantiateComponentOnNewGameObject<JumpChargeService>();

            Container
                .Bind<IJumpChargeService>()
                .To<JumpChargeService>()
                .FromInstance(jumpForceChargerInstance)
                .AsSingle();
        }
    }
}