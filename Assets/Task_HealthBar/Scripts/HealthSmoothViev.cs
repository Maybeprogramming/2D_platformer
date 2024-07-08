using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothViev : HealthBaseViev
{
    [SerializeField] private float _smoothStepTarget;

    private Slider _slider;
    private Coroutine _healthFilling;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
    }

    public override void OnHealthChanged(float healthValue)
    {
        if (_healthFilling != null)
        {
            StopCoroutine(_healthFilling);
        }

        _healthFilling = StartCoroutine(SliderValueFilling(healthValue));
    }

    private IEnumerator SliderValueFilling(float currentHealthValue)
    {
        float stepElapsed = 0;
        float stepTarget = _smoothStepTarget;
        float deltaMax = currentHealthValue - _slider.value;
        float deltaStep = deltaMax / stepTarget;

        while (stepElapsed < stepTarget)
        {
            _slider.value = Mathf.Clamp(_slider.value + deltaStep, _health.MinValue, _health.MaxValue);
            stepElapsed++;

            yield return null;
        }

        if (_slider.value == _health.MinValue)
        {
            StopAllCoroutines();
        }
    }
}