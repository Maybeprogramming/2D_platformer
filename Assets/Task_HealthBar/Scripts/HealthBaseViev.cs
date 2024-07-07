using UnityEngine;

public abstract class HealthBaseViev : MonoBehaviour
{
    [SerializeField] protected HealthPoint _health;

    private void Awake()
    {
        _health.ValueChanged += OnHealthChanged;
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnHealthChanged;
    }

    public abstract void OnHealthChanged(float healthValue);
}