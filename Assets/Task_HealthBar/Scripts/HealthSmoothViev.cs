using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothViev : HealthSimpleViev
{
    [SerializeField] private float _smoothSliderTime;

    private Coroutine _healthFilling;

    public override void OnHealthChanged(float healthValue, float minValue, float maxValue)
    {
        if (_healthFilling != null)
        {
            StopCoroutine(_healthFilling);
        }

        _healthFilling = StartCoroutine(SliderValueFilling(healthValue, minValue, maxValue));
    }

    private IEnumerator SliderValueFilling(float currentHealthValue, float minValue, float maxValue)
    {
        float currentValue = currentHealthValue / maxValue;
        float timeElapsed = 0f;

        while (timeElapsed < _smoothSliderTime)
        {
            timeElapsed += Time.deltaTime;
            Slider.value = Mathf.Lerp(Slider.value, currentValue, timeElapsed/_smoothSliderTime);

            yield return null;
        }
    }
}