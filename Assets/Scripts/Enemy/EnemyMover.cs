using UnityEngine;

public class EnemyMover : Mover
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private SpriteRenderer _spriteRenderer; //Костыль!! Нужно переворачивание по X привести в норм вид!

    private int _currentWaypoint = 0;
    private float _deltaPosition;
    private Vector2 _nextPosition;

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
        _nextPosition = new Vector2(_waypoints[_currentWaypoint].position.x, transform.position.y);
    }

    protected override void Move()
    {
        _deltaPosition = Mathf.Abs(_waypoints[_currentWaypoint].position.x - transform.position.x);

        if (_deltaPosition <= 0.1f)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
            FlipX();
        }
        else
        {
            SetNextWaypoint();
        }

        transform.position = Vector2.MoveTowards(transform.position, _nextPosition, _speed * Time.deltaTime);
    }

    private void FlipX()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}