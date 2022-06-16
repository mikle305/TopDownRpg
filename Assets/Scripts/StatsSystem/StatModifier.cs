public class StatModifier
{
    private readonly float _value;
    private readonly ModifierType _type;

    public float Value { get => _value; }

    public ModifierType Type  { get => _type; }


    public StatModifier(float value, ModifierType type)
    /// <summary>
    /// With type coefficient value 0.1 equals +10%, -0.1 equals -10%
    /// </summary>
    /// <param name="type"></param>
    {
        _value = value;
        _type = type;
    }
}

public enum ModifierType
{
    AdditionBefore,
    Coefficient,
    AdditionAfter
}
