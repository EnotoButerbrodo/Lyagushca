using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameLoopState : State
    {
        private ILevelGenerationService _generationService;

        public GameLoopState(StateMachine stateMachine, ILevelGenerationService generationService) : base(stateMachine)
        {
            _generationService = generationService;
        }

        public override void UpdateState()
        {
            _generationService.CheckChunksRelevance();
        }
    }
}