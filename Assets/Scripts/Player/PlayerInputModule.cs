using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputModule : MonoBehaviour
{
    private PlayerInput _input;
    private Vector2 _moveDirection;

    public event Action AttackButtonDowned;
    public event Action JumpButtonDowned;
    public event Action<Vector2> DirectionMoving;

    public Vector2 MoveDirection => _moveDirection;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Attack.performed += OnAttacked;
        _input.Player.Jump.performed += OnJumped;
        _input.Player.Move.performed += OnMovingDirection;
    }


    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Attack.performed -= OnAttacked;
        _input.Player.Jump.performed -= OnJumped;
        _input.Player.Move.performed -= OnMovingDirection;
    }

    private void Update()
    {
        _moveDirection = _input.Player.Move.ReadValue<Vector2>();
    }

    private void OnJumped(InputAction.CallbackContext context)
    {
        JumpButtonDowned?.Invoke();
    }

    private void OnAttacked(InputAction.CallbackContext context)
    {
        AttackButtonDowned?.Invoke();
    }

    private void OnMovingDirection(InputAction.CallbackContext context)
    {
        DirectionMoving?.Invoke(context.ReadValue<Vector2>());
    }
}