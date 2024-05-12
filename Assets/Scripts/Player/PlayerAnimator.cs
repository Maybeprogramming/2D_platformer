using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _playerMove;
    [SerializeField] private PlayerEntity _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerEntity>();
    }

    private void Update()
    {
        _playerMove = Input.GetAxis("Horizontal");

        if(Mathf.Abs(_playerMove) > 0.1f && _player.IsGrounded == true)
        {
            _animator.SetTrigger("Run");
        }
        else if (_player.IsGrounded == true)
        {
            _animator.SetTrigger("Idle");
        }

        if (_player.IsGrounded == false)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _animator.SetTrigger("Dead");
        }
    }

    private void Jump()
    {
        _animator.SetTrigger("Jump");
    }
}