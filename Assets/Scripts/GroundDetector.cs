using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _detector;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _groundableLayerMask;

    public bool IsGrouded => HasGrounded();

    private bool HasGrounded()
    {
        Vector2 point = new Vector2(_detector.transform.position.x, _detector.transform.position.y);

        return Physics2D.OverlapCircle(point, _radius, _groundableLayerMask);
    }
}