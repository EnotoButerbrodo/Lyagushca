using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.UI
{
    public class JumpChargePresenter : MonoBehaviour
    {
        [SerializeField] private ChargeBar chargeBar;

        private IJumpForceCharger _jumpChargeHandler;

        [Inject]
        public void Construct(IJumpForceCharger jumpChargeHandler)
        {
            _jumpChargeHandler = jumpChargeHandler;
        }

        private void OnEnable()
        {
            _jumpChargeHandler.ChargeBegin += OnChargeBegin;
            _jumpChargeHandler.ChargePercentChanged += OnPercentChanged;
            _jumpChargeHandler.JumpCharged += OnChargeEnd;
        }

        private void OnDisable()
        {
            _jumpChargeHandler.ChargeBegin -= OnChargeBegin;
            _jumpChargeHandler.ChargePercentChanged -= OnPercentChanged;
            _jumpChargeHandler.JumpCharged -= OnChargeEnd;
        }

        private void OnPercentChanged(float percent)
        {
            chargeBar.SetFillPercent(percent);
        }

        private void OnChargeBegin(float percent)
        {
            chargeBar.SetFillPercent(percent);
            chargeBar.Show();
        }

        private void OnChargeEnd(float percent)
        {
            if (percent == 0)
            {
                chargeBar.Hide();
            }

            chargeBar.SetFillPercent(percent);
        }


    }


}