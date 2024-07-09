using System;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public event Action<float, float, float> ValueChanged;

    public float MaxValue { get; private set; }
    public float MinValue { get; private set; }
    public float CurrentValue { get; private set; }

    public void Init(float currentValue, float minValue, float maxValue)
    {
        CurrentValue = currentValue;
        MinValue = minValue;
        MaxValue = maxValue;
        ValueChanged?.Invoke(CurrentValue, MinValue, MaxValue);
    }

    public bool Add(float healthValue)
    {
        if (healthValue > 0f)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + healthValue, MinValue, MaxValue);
            ValueChanged?.Invoke(CurrentValue, MinValue, MaxValue);

            return true;
        }

        return false;
    }

    public bool Remove(float healthValue)
    {
        if (healthValue > 0f)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - healthValue, MinValue, MaxValue);
            ValueChanged?.Invoke(CurrentValue, MinValue, MaxValue);

            return true;
        }

        return false;
    }
}