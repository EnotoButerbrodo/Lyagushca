using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.HUD
{
    public class JumpChargePresenter : MonoBehaviour
    {
        [SerializeField] private ChargeBar _chargeBar;

        private IJumpChargeService _jumpChargeHandler;

        [Inject]
        public void Construct(IJumpChargeService jumpChargeHandler)
        {
            _jumpChargeHandler = jumpChargeHandler;
        }

        private void OnEnable()
        {
            _jumpChargeHandler.ChargeBegin += OnChargeBegin;
            _jumpChargeHandler.ChargePercentChanged += OnPercentChanged;
            _jumpChargeHandler.ChargeEnd += OnChargeEnd;
            _jumpChargeHandler.Showed += Show;
            _jumpChargeHandler.Hided += Hide;
        }

        private void Hide()
        {
            _chargeBar.Hide();
        }

        private void Show()
        {
            _chargeBar.Show();
        }

        private void OnDisable()
        {
            _jumpChargeHandler.ChargeBegin -= OnChargeBegin;
            _jumpChargeHandler.ChargePercentChanged -= OnPercentChanged;
            _jumpChargeHandler.ChargeEnd -= OnChargeEnd;
        }

        private void OnPercentChanged(float percent)
        {
            _chargeBar.SetFillPercent(percent);
        }

        private void OnChargeBegin(float percent)
        {
            _chargeBar.SetFillPercent(percent);
            
        }

        private void OnChargeEnd(float percent)
        {
            if(percent == 0)
                _chargeBar.Hide();
            
            _chargeBar.SetFillPercent(percent);
        }


    }


}