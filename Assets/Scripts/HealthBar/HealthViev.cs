using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthViev : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;

    private Slider _slider;
    private Coroutine _smothChangedValue;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
    }

    private void OnEnable()
    {
        _health.HealhtValueChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealhtValueChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        if (_smothChangedValue != null && gameObject.activeSelf == true)
        {
            StopCoroutine(_smothChangedValue);
        }

        _smothChangedValue = StartCoroutine(SmothSliderValue(value));
    }

    IEnumerator SmothSliderValue(float currentHealthValue)
    {
        while (_slider.value != currentHealthValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealthValue, _speed);
            yield return null;
        }

        if (_slider.value == _health.MinValue)
        {
            StopAllCoroutines();
            _slider.gameObject.SetActive(false);
        }
    }
}
