using System;

namespace Lyaguska.Services
{
    public interface IJumpChargeService : IResetable
    {
        event Action<float> ChargeBegin;
        event Action<float> ChargePercentChanged;
        event Action<float> ChargeEnd;
        event Action<float> DechargeBegin;
        event Action<float> DechargeEnd;
        event Action Showed;
        event Action Hided;

        float ChargePercent { get; }
        void StartCharge();
        void StopCharge();

        void Show();
        void Hide();

    }
}