using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;

    public float BaseSpeed => _baseSpeed;

    protected virtual void WalkState() { }
}