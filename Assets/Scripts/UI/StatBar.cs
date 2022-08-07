using UnityEngine.UI;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;

    [SerializeField] private Image _fill;

    private Slider _slider;

    private Stat _stat;

    private Stat _statMax;


    public void InitStats(Stat stat, Stat statMax)
    {
        _stat = stat;
        _statMax = statMax;
        ChangeFiller();
        _stat.ValueChanged += OnStatChanged;
        _statMax.ValueChanged += OnStatChanged;
    }


    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnStatChanged()
    {
        ChangeFiller();
    }

    private void ChangeFiller()
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