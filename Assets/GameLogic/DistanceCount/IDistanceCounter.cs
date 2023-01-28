using System;
using UnityEngine;

public interface IDistanceCounter
{
    event Action<float> DistanceChanged;
    float Distance { get;}
    Vector2 Position { get; }
}