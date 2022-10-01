using UnityEngine;
using UnityEngine.UI;

public class JumpBufferPresenter : MonoBehaviour
{
    [SerializeField] private JumpMechanic _jumpMechanic;
    [SerializeField] private Image _jumpBufferTungle;

    private void OnBufferChanged(bool state)
    {
        _jumpBufferTungle.enabled = state;
    }

    private void OnEnable()
    {
        _jumpMechanic.JumpBufferChaged += OnBufferChanged;
    }

    private void OnDisable()
    {
        _jumpMechanic.JumpBufferChaged -= OnBufferChanged;
    }
}