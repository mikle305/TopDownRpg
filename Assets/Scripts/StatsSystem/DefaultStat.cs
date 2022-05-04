 using System;
using UnityEngine;

public class DefaultStat: IDefaultStat
{
    private float _value;

    public event Action ValueChanged;

    public float Value { get => _value; }


    public DefaultStat(float value)
    {
        _value = value;
    }

    public void Increase(float value)
    {
        _value += value;
        ValueChanged?.Invoke();
    }

    public void Decrease(float value)
    {
        if (_value - value <= 0)
            _value = 0;
        else
            _value -= value;
        ValueChanged?.Invoke();
    }
}