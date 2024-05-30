using UnityEngine;

[RequireComponent(typeof(SpriteFlipperAxisX), typeof(PlayerInputModule))]
public class PlayerMover : Mover
{
    private float _directionRaw;
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
        WalkState();
    }

    protected override void WalkState()
    {
        _directionRaw = _playerInput.MoveDirection.x;
        _flipperAxisX.Flip(_directionRaw);
        Vector2 nextPosition = Vector2.right * _directionRaw * BaseSpeed * Time.deltaTime;
        transform.Translate(nextPosition);
    }
}