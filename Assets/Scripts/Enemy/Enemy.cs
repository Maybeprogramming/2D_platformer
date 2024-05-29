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

    public bool TryTakeDamage(float damage)
    {
        if (IsAlive == false)
        {
            return false;
        }

        _health.Remove(damage);
        return true;
    }

    private void OnEnable()
    {
        _health.HealhtValueChanged += IsDied;
    }

    private void OnDisable()
    {
        _health.HealhtValueChanged -= IsDied;
    }

    private void IsDied(float currentHealthValue)
    {
        if (IsAlive == false)
        {
            _health.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}