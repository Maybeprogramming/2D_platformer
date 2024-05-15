using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerFlipperX : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    private SpriteRenderer _renderer;
    private int _directionRawX;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Flip();
    }

    public void Flip()
    {
        _directionRawX = (int)Input.GetAxisRaw(nameof(Horizontal));

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