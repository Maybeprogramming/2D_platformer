using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float, float> ValueChanged;

    public float MaxValue { get; private set; }
    public float MinValue { get; private set; } = 0f;
    public float CurrentValue { get; private set; }

    public void Init(float currentValue, float maxValue)
    {
        CurrentValue = currentValue;
        MaxValue = maxValue;
        ValueChanged?.Invoke(CurrentValue, MaxValue);
    }

    public void Add(float healthValue)
    {
        if (healthValue > 0f)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + healthValue, MinValue, MaxValue);
            ValueChanged?.Invoke(CurrentValue, MaxValue);
        }
    }

    public void Remove(float healthValue)
    {
        if (healthValue > 0f)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - healthValue, MinValue, MaxValue);
            ValueChanged?.Invoke(CurrentValue, MaxValue);
        }
    }
}