using System;
using UnityEngine;

public class HeartDetector : MonoBehaviour
{
    public event Action<Hearth> HeartDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.TryGetComponent<Hearth>(out Hearth heart) == true)
        {
            heart.gameObject.SetActive(false);
            HeartDetected?.Invoke(heart);
        }
    }
}