using UnityEngine;

public abstract class HealthBaseViewValue : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ValueChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnHealthChanged;
    }

    public abstract void OnHealthChanged(float currentHealthValue, float maxValue);
}