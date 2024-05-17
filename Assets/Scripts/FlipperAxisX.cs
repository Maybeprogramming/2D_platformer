using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlipperAxisX : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private int _directionRawX;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Flip(Vector2 direction)
    {
        _directionRawX = (int)direction.x;

        if (_directionRawX > 0)
        {
            _renderer.flipX = false;
        }
        else if (_directionRawX < 0)
        {
            _renderer.flipX = true;
        }
    }
}