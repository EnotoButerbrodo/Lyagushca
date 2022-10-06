using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchInput : MonoBehaviour
{
    public delegate void TouchInputDelegate(Vector2 touchPosition);

    public event TouchInputDelegate TouchBegin;
    public event TouchInputDelegate TouchEnd;
    public event TouchInputDelegate TouchMove;

    private Camera _camera;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();

        _camera = Camera.main;
    }

    private void OnEnable()
    {
        Touch.onFingerDown += OnFingerDown;
        Touch.onFingerUp += OnFingerUp;
        Touch.onFingerMove += OnFigerMove;
    }

    private void OnDisable()
    {
        Touch.onFingerDown -= OnFingerDown;
        Touch.onFingerUp -= OnFingerUp;
        Touch.onFingerMove -= OnFigerMove;
    }

    private void OnFigerMove(Finger finger)
    {
        if (finger.index > 0)
            return;
        TouchMove?.Invoke(finger.screenPosition);
    }

    private void OnFingerDown(Finger finger) 
    {
        if (finger.index > 0)
            return;
        TouchBegin?.Invoke(finger.screenPosition);
    }
    private void OnFingerUp(Finger finger)
    {
        if (finger.index > 0)
            return;

        TouchEnd?.Invoke(finger.screenPosition);
    }
}
