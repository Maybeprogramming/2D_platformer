using UnityEngine;

public abstract class HealthBaseViev : MonoBehaviour
{
    [SerializeField] private HealthPoint _health;

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