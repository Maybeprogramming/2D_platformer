using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Transform _defaultAttackPoint;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _offset;
    [SerializeField] private LayerMask _layerMask;

    private PlayerInputModule _playerInput;

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
        Collider2D target = Physics2D.OverlapCircle(new Vector2(_attackPoint.position.x, _attackPoint.position.y), _attackRadius, _layerMask);

        if (target != null && target.TryGetComponent<Enemy>(out Enemy enemy) == true)
        {
            enemy.TryTakeDamage(_damage);
        }
    }

    private void OnSetPointToAttack(Vector2 direction)
    {
        float horizontalDirection = direction.x * _offset;
        _attackPoint.transform.position = new Vector3(_defaultAttackPoint.position.x + horizontalDirection, _attackPoint.position.y, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(_attackPoint.position.x, _attackPoint.position.y), _attackRadius);
    }
}