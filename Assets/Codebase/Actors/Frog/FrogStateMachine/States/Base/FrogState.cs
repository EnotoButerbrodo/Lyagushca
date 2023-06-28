using Lyaguska.Actors.StateMachine;

namespace Lyaguska.Actors.StateMachine
{
    public abstract class FrogState : ActorState
    {
        protected FrogStateMachine Context;
        public FrogState(FrogStateMachine context)
        {
            Context = context;
        }
    }

}