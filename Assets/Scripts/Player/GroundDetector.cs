using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _detector;
    [SerializeField] private float _radius;

    private Collider2D [] _grounds;

    public bool IsGrouded => HasGrounded();

    private bool HasGrounded()
    {
        Vector2 point = new Vector2(_detector.transform.position.x, _detector.transform.position.y);
        _grounds = Physics2D.OverlapCircleAll(point, _radius);

        foreach (Collider2D ground in _grounds)
        {
            if (ground.TryGetComponent(out Ground ground1) == true)
            {
                return true;
            }
        }

        return false;
    }
}