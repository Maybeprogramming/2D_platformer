using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _distance = Single.MaxValue;
    [SerializeField] private Player _player;

    public event Action<Player> PlayerDetected;
    public event Action PlayerLost;

    public float Distance => _distance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _player))
        {
            PlayerDetected?.Invoke(_player);
            Debug.Log("Detect");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CalculateDistance();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _player))
        {
            _player = null;
            PlayerLost?.Invoke();
            Debug.Log("Lost");
        }
    }
    private void CalculateDistance()
    {
        if (_player != null)
        {
            _distance = Mathf.Abs((_player.transform.position - transform.position).magnitude);
        }
    }
}