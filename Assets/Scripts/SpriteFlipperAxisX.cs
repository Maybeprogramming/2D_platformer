using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlipperAxisX : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Flip(float directionAxisX)
    {
        if (directionAxisX > 0)
        {
            _renderer.flipX = false;
        }
        else if (directionAxisX < 0)
        {
            _renderer.flipX = true;
        }
    }
}