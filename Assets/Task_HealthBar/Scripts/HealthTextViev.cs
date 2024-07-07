using TMPro;
using UnityEngine;

public class HealthTextViev : HealthBaseViev
{
    [SerializeField] private TextMeshProUGUI _healthTextEntity;

    private string _healthText;

    private void Start()
    {
        UpdateText(_health.CurrentValue);
    }

    public override void OnHealthChanged(float healthValue)
    {
        UpdateText(healthValue);
    }

    private void UpdateText(float healthValue)
    {
        _healthText = $"{healthValue}/{_health.MaxValue}";
        _healthTextEntity.text = _healthText;
    }
}