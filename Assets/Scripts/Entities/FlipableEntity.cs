using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlipableEntity : MonoBehaviour, IFlipable
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public SpriteRenderer GetRenderer()
    {
        return _spriteRenderer;
    }
}