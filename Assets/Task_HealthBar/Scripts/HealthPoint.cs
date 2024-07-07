using System;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _maxValue;

    private float _newValue;

    public event Action<float> ValueChanged;

    public float MaxValue => _maxValue;
    public float MinValue => _minValue;
    public float CurrentValue => _currentValue;

    public bool Add(float healthValue)
    {
        _newValue = Mathf.Clamp(_currentValue + healthValue, _minValue, _maxValue);

        if (_currentValue != _newValue)
        {
            _currentValue = _newValue;
            ValueChanged?.Invoke(_currentValue);

            return true;
        }

        return false;
    }

    public bool Remove(float healthValue)
    {
        _newValue = Mathf.Clamp(_currentValue - healthValue, _minValue, _maxValue);

        if (_currentValue != _newValue)
        {
            _currentValue = _newValue;
            ValueChanged?.Invoke(_currentValue);

            return true;
        }

        return false;
    }
}