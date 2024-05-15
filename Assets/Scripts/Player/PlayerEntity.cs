using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class PlayerEntity : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;
    [SerializeField] private GroundDetector _groundDetector;

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        _isGrounded = _groundDetector.IsGrouded;
    }
}