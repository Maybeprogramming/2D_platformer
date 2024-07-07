using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothViev : HealthBaseViev
{
    [SerializeField] private float _stepDelta;
    [SerializeField] private float _smoothTime;

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
        float elapsedTime = 0f;
        float smoothTime = _smoothTime;
        

        while (elapsedTime < smoothTime)
        {
            elapsedTime += Time.deltaTime;
            float percentElapsedTime = elapsedTime / smoothTime;
            float delta = currentHealthValue - _slider.value;
            float nextValue = currentHealthValue * percentElapsedTime;
            float stepValue = _slider.value - nextValue;
            Debug.Log(nextValue);
            _slider.value += stepValue;

            Debug.Log(percentElapsedTime);


            yield return null;
        }

        if (_slider.value == _health.MinValue)
        {
            StopAllCoroutines();
        }
    }
}