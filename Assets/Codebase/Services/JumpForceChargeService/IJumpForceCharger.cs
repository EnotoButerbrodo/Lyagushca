using System;

namespace Lyaguska.Services
{
    public interface IJumpForceCharger
    {
        event Action<float> ChargeBegin;
        event Action<float> ChargePercentChanged;
        event Action<float> JumpCharged;

        float ChargePercent { get; }
        void StartCharge();
        void StopCharge();
        void Reset();
    }
}