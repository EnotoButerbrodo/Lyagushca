using System;
using UnityEngine;

namespace Lyaguska.Services
{
    public interface IDistanceCounter
    {
        event Action<float> DistanceChanged;
        float Distance { get; }
        Vector2 Position { get; }
    }
}