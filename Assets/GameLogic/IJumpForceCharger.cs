using System;

public interface IJumpForceCharger
{
    float ChargePercent { get; set; }

    event Action<float> ChargeBegin;
    event Action<float> ChargePercentChanged;
    event Action<float> JumpCharged;
}