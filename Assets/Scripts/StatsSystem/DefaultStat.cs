using System;

public class DefaultStat: IStat
{
    private float _value;
    
    public event Action<float, float> ValueChanged;

    public float Value
    {
        get => _value;
        set
        {
            var oldValue = _value;
            _value = value;
            ValueChanged?.Invoke(oldValue, _value);
        }
    }

    public float GetValue()
    {
        return _value;
    }
}