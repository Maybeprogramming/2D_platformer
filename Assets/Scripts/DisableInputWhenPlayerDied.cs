using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerInputModule))]
public class DisableInputWhenPlayerDied : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInputModule _input;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _input = GetComponent<PlayerInputModule>();
    }

    private void OnEnable()
    {
        _player.Died += OnDisableInput;
    }

    private void OnDisable()
    {
        _player.Died -= OnDisableInput;
    }

    private void OnDisableInput()
    {
        _input.enabled = false;
    }
}