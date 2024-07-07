using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSimpleViev : HealthBaseViev
{
    [SerializeField] private float _stepDelta;

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
        if (_healthFilling != null && gameObject.activeSelf == true)
        {
            StopCoroutine(_healthFilling);
        }

        _healthFilling = StartCoroutine(SliderValueFilling(healthValue));
    }

    private IEnumerator SliderValueFilling(float currentHealthValue)
    {
        while (_slider.value != currentHealthValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealthValue, _stepDelta);
            yield return null;
        }

        if (_slider.value == _health.MinValue)
        {
            StopAllCoroutines();
        }
    }
}