using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _animator.SetTrigger("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _animator.SetTrigger("Run");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _animator.SetTrigger("Dead");
        }
    }
}