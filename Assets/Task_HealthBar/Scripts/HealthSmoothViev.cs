using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothViev : HealthSimpleViev
{
    [SerializeField] private float _smoothSliderTime;

    private Coroutine _healthFilling;

    public override void OnHealthChanged(float healthValue, float maxValue)
    {
        if (_healthFilling != null)
        {
            StopCoroutine(_healthFilling);
        }

        _healthFilling = StartCoroutine(SliderValueFilling(healthValue, maxValue));

    }
    private IEnumerator SliderValueFilling(float currentHealthValue, float maxValue)
    {
        float targetValue = currentHealthValue / maxValue;
        float startValue = Slider.value;
        float timeElapsed = 0f;

        while (timeElapsed < _smoothSliderTime)
        {
            timeElapsed += Time.deltaTime;
            Slider.value = Mathf.Lerp(startValue, targetValue, timeElapsed / _smoothSliderTime);

            yield return null;
        }
    }
}