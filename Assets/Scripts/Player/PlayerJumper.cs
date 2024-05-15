using UnityEngine;

[RequireComponent(typeof(PlayerEntity))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private PlayerEntity _player;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _player = GetComponent<PlayerEntity>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _player.IsGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
}