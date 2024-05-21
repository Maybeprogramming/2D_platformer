using System;
using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _damage;
    [SerializeField] private PlayerDetector _playerDetector;

    private Coroutine _attackerCoroutine;

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
        float elapsetTime = 1;

        while (_player != null)
        {
            yield return new WaitForSeconds(0.2f);

            if (/*_player != null &&*/ _player.TryGetComponent<Health>(out Health playerHealth))
            {
                playerHealth.Remove(_damage);
            }

            yield return new WaitForSeconds(elapsetTime);
        }
    }
}