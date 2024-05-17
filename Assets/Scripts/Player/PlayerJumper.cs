using UnityEngine;

[RequireComponent(typeof(PlayerEntity), typeof(Rigidbody2D), typeof(PlayerInputModule))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private PlayerEntity _player;
    private Rigidbody2D _rigidbody;
    private PlayerInputModule _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputModule>();
    }

    private void Start()
    {
        _player = GetComponent<PlayerEntity>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _playerInput.JumpButtonDowned += OnJumped;
    }

    private void OnDisable()
    {
        _playerInput.JumpButtonDowned -= OnJumped;
    }

    private void OnJumped()
    {
        if (_player.IsGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
}