namespace Lyaguska.Actors.StateMachine
{
    public abstract class ActorState
    {
        public virtual void Enter() { return; }
        public virtual void Exit() { return; }
        public virtual void HandleButtonPress() { return; }
        public virtual void HandleButtonRelease() { return; }
        public virtual void UpdateState() {return;}
    }
}