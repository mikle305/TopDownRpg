using UnityEngine.UI;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;

    [SerializeField] private Image _fill;

    private Slider _slider;

    private Stat _stat;

    private Stat _statMax;

    public Stat Stat { get => _stat; set => _stat = value; }

    public Stat StatMax { get => _statMax; set => _statMax = value; }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        SetValue();
        _stat.ValueChanged += OnStatChanged;
        _statMax.ValueChanged += OnStatChanged;
    }


    private void OnStatChanged()
    {
        SetValue();
    }

    private void SetValue()
    {
        _slider.maxValue = _statMax.Value;
        _slider.value = _stat.Value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    ~StatBar()
    {
        _stat.ValueChanged -= OnStatChanged;
        _statMax.ValueChanged -= OnStatChanged;
    }
}