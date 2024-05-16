using UnityEngine;

public class PlayerMover : Mover
{
    private float _direction;
    private float _moveDelta = 0.1f;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        _direction = Input.GetAxis(Horizontal);

        Vector2 nextPosition = Vector2.right * _direction * _speed * Time.deltaTime;

        if (Mathf.Abs(_direction) > _moveDelta)
        {
            transform.Translate(nextPosition);
        }
    }
}