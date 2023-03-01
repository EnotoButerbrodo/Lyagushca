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
            _jumpChargeHandler.DechargeBegin += OnDechargeBegin;
            _jumpChargeHandler.DechargeEnd += OnDechargeEnd;
        }
        
        private void OnDisable()
        {
            _jumpChargeHandler.ChargeBegin -= OnChargeBegin;
            _jumpChargeHandler.ChargePercentChanged -= OnPercentChanged;
            _jumpChargeHandler.ChargeEnd -= OnChargeEnd;
            _jumpChargeHandler.Showed -= Show;
            _jumpChargeHandler.Hided -= Hide;
            _jumpChargeHandler.DechargeBegin -= OnDechargeBegin;
            _jumpChargeHandler.DechargeEnd -= OnDechargeEnd;
            
        }

        private void OnPercentChanged(float percent)
        {
            _chargeBar.SetFillPercent(percent);
        }

        private void OnChargeBegin(float percent)
        {
            _chargeBar.SetFillPercent(percent);
            _chargeBar.HideFullChargeIndicator();
            
        }

        private void OnChargeEnd(float percent)
        {
            _chargeBar.ShowFullChargeIndicator();
        }
        
        private void OnDechargeEnd(float distance)
        {
            _chargeBar.Hide();
        }

        private void OnDechargeBegin(float distance)
        {
            _chargeBar.HideFullChargeIndicator();
        }
        
        private void Hide()
        {
            _chargeBar.Hide();
        }

        private void Show()
        {
            _chargeBar.Show();
        }


    }


}