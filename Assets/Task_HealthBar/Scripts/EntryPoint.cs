using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private HealthPoint _healthEntity;
    [SerializeField] private float _currentHealthEntity;
    [SerializeField] private float _maxHealthEntity;

    private void Start()
    {
        _healthEntity.Init(_currentHealthEntity, _maxHealthEntity);
    }
}