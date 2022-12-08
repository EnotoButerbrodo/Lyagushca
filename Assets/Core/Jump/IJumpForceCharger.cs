using System;

namespace Lyaguska.Core
{
    public interface IJumpForceCharger
    {
        float ChargePercent { get; set; }
        void StartCharge();
        void StopCharge();

        event Action<float> ChargeBegin;
        event Action<float> ChargePercentChanged;
        event Action<float> JumpCharged;
        void Reset();
    }
}