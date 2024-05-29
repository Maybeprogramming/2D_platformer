using System;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    [SerializeField] private float _distance = Single.MaxValue;

    private Player _player;

    public event Action<Player> Detected;
    public event Action Lost;

    public float Distance => _distance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _player))
        {
            Detected?.Invoke(_player);
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
            Lost?.Invoke();
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