using System;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
    public abstract void InitialJump();
    public abstract void PerformJump();
}