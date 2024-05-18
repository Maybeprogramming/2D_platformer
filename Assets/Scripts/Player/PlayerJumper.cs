using UnityEngine;

[RequireComponent(typeof(Player), typeof(Rigidbody2D), typeof(PlayerInputModule))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Player _player;
    private Rigidbody2D _rigidbody;
    private PlayerInputModule _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputModule>();
    }

    private void Start()
    {
        _player = GetComponent<Player>();
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