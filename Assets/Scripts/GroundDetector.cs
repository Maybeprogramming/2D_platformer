using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _detector;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _groundableLayerMask;

    private Vector2 _point;

    public bool IsGrouded => HasGrounded();

    private bool HasGrounded()
    {
        SetDetectorPointPosition();
        return Physics2D.OverlapCircle(_point, _radius, _groundableLayerMask);
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