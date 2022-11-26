namespace Lyaguska.Core.Command
{
    public abstract class Command
    {
        public abstract void Execute(GameActor actor);
    }
}