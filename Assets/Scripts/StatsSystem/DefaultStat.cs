using System;

public class DefaultStat: Stat
{
    public override event Action ValueChanged;

    public override float Value { 
        get => _value; 
    }

    public void SetValue(float value)
    {
        _value = value;
        ValueChanged?.Invoke();
    }

    public DefaultStat(float baseValue) : base(baseValue)
    {
    }
}