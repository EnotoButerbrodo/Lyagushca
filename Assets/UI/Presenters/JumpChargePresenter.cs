using Lyaguska.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class JumpChargePresenter : MonoBehaviour
{
    [SerializeField] private ReloadBar _reloadBar;

    private IJumpForceCharger _jumpChargeHandler;

    [Inject]
    public void Construct(IJumpForceCharger jumpChargeHandler)
    {
        _jumpChargeHandler = jumpChargeHandler;
    }

    private void OnPercentChanged(float percent)
    {
        if (percent > 0)
            _reloadBar.Show();

        _reloadBar.SetFillPercent(percent);
    }

    private void OnChargeBegin(float percent)
    {
        _reloadBar.SetFillPercent(percent);
    }

    private void OnChargeEnd(float percent)
    {
        if(percent == 0)
        {
            _reloadBar.Hide();
        }
        _reloadBar.SetFillPercent(percent);
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
}

