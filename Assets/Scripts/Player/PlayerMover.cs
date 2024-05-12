using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _jumpForce;

    private float _direction;
    private PlayerEntity _player;
    private Rigidbody2D _rigidbody;

    public static int DirectionRaw => (int)Input.GetAxisRaw(nameof(Horizontal));

    private void Start()
    {
        _player = GetComponent<PlayerEntity>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
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

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _player.IsGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
}
