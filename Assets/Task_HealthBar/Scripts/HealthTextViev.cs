using TMPro;
using UnityEngine;

public class HealthTextViev : HealthBaseViev
{
    [SerializeField] private TextMeshProUGUI _healthTextEntity;

    public override void OnHealthChanged(float healthValue, float minValue, float maxValue)
    {
        UpdateTextBar(healthValue, maxValue);
    }

    private void UpdateTextBar(float healthValue, float maxValue)
    {
        _healthTextEntity.text = $"{healthValue}/{maxValue}";
    }
}