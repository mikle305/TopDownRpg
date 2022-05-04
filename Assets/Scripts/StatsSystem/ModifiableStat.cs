using System;
using System.Collections.Generic;
using UnityEngine;

public class ModifiableStat: IModifiableStat
{
    private float _value;

    private List<StatModifier> _modifiers;

    public event Action ValueChanged;

    public float Value { get => CalculateModifiedValue(); }


    public ModifiableStat(float value)
    {
        _value = value;
        _modifiers = new List<StatModifier>();
    }

    public void AddModifier(StatModifier modifier)
    {
        _modifiers.Add(modifier);
        ValueChanged?.Invoke();
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        bool result = _modifiers.Remove(modifier);
        ValueChanged?.Invoke();
        return result;
    }

    private float CalculateModifiedValue()
    {
        float modifiedValue = _value;
        float totalCoefficient = 1;
        foreach (var modifier in _modifiers)
        {
            if (modifier.Type == StatModifier.ModifierType.flat)
                modifiedValue += modifier.Value;
            else
                totalCoefficient += modifier.Value;
        }
        modifiedValue *= totalCoefficient;
        return MathF.Round(modifiedValue, 2);
    }
}
