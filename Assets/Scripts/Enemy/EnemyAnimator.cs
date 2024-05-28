using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyAttacker))]
public class EnemyAnimator : MonoBehaviour
{
    private const string Hit = "Hit";
    private const string Attack = "Attack";

    [SerializeField] private EnemyAttacker _attacker;
    private Health _health;
    private Animator _animator;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _attacker = GetComponent<EnemyAttacker>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _health.HealhtValueChanged += OnAnimationHit;
        _attacker.TargetAttacked += OnAnimationAttack;
    }

    private void OnDisable()
    {
        _health.HealhtValueChanged -= OnAnimationHit;
        _attacker.TargetAttacked -= OnAnimationAttack;
    }

    private void OnAnimationHit(float currentHealth)
    {
        _animator.SetTrigger(Hit);
    }

    private void OnAnimationAttack()
    {
        _animator.SetTrigger(Attack);
    }
}