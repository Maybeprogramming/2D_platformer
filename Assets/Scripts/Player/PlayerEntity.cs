using System;
using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(Health))]
public class PlayerEntity : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Health _health;

    public event Action PlayerDead;

    public bool IsGrounded => _isGrounded;
    public bool IsAlive => _health.CurrentValue > 0;

    private void Awake()
    {
        _health = GetComponent<Health>();        
    }

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _health.HealhtValueChanged += IsAlreadyDead;
    }

    private void OnDisable()
    {
        _health.HealhtValueChanged -= IsAlreadyDead;
    }

    private void Update()
    {
        _isGrounded = _groundDetector.IsGrouded;
    }

    private void IsAlreadyDead(float currentHealthValue)
    {
        if (IsAlive == false)
        {
            PlayerDead?.Invoke();
        }
    }
}