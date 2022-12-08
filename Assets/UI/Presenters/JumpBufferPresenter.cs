﻿using Lyaguska.Core;
using UnityEngine;
using UnityEngine.UI;

public class JumpBufferPresenter : MonoBehaviour
{
    [SerializeField] private Image _jumpBufferTungle;

    private void OnBufferChanged(bool state)
    {
        _jumpBufferTungle.enabled = state;
    }

    private void OnEnable()
    {
        //_jumpMechanic.SavedJumpChanged += OnBufferChanged;
    }

    private void OnDisable()
    {
        //_jumpMechanic.SavedJumpChanged -= OnBufferChanged;
    }
}