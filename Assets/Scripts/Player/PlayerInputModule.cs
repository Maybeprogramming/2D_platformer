using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputModule : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Vector2 _moveDirection;

    public event Action AttackButtonDowned;
    public event Action JumpButtonDowned;

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
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Attack.performed -= OnAttacked;
        _input.Player.Jump.performed -= OnJumped;
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
}