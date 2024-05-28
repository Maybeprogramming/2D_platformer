using System;
using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Player _targetForAttack;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private float _minDistanseToAttack;
    [SerializeField] private float _distanseToTarget;
    [SerializeField] private float _damage;
    [SerializeField] private float _beforeAttackTime = 0.2f;
    [SerializeField] private float _afterAttackTime = 1f;

    private Coroutine _attackerCoroutine;
    private WaitForSeconds _beforeWaitTime;
    private WaitForSeconds _afterWaitTime;

    public event Action TargetAttacked;

    private void Start()
    {
        _beforeWaitTime = new WaitForSeconds(_beforeAttackTime);
        _afterWaitTime = new WaitForSeconds(_afterAttackTime);
    }

    private void OnEnable()
    {
        _playerDetector.PlayerDetected += StartAttack;
        _playerDetector.PlayerLost += StopAttack;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerDetected -= StartAttack;
        _playerDetector.PlayerLost -= StopAttack;
    }

    private void Update()
    {
        if (_targetForAttack != null)
        {
            _distanseToTarget = Mathf.Abs((_targetForAttack.transform.position - transform.position).magnitude);
        }
    }

    private void StopAttack()
    {
        StopCoroutine(DrowLineToTarget());
        StopCoroutine(_attackerCoroutine);
        _targetForAttack = null;
    }

    private void StartAttack(Player player)
    {
        _targetForAttack = player;
        _attackerCoroutine = StartCoroutine(Attacker());
        StartCoroutine(DrowLineToTarget());
    }

    private IEnumerator Attacker()
    {
        while (_targetForAttack != null)
        {
            yield return _beforeWaitTime;

            if (_distanseToTarget <= _minDistanseToAttack)
            {
                _targetForAttack.TryTakeDamage(_damage);
                TargetAttacked?.Invoke();
            }

            yield return _afterWaitTime;
        }
    }

    private IEnumerator DrowLineToTarget()
    {
        while (_targetForAttack != null)
        {
            Debug.DrawLine(transform.position, _targetForAttack.transform.position, Color.red);
            yield return null;
        }
    }
}