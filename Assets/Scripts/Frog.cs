using UnityEngine;

public class Frog : GameActor
{
    [SerializeField] private JumpHandler _jumpHandler;
    public override void InitialJump()
    {
        _jumpHandler.InitialJump();
    }

    public override void PerformJump()
    {
        _jumpHandler.PerformJump();
    }
}
