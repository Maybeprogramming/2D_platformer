using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private PlayerInputModule _playerInput;
    [SerializeField] private Enemy _target;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputModule>();
    }

    private void OnEnable()
    {
        _playerInput.AttackButtonDowned += OnAttacked;
    }

    private void OnDisable()
    {
        _playerInput.AttackButtonDowned -= OnAttacked;
    }

    private void OnAttacked()
    {
        Collider2D enemy = Physics2D.OverlapCircle(new Vector2(_attackPoint.position.x, _attackPoint.position.y), _attackRadius, _layerMask);


        if (enemy != null && enemy.TryGetComponent<Enemy>(out _target) == true)
        {
            Debug.Log(enemy.name);

            if (_target != null && _target.TryGetComponent<Health>(out Health enemyHealth))
            {
                enemyHealth.Remove(_damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(_attackPoint.position.x, _attackPoint.position.y), _attackRadius);
    }
}