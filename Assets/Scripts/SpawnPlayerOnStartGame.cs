using UnityEngine;

public class SpawnPlayerOnStartGame : MonoBehaviour
{
    [SerializeField] private PlayerDetectorByWorldOut _playerDetectorOutWorld;

    private void OnEnable()
    {
        _playerDetectorOutWorld.PlayerOutWorldDetected += OnPlayerRespawning;
    }

    private void OnDisable()
    {
        _playerDetectorOutWorld.PlayerOutWorldDetected -= OnPlayerRespawning;
    }

    private void OnPlayerRespawning(Player player)
    {
        player.transform.position = transform.position;
    }
}