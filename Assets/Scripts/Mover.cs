using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    protected const string Horizontal = "Horizontal";

    [SerializeField] protected float _speed;

    protected virtual void Move() { }
}