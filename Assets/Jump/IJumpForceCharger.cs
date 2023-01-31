using System;

namespace Lyaguska.Core
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