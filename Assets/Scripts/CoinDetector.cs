using System;
using UnityEngine;

public class CoinDetector : MonoBehaviour
{
    public event Action CoinDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.TryGetComponent<Coin>(out Coin coin) == true)
        {
            coin.gameObject.SetActive(false);
            CoinDetected?.Invoke();
        }
    }
}