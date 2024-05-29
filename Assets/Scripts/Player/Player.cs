using System;
using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(Health))]
public class Player : MonoBehaviour
{
    private bool _isGrounded;
    private GroundDetector _groundDetector;
    private Health _health;
    private HeartDetector _heartDetector;

    public event Action Died;
    public event Action DamageReceived;

    public bool IsGrounded => _isGrounded;
    public bool IsAlive => _health.CurrentValue > 0;

    private void Awake()
    {
        _health = GetComponent<Health>();        
        _heartDetector = GetComponent<HeartDetector>();
    }

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _health.HealhtValueChanged += IsAlreadyDead;
        _heartDetector.HeartDetected += OnHealing;
    }

    private void OnDisable()
    {
        _health.HealhtValueChanged -= IsAlreadyDead;
        _heartDetector.HeartDetected -= OnHealing;
    }

    private void Update()
    {
        _isGrounded = _groundDetector.IsGrouded;
    }

    public bool TryTakeDamage(float damage)
    {
        if (IsAlive == false)
        {
            return false;
        }

        _health.Remove(damage);
        DamageReceived?.Invoke();

        return true;
    }

    public bool TryHealing(float healthPoint)
    {
        if (IsAlive == false)
        {
            return false;
        }

        _health.Add(healthPoint);
        return true;
    }

    private void IsAlreadyDead(float currentHealthValue)
    {
        if (IsAlive == false)
        {
            Died?.Invoke();
        }
    }

    private void OnHealing(Hearth hearth)
    {
        _health.Add(hearth.HealthPoint);
    }
}