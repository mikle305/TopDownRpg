using System;
using System.Collections.Generic;

public class ModifiableStat: Stat
{
    private List<StatModifier> _modifiers;

    public override event Action ValueChanged;

    public override float Value { get => CalculateModifiedValue(); }


    public ModifiableStat(float baseValue) : base(baseValue)
    {
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
        float modifiedValue = (_value + additionBefore) * coefficient + additionAfter;
        return MathF.Round(modifiedValue, 2);
    }
}
