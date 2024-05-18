using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _currentValue;

    public event Action<float> HealhtValueChanged;

    public float MaxValue => _maxValue;
    public float MinValue => _minValue;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public bool Add(float value)
    {
        if (value <= 0 || _currentValue == _maxValue)
        {
            return false;
        }

        if (_currentValue + value >= _maxValue)
        {
            _currentValue = _maxValue;
            HealhtValueChanged?.Invoke(_currentValue);
            return true;
        }

        _currentValue += value;
        HealhtValueChanged?.Invoke(_currentValue);
        return true;
    }

    public bool Remove(float value)
    {
        if (value <= 0 || _currentValue == _minValue)
        {
            return false;
        }

        if (_currentValue - value <= _minValue)
        {
            _currentValue = _minValue;
            HealhtValueChanged?.Invoke(_currentValue);
            return true;
        }

        _currentValue -= value;
        HealhtValueChanged?.Invoke(_currentValue);
        return true;
    }
}