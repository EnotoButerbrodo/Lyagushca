namespace Lyaguska.Core.Command
{
    public class JumpCommand : Command
    {
        private float _chargePercent;
        public JumpCommand(float chargePercent)
        {
            _chargePercent = chargePercent;
        }
        public override void Execute(Actor actor)
        {
            actor.Jump(_chargePercent);
        }
    }
}