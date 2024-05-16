using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerEntity))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Run = "Run";
    private const string Idle = "Idle";
    private const string Jump = "Jump";
    private const string Horizontal = "Horizontal";

    [SerializeField] private float moveDelta = 0.1f;

    private float _playerMove;
    private PlayerEntity _player;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerEntity>();
    }

    private void Update()
    {
        _playerMove = Input.GetAxis(nameof(Horizontal));

        if(Mathf.Abs(_playerMove) > moveDelta && _player.IsGrounded == true)
        {
            _animator.SetTrigger(nameof(Run));
        }
        else if (_player.IsGrounded == true)
        {
            _animator.SetTrigger(nameof(Idle));
        }

        if (_player.IsGrounded == false)
        {
            JumpAnimation();
        }
    }

    private void JumpAnimation()
    {
        _animator.SetTrigger(nameof(Jump));
    }
}