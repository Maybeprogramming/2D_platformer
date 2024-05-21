using System;
using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Health _health;
    [SerializeField] private HeartDetector _heartDetector;

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
        _heartDetector = GetComponent<HeartDetector>();
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

    private void IsAlreadyDead(float currentHealthValue)
    {
        if (IsAlive == false)
        {
            PlayerDead?.Invoke();
        }
    }

    private void OnHealing(Hearth hearth)
    {
        _health.Add(hearth.HealthPoint);
    }
}