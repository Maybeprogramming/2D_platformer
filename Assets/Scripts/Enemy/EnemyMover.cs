using System;
using UnityEngine;

[RequireComponent(typeof(SpriteFlipperAxisX))]
public class EnemyMover : Mover
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private TargetDetector _playerDetector;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _offsetRange;
    [SerializeField] private float minDistanceToTarget = 0.05f;

    private Player _playerEntity;
    private SpriteFlipperAxisX _flipperAxisX;
    private float minMagnitude = 0.1f;
    private int _currentWaypoint = 1;
    private Vector3 _targetPosition;

    public event Action Runing;
    public event Action Walking;

    private void Start()
    {
        _flipperAxisX = GetComponent<SpriteFlipperAxisX>();
        SetNextWaypoint();
    }

    private void OnEnable()
    {
        _playerDetector.Detected += OnDetectTarget;
        _playerDetector.Lost += OnLostTarget;
    }

    private void OnDisable()
    {
        _playerDetector.Detected -= OnDetectTarget;
        _playerDetector.Lost += OnLostTarget;
    }

    private void Update()
    {
        if (IsTargetEmpty())
        {
            WalkState();
        }
        else
        {
            RunToTargetState();
        }
    }

    private bool IsTargetEmpty()
    {
        if (_playerEntity == null || _playerEntity.IsAlive == false)
        {
            return true;
        }

        return false;
    }

    private void SetNextWaypoint()
    {
        _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        _targetPosition = new Vector3(_waypoints[_currentWaypoint].position.x, transform.position.y, transform.position.z);
    }

    private float GetDirection(Vector3 targetPosition)
    {
        return new Vector2(transform.position.x - targetPosition.x, Vector2.zero.y).normalized.x;
    }

    protected override void WalkState()
    {
        if ((transform.position - _targetPosition).sqrMagnitude >= minMagnitude)
        {
            Walking?.Invoke();
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _baseSpeed * Time.deltaTime);
            _flipperAxisX.Flip(GetDirection(_targetPosition));
        }
        else
        {
            SetNextWaypoint();
        }
    }

    private void RunToTargetState()
    {
        if (_playerEntity != null && _playerEntity.IsAlive == true)
        {

            Vector3 targetPosition = _playerEntity.transform.position;
            Vector2 newPosition = new Vector2(targetPosition.x + _offsetRange * GetDirection(targetPosition), transform.position.y);

            if ((Mathf.Abs(newPosition.x - transform.position.x)) > minDistanceToTarget)
            {
                Runing?.Invoke();
                transform.position = Vector2.MoveTowards(transform.position, newPosition, _runSpeed * Time.deltaTime);
            }

            _flipperAxisX.Flip(GetDirection(targetPosition));
        }
    }

    private void OnDetectTarget(Player player)
    {
        _playerEntity = player;
    }

    private void OnLostTarget()
    {
        _playerEntity = null;
        SetNextWaypoint();
    }
}