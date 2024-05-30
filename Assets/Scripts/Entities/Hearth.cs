using UnityEngine;

public class Hearth : IPickable
{
    [SerializeField] private float _healthPoint;

    public float HealthPoint => _healthPoint;
}