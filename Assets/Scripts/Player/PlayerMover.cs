using UnityEngine;

[RequireComponent(typeof(PlayerInputModule), typeof(PlayerInputModule))]
public class PlayerMover : Mover
{
    private Vector2 _directionRaw;
    private PlayerInputModule _playerInput;
    private SpriteFlipperAxisX _flipperAxisX;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputModule>();
    }
    private void Start()
    {
        _flipperAxisX = GetComponent<SpriteFlipperAxisX>();
    }

    private void Update()
    {        
        Move();
    }

    protected override void Move()
    {
        _directionRaw = _playerInput.MoveDirection;
        _flipperAxisX.Flip(_directionRaw);
        Vector2 nextPosition = _directionRaw * _speed * Time.deltaTime;
        transform.Translate(nextPosition);
    }
}