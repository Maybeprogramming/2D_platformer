using UnityEngine;
using UnityEngine.UI;

public class EntityHealer : MonoBehaviour
{
    [SerializeField] private HealthPoint _health;
    [SerializeField] private float _healthHealPoint;
    [SerializeField] private Button _healingButton;

    private void OnEnable()
    {
        _healingButton.onClick.AddListener(Healing);
    }

    private void OnDisable()
    {
        _healingButton.onClick.RemoveListener(Healing);
    }

    public void Healing()
    {
        _health.Add(_healthHealPoint);
    }
}