using UnityEngine.UI;
using UnityEngine;

public class StatBarView : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private Slider _slider;
    
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

    private void OnDestroy()
    {
        _stat.ValueChanged -= OnStatChanged;
        _statMax.ValueChanged -= OnStatChanged;
    }
}