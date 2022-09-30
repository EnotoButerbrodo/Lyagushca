using System;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
    public abstract event Action Jump;
    public abstract event Action Land;
    public abstract event Action Die;
    public abstract void ChargeJump();
    public abstract void StopChargeJump();
}