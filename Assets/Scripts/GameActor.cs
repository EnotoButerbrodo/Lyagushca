using System;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
    public abstract event Action JumpChargeBegin;
    public abstract event Action Jumped;
    public abstract event Action GroundLand;
    public abstract event Action Dead;

    public abstract bool Grounded { get; }

    protected GameActorState _state = GameActorState.Idle;

    public abstract void ChargeJump();
    public abstract void Jump();
    public abstract void ResetGameActor();
}

[Serializable]
public enum GameActorState
{
    JumpCharging,
    Jumping,
    Idle
}