using System;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public event Action<float> ValueChanged;

    public float MaxValue { get; private set; }
    public float MinValue { get; private set; }
    public float CurrentValue { get; private set; }

    public void Init(float currentValue, float minValue, float maxValue)
    {
        CurrentValue = currentValue;
        MinValue = minValue;
        MaxValue = maxValue;
    }

    public bool Add(float healthValue)
    {
        float newValue = Mathf.Clamp(CurrentValue + healthValue, MinValue, MaxValue);

        if (CurrentValue != newValue)
        {
            CurrentValue = newValue;
            ValueChanged?.Invoke(CurrentValue);

            return true;
        }

        return false;
    }

    public bool Remove(float healthValue)
    {
        float newValue = Mathf.Clamp(CurrentValue - healthValue, MinValue, MaxValue);

        if (CurrentValue != newValue)
        {
            CurrentValue = newValue;
            ValueChanged?.Invoke(CurrentValue);

            return true;
        }

        return false;
    }
}