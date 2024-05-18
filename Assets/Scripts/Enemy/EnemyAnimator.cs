using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string Hit = "Hit";

    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _health.HealhtValueChanged += OnAnimationHit;
    }

    private void OnDisable()
    {
        _health.HealhtValueChanged += OnAnimationHit;        
    }

    private void OnAnimationHit(float currentHealth)
    {
        _animator.SetTrigger(Hit);
    }
}
