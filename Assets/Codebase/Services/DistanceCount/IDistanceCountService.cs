﻿using System;
using UnityEngine;

namespace Lyaguska.Services
{
    public interface IDistanceCountService : IResetable
    {
        event Action<float> DistanceChanged;
        float Distance { get; }
        Vector2 Position { get; }
        void SetTarget(Transform targetTransform);
        void Update();
    }
}