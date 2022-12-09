using System;

public interface IDistanceCounter
{
    event Action<float> DistanceChanged;
    float Distance { get; set; }
}