using UnityEngine;
using UnityEngine.UI;

public class JumpChargPresenter : MonoBehaviour
{
    [SerializeField] private ReloadBar _reloadBar;
    [SerializeField] private JumpHandler _jumpHandler;

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
        _reloadBar.Hide();
    }

    private void OnEnable()
    {
        _jumpHandler.JumpPercentChanged += OnChargeTick;
        _jumpHandler.JumpChargeBegin += OnChargeBegin;
        _jumpHandler.JumpChargeEnd += OnChargeEnd;
    }

    private void OnDisable()
    {
        _jumpHandler.JumpPercentChanged -= OnChargeTick;
        _jumpHandler.JumpChargeBegin -= OnChargeBegin;
        _jumpHandler.JumpChargeEnd -= OnChargeEnd;
    }
}

