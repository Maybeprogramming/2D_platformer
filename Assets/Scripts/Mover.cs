using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected virtual void Move() { }
}