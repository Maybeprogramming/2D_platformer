using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerEntity))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Idle = "Idle";
    private const string Run = "Run";
    private const string Jump = "Jump";
    private const string Attack = "Attack";
    private const string IsGround = "IsGround";
    private const string MoveDirection = "MoveDirection";

    [SerializeField] private float _directionZero = 0;
    [SerializeField] private PlayerInputModule _playerInput;

    private PlayerEntity _player;
    private Animator _animator;
    private int moveDirection;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputModule>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerEntity>();
    }

    private void OnEnable()
    {
        _playerInput.AttackButtonDowned += OnAmimationAttacked;
        _playerInput.JumpButtonDowned += OnAnimationJumped;
    }

    private void OnDisable()
    {
        _playerInput.AttackButtonDowned -= OnAmimationAttacked;
        _playerInput.JumpButtonDowned -= OnAnimationJumped;
    }

    private void Update()
    {
        moveDirection = Mathf.Abs((int)_playerInput.MoveDirection.x);
        _animator.SetBool(IsGround, _player.IsGrounded);
        _animator.SetInteger(MoveDirection, moveDirection);
    }

    private void OnAnimationJumped()
    {
        _animator.SetTrigger(Jump);
    }

    private void OnAmimationAttacked()
    {
        _animator.SetTrigger(Attack);
    }
}