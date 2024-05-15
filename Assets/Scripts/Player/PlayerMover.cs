using UnityEngine;

public class PlayerMover : Mover
{
    private float _direction;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        _direction = Input.GetAxis(nameof(Horizontal));

        Vector2 nextPosition = Vector2.right * _direction * _speed * Time.deltaTime;

        if (Mathf.Abs(_direction) > 0.1f)
        {
            transform.Translate(nextPosition);
        }
    }
}