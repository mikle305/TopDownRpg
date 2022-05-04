using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Unit _unit;

    [SerializeField]
    private Gradient _gradient;

    [SerializeField]
    private Image _fill;

    private Slider _slider;


    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _unit.MaxHealth.Value;
        _slider.value = _unit.Health.Value;
        _unit.Health.ValueChanged += OnUnit_HealthChanged;
        _unit.MaxHealth.ValueChanged += OnUnit_MaxHealthChanged;
        _fill.color = _gradient.Evaluate(1.0f);
    }

    private void OnUnit_HealthChanged()
    {
        _slider.maxValue = _unit.MaxHealth.Value;
        _slider.value = _unit.Health.Value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    private void OnUnit_MaxHealthChanged()
    {
        _slider.maxValue = _unit.MaxHealth.Value;
        _slider.value = _unit.Health.Value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    ~HealthBar()
    {
        _unit.Health.ValueChanged -= OnUnit_HealthChanged;
        _unit.MaxHealth.ValueChanged -= OnUnit_MaxHealthChanged;
    }
}