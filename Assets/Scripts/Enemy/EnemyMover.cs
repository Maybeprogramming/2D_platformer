using UnityEngine;

public class EnemyMover : Mover
{
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypoint = 1;
    private float _deltaPosition;
    private Vector2 _targetPosition;

    public float MoveDirectionX => _deltaPosition;

    private void Start()
    {
        SetNextWaypoint();
    }

    private void Update()
    {
        Move();
    }

    private void SetNextWaypoint()
    {
        _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        _targetPosition = new Vector2(_waypoints[_currentWaypoint].position.x, transform.position.y);
    }

    protected override void Move()
    {
        _deltaPosition = _waypoints[_currentWaypoint].position.x - transform.position.x;

        if (Mathf.Abs(_deltaPosition) >= 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
        else
        {
            SetNextWaypoint();
        }
    }
}