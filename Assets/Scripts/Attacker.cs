using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private PlayerInputModule _playerInput;
    [SerializeField] private Enemy _target;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Transform _defaultAttackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _offset;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputModule>();
    }

    private void OnEnable()
    {
        _playerInput.AttackButtonDowned += OnAttacked;
        _playerInput.DirectionMoving += OnSetPointToAttack;
    }

    private void OnDisable()
    {
        _playerInput.AttackButtonDowned -= OnAttacked;
        _playerInput.DirectionMoving -= OnSetPointToAttack;
    }

    private void OnAttacked()
    {
        Collider2D enemy = Physics2D.OverlapCircle(new Vector2(_attackPoint.position.x, _attackPoint.position.y), _attackRadius, _layerMask);

        if (enemy != null && enemy.TryGetComponent<Enemy>(out _target) == true)
        {
            if (_target != null && _target.TryGetComponent<Health>(out Health enemyHealth))
            {
                enemyHealth.Remove(_damage);
            }
        }
    }

    private void OnSetPointToAttack(Vector2 direction)
    {
        float horizontalPosition = direction.x * _offset;
        _attackPoint.transform.position = new Vector3(_defaultAttackPoint.position.x + horizontalPosition, _attackPoint.position.y, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(_attackPoint.position.x, _attackPoint.position.y), _attackRadius);
    }
}