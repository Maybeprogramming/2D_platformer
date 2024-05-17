using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(EnemyMover))]
public class EnemyFlipperX : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private EnemyMover _enemyMover;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    //private void Update()
    //{
    //    Flip();
    //}

    //private void Flip()
    //{
    //    if (_enemyMover._moveDirectionX < 0)
    //    {
    //        _spriteRenderer.flipX = false;
    //    }
    //    else if (_enemyMover._moveDirectionX > 0)
    //    {
    //        _spriteRenderer.flipX = true;
    //    }
    //}
}