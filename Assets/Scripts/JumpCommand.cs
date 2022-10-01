public class JumpCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.Jump();
    }
}

public class ChargeBeginCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.ChargeJump();
    }
}

