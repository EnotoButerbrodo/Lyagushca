using Cinemachine;
using Codebase.Services;
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
        [SerializeField] private BackgroundSound _backgroundSound;

        public override void InstallBindings()
        {
            IResetService resetService = BindResetService();
            IPauseService pauseService = BindPauseService();
            IActorFactory actorFactory = BindActorFactory();
            IInputService inputService = BindInputService();
            
            BindTimer();
            BindBackgroundSound();

            BindCameraService(resetService);
            BindDistanceCountService(resetService);
            BindJumpForceCharger(resetService, pauseService);
            BindLevelGeneration(resetService);
            BindActorSelectService(actorFactory, resetService);

            BindPlayerControlService(inputService, pauseService);
            BindProgressService();
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
        
        private IPauseService BindPauseService()
        {
            PauseService pause = new PauseService();

            Container
                .Bind<IPauseService>()
                .To<PauseService>()
                .FromInstance(pause)
                .AsSingle();

            return pause;
        }
        
        private IActorFactory BindActorFactory()
        {
            ActorFactory actorFactory = new ActorFactory(Container);

            Container
                .Bind<IActorFactory>()
                .To<ActorFactory>()
                .FromInstance(actorFactory)
                .AsSingle();

            return actorFactory;
        }
        
        private IInputService BindInputService()
        {
            var inputService = new InputService();

            Container
                .Bind<IInputService>()
                .To<InputService>()
                .FromInstance(inputService)
                .AsSingle();

            return inputService;
        }
        
        private void BindTimer()
        {
            Container
                .BindInterfacesAndSelfTo<Timer>()
                .FromInstance(new Timer())
                .AsTransient();
        }
        
        private void BindBackgroundSound()
        {
            Container
                .Bind<BackgroundSound>()
                .FromInstance(_backgroundSound)
                .AsSingle();
        }

        private void BindCameraService(IResetService resetService)
        {
            var camera = Container.InstantiatePrefabForComponent<CinemachineVirtualCamera>(_camera);
            Camera.main.AddComponent<CinemachineBrain>();
            
            CameraService cameraService = new CameraService(camera);

            Container
                .Bind<ICameraService>()
                .To<CameraService>()
                .FromInstance(cameraService)
                .AsSingle();
            
            resetService.Register(cameraService);
        }
        
        private void BindDistanceCountService(IResetService resetService)
        {
            var distanceCount = new DistanceCountService();

            Container
                .Bind<IDistanceCountService>()
                .To<DistanceCountService>()
                .FromInstance(distanceCount)
                .AsSingle();
            
            resetService.Register(distanceCount);
        }
        
        private void BindJumpForceCharger(IResetService resetService, IPauseService pauseService)
        {

            var jumpChargeService = Container
                .InstantiateComponentOnNewGameObject<JumpChargeService>();

            Container
                .Bind<IJumpChargeService>()
                .To<JumpChargeService>()
                .FromInstance(jumpChargeService)
                .AsSingle();
            
            resetService.Register(jumpChargeService);
            pauseService.Register(jumpChargeService);
        }
        
        private void BindLevelGeneration(IResetService resetService)
        {
            Transform chunksRoot = new GameObject(_chunksRootName).transform;
            ChunkFactory factory = new ChunkFactory(Container.Resolve<ChunksCollection>(), chunksRoot);
            
            LevelGenerationService generationService = new LevelGenerationService(Container.Resolve<LevelGenerationConfig>()
                , factory
                , Container.Resolve<IDistanceCountService>());

            Container
                .Bind<ILevelGenerationService>()
                .To<LevelGenerationService>()
                .FromInstance(generationService)
                .AsSingle();

            resetService.Register(generationService);
        }
        
        private void BindActorSelectService(IActorFactory actorFactory, IResetService resetService)
        {
            var actorSelectService = new ActorSelectService(actorFactory);
            Container
                .Bind<IActorSelectService>()
                .To<ActorSelectService>()
                .FromInstance(actorSelectService)
                .AsSingle();
            
            resetService.Register(actorSelectService);
        }

        private void BindPlayerControlService(IInputService inputService, IPauseService pause)
        {
            var controlsService = new ActorControllService(inputService);
            Container
                .Bind<IActorControllService>()
                .To<ActorControllService>()
                .FromInstance(controlsService)
                .AsSingle();
            
            pause.Register(controlsService);
        }
        
        private void BindProgressService()
        {
            Container
                .Bind<IProgressService>()
                .To<UnityProgressService>()
                .FromNew()
                .AsSingle();
        }
    }
}