using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player), typeof(PlayerInputModule))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Jump = "Jump";
    private const string Attack = "Attack";
    private const string Dead = "Dead";
    private const string IsDead = "IsDead";
    private const string Hit = "Hit";
    private const string IsGround = "IsGround";
    private const string MoveDirection = "MoveDirection";

    private PlayerInputModule _playerInput;
    private Player _player;
    private Animator _animator;
    private int _moveDirectionRawX;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputModule>();
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.AttackButtonDowned += OnAmimationAttacked;
        _playerInput.JumpButtonDowned += OnAnimationJumped;
        _player.Died += OnAnimationDied;
        _player.DamageReceived += OnAnimationHit;
    }

    private void OnDisable()
    {
        _playerInput.AttackButtonDowned -= OnAmimationAttacked;
        _playerInput.JumpButtonDowned -= OnAnimationJumped;
        _player.Died -= OnAnimationDied;
        _player.DamageReceived -= OnAnimationHit;
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

    private void OnAnimationDied()
    {
        if (_player.IsAlive == false)
        {
            _animator.SetBool(IsDead, !_player.IsAlive);
            _animator.SetTrigger(Dead);
        }
    }

    private void OnAnimationHit()
    {
        _animator.SetTrigger(Hit);
    }
}