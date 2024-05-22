using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private float _damage;
    [SerializeField] private float beforeAttackTime = 0.2f;
    [SerializeField] private float afterAttackTime = 1f;

    private Coroutine _attackerCoroutine;
    private WaitForSeconds beforeWaitTime;
    private WaitForSeconds afterWaitTime;

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
        _player = null;
    }

    private void StartAttack(Player player)
    {
        _player = player;
        _attackerCoroutine = StartCoroutine(Attacker());
    }

    private IEnumerator Attacker()
    {
        while (_player != null)

        {
            yield return beforeWaitTime;
            _player.TryTakeDamage(_damage);

            yield return afterWaitTime;
        }
    }
}