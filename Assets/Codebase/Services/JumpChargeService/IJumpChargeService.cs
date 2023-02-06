using System;

namespace Lyaguska.Services
{
    public interface IJumpChargeService : IResetable
    {
        event Action<float> ChargeBegin;
        event Action<float> ChargePercentChanged;
        event Action<float> JumpCharged;

        float ChargePercent { get; }
        void StartCharge();
        void StopCharge();
    }
}