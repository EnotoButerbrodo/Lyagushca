using EnotoButerbrodo.StateMachine;

namespace Lyaguska.Bootstrap
{
    public class GameStateMachine : StateMachine
    {
        private readonly IStateFactory _stateFactory;
        
        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            _states = _stateFactory.GetStates(this);
        }
    }
    
}