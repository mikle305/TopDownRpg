using System;

public abstract class Stat
{
    protected float _value;

    public Stat(float baseValue)
    {
        _value = baseValue;
    }

    public abstract float Value { get; }

    public abstract event Action ValueChanged;
}


