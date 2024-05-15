using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyMover))]
public class EnemyFlipperX : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private EnemyMover _enemyMover;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        Flip();
    }

    private void Flip()
    {
        if (_enemyMover.MoveDirectionX < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_enemyMover.MoveDirectionX > 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}