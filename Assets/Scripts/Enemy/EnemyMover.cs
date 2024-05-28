using UnityEngine;

[RequireComponent(typeof(SpriteFlipperAxisX))]
public class EnemyMover : Mover
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Player _target;
    [SerializeField] private FlipDetector _flipDetector;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private float _runSpeed;
    [SerializeField] private Vector2 _offset;

    private SpriteFlipperAxisX _flipperAxisX;
    private float minMagnitude = 0.1f;
    private int _currentWaypoint = 1;
    private Vector3 _targetPosition;

    private void Start()
    {
        _flipperAxisX = GetComponent<SpriteFlipperAxisX>();
        SetNextWaypoint();
    }

    private void OnEnable()
    {
        _playerDetector.PlayerDetected += OnSelectTarget;
        _playerDetector.PlayerLost += OnDeselectTarget;
    }


    private void OnDisable()
    {
        _playerDetector.PlayerDetected -= OnSelectTarget;
        _playerDetector.PlayerLost += OnDeselectTarget;
    }

    private void Update()
    {
        if (_target == null)
        {
            Move();
        }
        else
        {
            MoveToTarget();
        }
    }

    private void SetNextWaypoint()
    {
        _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        _targetPosition = new Vector3(_waypoints[_currentWaypoint].position.x, transform.position.y, transform.position.z);

        _flipperAxisX.Flip(GetDirection());
        _flipDetector.Flip(GetDirection());
    }

    private Vector2 GetDirection()
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

    private void MoveToTarget()
    {
        if (_target != null)
        {
            Vector2 targetPosition = new Vector2(_target.transform.position.x, transform.position.y) + _offset * GetDirection();
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _runSpeed * Time.deltaTime);
        }
    }

    private void OnSelectTarget(Player player)
    {
        _target = player;
    }

    private void OnDeselectTarget()
    {
        _target = null;
    }
}