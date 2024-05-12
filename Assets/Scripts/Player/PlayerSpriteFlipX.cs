using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteFlipX : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Flip();
    }

    private void Flip()
    {
        if (PlayerMover.DirectionRaw > 0)
        {
            _renderer.flipX = false;
        }
        else if (PlayerMover.DirectionRaw < 0)
        {
            _renderer.flipX = true;
        }
    }
}