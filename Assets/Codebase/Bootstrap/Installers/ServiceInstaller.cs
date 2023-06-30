using Cinemachine;
using Codebase.Services;
using Codebase.Services.JumpComboService;
using Codebase.Services.ScoreService;
using EnotoButebrodo;
using EnotoButerbrodo.LevelGeneration;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

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
            ICoroutineRunner coroutineRunner = BindCoroutineRunner();
            IDistanceCountService distanceCount = BindDistanceCountService(resetService);
            
            ITimersService timersService = BindTimerService(pauseService);
            IJumpCombo jumpCombo = BindJumpCombo(timersService, resetService);
            
            BindScoreService(resetService, distanceCount, timersService, jumpCombo);
            BindBackgroundSound();

            BindCameraService(resetService);
            BindJumpForceCharger(resetService, pauseService, coroutineRunner);
            BindLevelGeneration(resetService, distanceCount);
            BindActorSelectService(actorFactory, resetService);

            BindPlayerControlService(inputService, pauseService);
            BindProgressService();
            BindDieCheckService();
        }
        


        private ICoroutineRunner BindCoroutineRunner()
        {
            CoroutineRunner runner = Container
                .InstantiateComponentOnNewGameObject<CoroutineRunner>();

            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(runner)
                .AsSingle();

            return runner;
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

        private ITimersService BindTimerService(IPauseService pause)
        {
            var timers = Container
                .InstantiateComponentOnNewGameObject<TimersService>();
            
            Container
                .Bind<ITimersService>()
                .To<TimersService>()
                .FromInstance(timers)
                .AsSingle();
            
            pause.Register(timers);

            return timers;
        }

        private void BindBackgroundSound()
        {
            var backgroundSound = GameObject.Instantiate(_backgroundSound);
            
            Container
                .Bind<BackgroundSound>()
                .FromInstance(backgroundSound)
                .AsSingle();
        }

        private void BindCameraService(IResetService resetService)
        {
            var camera = Container.InstantiatePrefabForComponent<CinemachineVirtualCamera>(_camera);

            CameraFollowFollowService cameraFollowFollowService = new CameraFollowFollowService(camera);

            Container
                .Bind<ICameraFollowService>()
                .To<CameraFollowFollowService>()
                .FromInstance(cameraFollowFollowService)
                .AsSingle();
            
            resetService.Register(cameraFollowFollowService);
        }

        private IDistanceCountService BindDistanceCountService(IResetService resetService)
        {
            var distanceCount = new DistanceCountService();

            Container
                .Bind<IDistanceCountService>()
                .To<DistanceCountService>()
                .FromInstance(distanceCount)
                .AsSingle();
            
            resetService.Register(distanceCount);

            return distanceCount;
        }

        private void BindJumpForceCharger(IResetService resetService
            , IPauseService pauseService
            , ICoroutineRunner coroutineRunner)
        {
            var jumpChargeService = new JumpChargeService(Container.Resolve<JumpsConfig>()
                , coroutineRunner);

            Container
                .Bind<IJumpChargeService>()
                .To<JumpChargeService>()
                .FromInstance(jumpChargeService)
                .AsSingle();
            
            resetService.Register(jumpChargeService);
            pauseService.Register(jumpChargeService);
        }

        private void BindLevelGeneration(IResetService resetService
        , IDistanceCountService distanceCountService)
        {
            Transform chunksRoot = new GameObject(_chunksRootName).transform;
            ChunkFactory factory = new ChunkFactory(Container.Resolve<ChunksCollection>(), chunksRoot);
            
            LevelGenerationService generationService = new LevelGenerationService(Container.Resolve<LevelGenerationConfig>()
                , factory
                , distanceCountService);

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

        private void BindDieCheckService()
        {
            Container
                .Bind<IActorDieCheckService>()
                .To<ActorDieCheckService>()
                .FromNew()
                .AsSingle();
        }

        private IJumpCombo BindJumpCombo(ITimersService timersService
            , IResetService resetService)
        {
            JumpCombo jumpCombo = new JumpCombo(timersService
                , Container.Resolve<JumpsConfig>());
            
            Container
                .Bind<IJumpCombo>()
                .To<JumpCombo>()
                .FromInstance(jumpCombo)
                .AsSingle();
            
            resetService.Register(jumpCombo);

            return jumpCombo;
        }
        
        private void BindScoreService(IResetService resetService
            , IDistanceCountService distanceCount
            , ITimersService timersService
            , IJumpCombo jumpCombo)
        {
            
            ScoreService scoreService = new ScoreService(jumpCombo
                , distanceCount
                , Container.Resolve<ScoreConfig>());

            Container
                .Bind<IScoreService>()
                .To<ScoreService>()
                .FromInstance(scoreService)
                .AsSingle();
            
            resetService.Register(scoreService); 

        }
    }
}