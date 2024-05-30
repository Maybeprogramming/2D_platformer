using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthViev : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;

    private Slider _slider;
    private Coroutine _smoothHealthFilling;
    private bool isBarActive = false;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
    }

    private void OnEnable()
    {
        _health.ValueChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        if (_smoothHealthFilling != null && gameObject.activeSelf == true)
        {
            StopCoroutine(_smoothHealthFilling);
        }

        _smoothHealthFilling = StartCoroutine(SmoothValueFilling(value));
    }

    private IEnumerator SmoothValueFilling(float currentHealthValue)
    {
        while (_slider.value != currentHealthValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealthValue, _speed);
            yield return null;
        }

        if (_slider.value == _health.MinValue)
        {
            StopAllCoroutines();
            _slider.gameObject.SetActive(isBarActive);
        }
    }
}
