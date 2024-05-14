using System;
using UnityEngine;

public class PlayerDetectorByWorldOut : MonoBehaviour
{
    public event Action<PlayerEntity> PlayerOutWorldDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerEntity player) == true)
        {
            PlayerOutWorldDetected?.Invoke(player);
        }
    }
}