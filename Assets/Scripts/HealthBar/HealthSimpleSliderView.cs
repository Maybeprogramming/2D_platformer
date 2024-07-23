using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSimpleSliderView : HealthBaseViewValue
{
    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    public override void OnHealthChanged(float healthValue, float maxValue)
    {
        Slider.value = healthValue / maxValue;
    }
}