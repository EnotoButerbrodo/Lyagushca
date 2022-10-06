
using UnityEngine;

public class JumpCommand : Command
{
    private float _chargePercent;
    public JumpCommand(float chargePercent)
    {
        _chargePercent = chargePercent;
    }
    public override void Execute(GameActor actor)
    {
        actor.Jump(_chargePercent);
    }
}
