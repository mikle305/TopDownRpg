using System;
using System.Collections.Generic;

public class ModifiableStat: IStat
{
    private float _baseValue;
    // Final value is using for cache.
    private float _finalValue;
    private readonly List<StatModifier> _modifiers;
    
    public event Action<float, float> ValueChanged;

    public float BaseValue
    {
        get => _baseValue;
        set
        {
            _baseValue = value;
            UpdateFinalValue();
        }
    }

    public float GetValue()
    {
        return _finalValue;
    }
    
    public ModifiableStat()
    {
        _modifiers = new List<StatModifier>();
    }

    public void AddModifier(StatModifier modifier)
    {
        _modifiers.Add(modifier);
        UpdateFinalValue();
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        var result = _modifiers.Remove(modifier);
        UpdateFinalValue();
        return result;
    }

    private void UpdateFinalValue()
    {
        var oldValue = _finalValue;
        _finalValue = CalculateModifiedValue();
        ValueChanged?.Invoke(oldValue, _finalValue);
    }

    private float CalculateModifiedValue()
    {
        float additionBefore = 0;
        float additionAfter = 0;
        float coefficient = 1;
        foreach (var modifier in _modifiers)
        {
            switch (modifier.Type)
            {
                case ModifierType.AdditionBefore:
                    additionBefore += modifier.Value;
                    break;
                case ModifierType.Coefficient:
                    coefficient += modifier.Value;
                    break;
                case ModifierType.AdditionAfter:
                    additionAfter += modifier.Value;
                    break;
                default:
                    throw new Exception("Unhandled modifier type");
            }
        }
        float modifiedValue = (BaseValue + additionBefore) * coefficient + additionAfter;
        return MathF.Round(modifiedValue, 2);
    }
}
