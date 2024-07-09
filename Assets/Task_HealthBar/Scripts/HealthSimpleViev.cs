using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSimpleViev : HealthBaseViev
{
    [SerializeField] private float _stepDelta;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
    }

    public override void OnHealthChanged(float healthValue)
    {
        _slider.value = Mathf.Clamp(healthValue, _health.MinValue, _health.MaxValue);
    }
}