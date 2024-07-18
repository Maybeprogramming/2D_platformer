using UnityEngine;

public class HealthInit : MonoBehaviour
{
    [SerializeField] private Health _healthEntity;
    [SerializeField] private float _currentHealthEntity;
    [SerializeField] private float _maxHealthEntity;

    private void Awake()
    {
        _healthEntity.Init(_currentHealthEntity, _maxHealthEntity);
    }
}