using System;
using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Player _targetForAttack;
    [SerializeField] private PlayerDetector _detector;
    [SerializeField] private float _minDistanseToAttack;
    [SerializeField] private float _damage;
    [SerializeField] private float _beforeAttackTime = 0.2f;
    [SerializeField] private float _afterAttackTime = 1f;

    private Coroutine _attackerCoroutine;
    private Coroutine _drowerLineCoroutine;
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
        _detector.PlayerDetected += StartAttack;
        _detector.PlayerLost += StopAttack;
    }

    private void OnDisable()
    {
        _detector.PlayerDetected -= StartAttack;
        _detector.PlayerLost -= StopAttack;
    }

    private void StopAttack()
    {
        StopCoroutine(_drowerLineCoroutine);
        StopCoroutine(_attackerCoroutine);
        _targetForAttack = null;
    }

    private void StartAttack(Player player)
    {
        if (player.IsAlive == true)
        {
            _targetForAttack = player;
            _attackerCoroutine = StartCoroutine(Attacker());
            _drowerLineCoroutine = StartCoroutine(DrowerLineToTarget());
        }
    }

    private IEnumerator Attacker()
    {
        while (true)
        {
            yield return _beforeWaitTime;

            if (_targetForAttack != null && _detector.Distance <= _minDistanseToAttack)
            {
                _targetForAttack.TryTakeDamage(_damage);
                TargetAttacked?.Invoke();
                yield return null;
            }

            yield return _afterWaitTime;
        }
    }

    private IEnumerator DrowerLineToTarget()
    {
        while (_targetForAttack != null)
        {
            Debug.DrawLine(transform.position, _targetForAttack.transform.position, Color.red);
            yield return null;
        }
    }
}