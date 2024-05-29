using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float _baseSpeed;

    protected virtual void WalkState() { }
}