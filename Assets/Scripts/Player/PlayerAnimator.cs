using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerEntity), typeof(PlayerInputModule))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Jump = "Jump";
    private const string Attack = "Attack";
    private const string IsGround = "IsGround";
    private const string MoveDirection = "MoveDirection";

    private PlayerInputModule _playerInput;
    private PlayerEntity _player;
    private Animator _animator;
    private int _moveDirectionRawX;

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
        _moveDirectionRawX = Mathf.Abs((int)_playerInput.MoveDirection.x);
        _animator.SetBool(IsGround, _player.IsGrounded);
        _animator.SetInteger(MoveDirection, _moveDirectionRawX);
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