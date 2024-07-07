using UnityEngine;
using UnityEngine.UI;

public class EntityAttacker : MonoBehaviour
{
    [SerializeField] private HealthPoint _health;
    [SerializeField] private float _damage;
    [SerializeField] private Button _attackButton;

    private void OnEnable()
    {
        _attackButton.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _attackButton.onClick.RemoveListener(TakeDamage);
    }

    public void TakeDamage()
    {
        _health.Remove(_damage);
    }
}