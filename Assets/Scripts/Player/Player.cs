using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;

    [SerializeField] private GroundDetector _groundDetector;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        _isGrounded = _groundDetector.IsGrouded;
    }
}