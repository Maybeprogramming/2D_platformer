using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private Player _player;

    public event Action<Player> PlayerDetected;
    public event Action PlayerLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _player))
        {
            PlayerDetected?.Invoke(_player);
            Debug.Log("Player detected!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _player))
        {
            _player = null;
            PlayerLost?.Invoke();
            Debug.Log("Player lost!");
        }
    }
}