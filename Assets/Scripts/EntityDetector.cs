using System;
using UnityEngine;

public class EntityDetector <T>: MonoBehaviour where T : IPickable
{
    public event Action<T> EntityDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<T>(out T entity) == true)
        {
            entity.gameObject.SetActive(false);
            EntityDetected?.Invoke(entity);
        }
    }
}