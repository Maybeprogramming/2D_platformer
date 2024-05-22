using UnityEngine;

[RequireComponent(typeof(FlipperAxisX))]
public class EnemyMover : Mover
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Player _target;

    private FlipperAxisX _flipperAxisX;
    private float minMagnitude = 0.1f;
    private int _currentWaypoint = 1;
    private Vector3 _targetPosition;

    private void Start()
    {
        _flipperAxisX = GetComponent<FlipperAxisX>();
        SetNextWaypoint();
    }

    private void Update()
    {
        if (_target == null)
        {
            Move();
        }
        else
        {
            MoveToTarget(_target);
        }
    }

    private void SetNextWaypoint()
    {
        _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        _targetPosition = new Vector3(_waypoints[_currentWaypoint].position.x, transform.position.y, transform.position.z);

        _flipperAxisX.Flip(GetMoveDirection());
    }

    private Vector2 GetMoveDirection()
    {
        return new Vector2(transform.position.x - _targetPosition.x, Vector2.zero.y).normalized;
    }

    protected override void Move()
    {
        if ((transform.position - _targetPosition).sqrMagnitude >= minMagnitude)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
        else
        {
            SetNextWaypoint();
        }
    }

    private void MoveToTarget(Player player)
    {

    }
}