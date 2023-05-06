using EnotoButerbrodo.LevelGeneration;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class LoadState : State
    {
        private readonly IUIFactory _uiFactory;
        private readonly IActorFactory _actorFactory;
        private readonly ILevelGenerationService _levelGenerationService;

        public LoadState(StateMachine stateMachine
            , IUIFactory uiFactory
            , IActorFactory actorFactory
            , ILevelGenerationService levelGenerationService) : base(stateMachine)
        {
            _uiFactory = uiFactory;
            _actorFactory = actorFactory;
            _levelGenerationService = levelGenerationService;
        }

        public override void Enter()
        {
            _actorFactory.Load();
            _uiFactory.Load();
            _levelGenerationService.LoadResources();
            
            _stateMachine.Enter<TittleScreenState>();
        }
    }
}