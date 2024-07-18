using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyAttacker), typeof(EnemyMover))]
public class EnemyAnimator : MonoBehaviour
{
    private const string Hit = "Hit";
    private const string Attack = "Attack";
    private const string Run = "Run";
    private const string Walk = "Walk";

    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private EnemyMover _mover;

    private Health _health;
    private Animator _animator;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _attacker = GetComponent<EnemyAttacker>();
        _mover = GetComponent<EnemyMover>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += OnAnimationHit;
        _attacker.TargetAttacked += OnAnimationAttack;
        _mover.Runing += OnAnimationRuning;
        _mover.Walking += OnAnimationWalking;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnAnimationHit;
        _attacker.TargetAttacked -= OnAnimationAttack;
        _mover.Runing -= OnAnimationRuning;
        _mover.Walking -= OnAnimationWalking;
    }

    private void OnAnimationHit(float currentHealth, float maxHealthValue)
    {
        _animator.SetTrigger(Hit);
    }

    private void OnAnimationAttack()
    {
        _animator.SetTrigger(Attack);
    }

    private void OnAnimationRuning()
    {
        _animator.SetTrigger(Run);
    }

    private void OnAnimationWalking()
    {
        _animator.SetTrigger(Walk);
    }
}