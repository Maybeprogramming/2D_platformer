using UnityEngine;

public class Hearth : MonoBehaviour
{
    [SerializeField] private float _healthPoint;

    public float HealthPoint => _healthPoint;
}