using System;
using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Player _targetForAttack;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private float _damage;
    [SerializeField] private float beforeAttackTime = 0.2f;
    [SerializeField] private float afterAttackTime = 1f;

    private Coroutine _attackerCoroutine;
    private WaitForSeconds beforeWaitTime;
    private WaitForSeconds afterWaitTime;

    public event Action TargetAttacked;

    private void Start()
    {
        beforeWaitTime = new WaitForSeconds(beforeAttackTime);
        afterWaitTime = new WaitForSeconds(afterAttackTime);
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

    private void StopAttack()
    {
        StopCoroutine(_attackerCoroutine);
        _targetForAttack = null;
    }

    private void StartAttack(Player player)
    {
        _targetForAttack = player;
        _attackerCoroutine = StartCoroutine(Attacker());
    }

    private IEnumerator Attacker()
    {
        while (_targetForAttack != null)
        {
            yield return beforeWaitTime;

            _targetForAttack.TryTakeDamage(_damage);
            TargetAttacked?.Invoke();

            yield return afterWaitTime;
        }
    }
}