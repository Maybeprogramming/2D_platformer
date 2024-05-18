using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    public bool IsAlive => _health.CurrentValue > 0;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealhtValueChanged += IsAlreadyDead;
    }

    private void OnDisable()
    {
        _health.HealhtValueChanged -= IsAlreadyDead;
    }

    private void IsAlreadyDead(float currentHealthValue)
    {
        if (IsAlive == false)
        {
            _health.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}