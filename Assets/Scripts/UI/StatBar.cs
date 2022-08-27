using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class StatBar : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _transitionDuration = 0.2f;

    private IStat _stat;
    private IStat _statMax;

    public void InitStats(IStat stat, IStat statMax)
    {
        _stat = stat;
        _statMax = statMax;
        _stat.ValueChanged += OnStat_ValueChanged;
        _statMax.ValueChanged += OnStatMax_ValueChanged;
    }

    private void OnStat_ValueChanged(float oldValue, float newValue)
    {
        _slider.maxValue = _statMax.GetValue();
        _slider.DOValue(newValue, _transitionDuration);
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    private void OnStatMax_ValueChanged(float oldValue, float newValue)
    {
        _slider.maxValue = newValue;
        _slider.value = _stat.GetValue();
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}