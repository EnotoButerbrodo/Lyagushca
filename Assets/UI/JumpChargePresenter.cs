using UnityEngine;
using UnityEngine.UI;

public class JumpChargePresenter : MonoBehaviour
{
    [SerializeField] private ReloadBar _reloadBar;
    [SerializeField] private JumpChargeHandler _jumpChargeHandler;

    private void OnChargeTick(float percent)
    {
        _reloadBar.SetFillPercent(percent);
    }

    private void OnChargeBegin()
    {
        _reloadBar.Show();
        _reloadBar.Reset();
    }

    private void OnChargeEnd()
    {
        //_reloadBar.Hide();
    }

    private void OnEnable()
    {
        _jumpChargeHandler.ChargePercentChanged += OnChargeTick;
        _jumpChargeHandler.Started += OnChargeBegin;
        _jumpChargeHandler.Charged += OnChargeEnd;
    }

    private void OnDisable()
    {
        _jumpChargeHandler.ChargePercentChanged -= OnChargeTick;
        _jumpChargeHandler.Started -= OnChargeBegin;
        _jumpChargeHandler.Charged -= OnChargeEnd;
    }
}

