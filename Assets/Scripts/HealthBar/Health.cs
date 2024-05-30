using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _currentValue;

    public event Action<float> ValueChanged;

    public float MaxValue => _maxValue;
    public float MinValue => _minValue;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public bool Add(float value)
    {
        float newValue = Mathf.Clamp(_currentValue + value, _minValue, _maxValue);

        if (_currentValue != newValue)
        {
            _currentValue = newValue;
            ValueChanged?.Invoke(_currentValue);
            return true;
        }

        return false;
    }

    public bool Remove(float value)
    {
        float newValue = Mathf.Clamp(_currentValue - value, _minValue, _maxValue);

        if (_currentValue != newValue)
        {
            _currentValue = newValue;
            ValueChanged?.Invoke(_currentValue);
            return true;
        }

        return false;
    }
}