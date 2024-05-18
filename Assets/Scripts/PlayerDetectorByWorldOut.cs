using System;
using UnityEngine;

public class PlayerDetectorByWorldOut : MonoBehaviour
{
    public event Action<Player> PlayerOutWorldDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) == true)
        {
            PlayerOutWorldDetected?.Invoke(player);
        }
    }
}