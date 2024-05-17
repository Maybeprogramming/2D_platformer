using UnityEngine;

[RequireComponent(typeof(FlipperAxisX))]
public class EnemyMover : Mover
{
    [SerializeField] private Transform[] _waypoints;

    private FlipperAxisX _flipperAxisX;
    private int _currentWaypoint = 1;
    private Vector3 _targetPosition;
    private Vector2 _moveDirectionX;

    private void Start()
    {
        _flipperAxisX = GetComponent<FlipperAxisX>();
        SetNextWaypoint();
    }

    private void Update()
    {
        Move();
    }

    private void SetNextWaypoint()
    {
        _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        _targetPosition = new Vector3(_waypoints[_currentWaypoint].position.x, transform.position.y, transform.position.z);
        _moveDirectionX = new Vector2(transform.position.x - _targetPosition.x, Vector2.zero.y).normalized;
        _flipperAxisX.Flip(_moveDirectionX);
    }

    protected override void Move()
    {
        if (transform.position.x != _targetPosition.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
        else
        {
            SetNextWaypoint();
        }
    }
}