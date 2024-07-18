using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;

    public bool IsAlive => _health.CurrentValue > 0;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += OnIsDied;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnIsDied;
    }

    public bool TryTakeDamage(float damage)
    {
        if (IsAlive == false)
        {
            return false;
        }

        _health.Remove(damage);
        return true;
    }

    private void OnIsDied(float currentHealthValue, float maxHealthValue)
    {
        if (IsAlive == false)
        {
            _health.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}