using System;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
    public abstract event Action Jump;
    public abstract event Action GroundLand;
    public abstract event Action Dead;
    public abstract void ChargeJump();
    public abstract void StopChargeJump();
    public abstract void ResetGameActor();
}