using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class JumpForceCharger : MonoBehaviour
{
    public event Action<float> ChargeBegin;
    public event Action<float> ChargePercentChanged;
    public event Action<float> JumpCharged;
    [SerializeField] private TouchInput _input;
    [SerializeField] private Image _radius;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    private Vector2 _startPoint;

    private float _chargePercent;

    public float ChargePercent
    {
        get => _chargePercent;
        set
        {
            _chargePercent = value;
            ChargePercentChanged?.Invoke(value);
            UnityEngine.Debug.Log(value);
        }
    }

    public void Reset()
    {
        ChargePercent = 0;
    }
    
    private void OnEnable()
    {
        _input.TouchBegin += OnTouchBegin;
        _input.TouchEnd += OnTouchEnd;
        _input.TouchMove += OnTouchMove;
    }

    private void OnTouchBegin(Vector2 touchPosition)
    {
        _startPoint = new Vector2(touchPosition.x / _camera.pixelWidth, touchPosition.y / _camera.pixelHeight);
        UnityEngine.Debug.Log(_startPoint);
        ChargePercent = 0;
        ChargeBegin?.Invoke(ChargePercent);
        _radius.enabled = true;
        _radius.transform.position = touchPosition;
    }

    private void OnTouchMove(Vector2 touchPosition)
    {
        Vector2 normalizedPosition = new Vector2(touchPosition.x / _camera.pixelWidth, touchPosition.y / _camera.pixelHeight);
        float distance = Vector2.Distance(_startPoint, normalizedPosition);
        if (distance < _minDistance) 
        {
            ChargePercent = 0;
        }
        else
        {
            ChargePercent = Mathf.Clamp01((distance - _minDistance) / _maxDistance);
        }

    }
    private void OnTouchEnd(Vector2 touchPosition)
    {
        JumpCharged?.Invoke(ChargePercent);
        _radius.enabled = false;
    }


}
