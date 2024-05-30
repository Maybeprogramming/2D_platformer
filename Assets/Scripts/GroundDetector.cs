using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _detector;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _groundableLayerMask;
    [SerializeField] private Groundable _groundable;

    private Vector2 _point;

    public bool IsGrouded => HasGrounded();

    private bool HasGrounded()
    {
        SetDetectorPointPosition();

        bool groundableMask = Physics2D.OverlapCircle(_point, _radius, _groundableLayerMask);
        Collider2D detectedEntity = Physics2D.OverlapCircle(_point, _radius);
        detectedEntity.TryGetComponent(out _groundable);
        bool groundableEntity = _groundable != null ? true : false;

        return groundableMask || groundableEntity;
    }

    private void OnDrawGizmos()
    {
        SetDetectorPointPosition();
        Gizmos.DrawWireSphere(_point, _radius);
    }

    private void SetDetectorPointPosition()
    {
        _point = new Vector2(_detector.transform.position.x, _detector.transform.position.y);
    }
}