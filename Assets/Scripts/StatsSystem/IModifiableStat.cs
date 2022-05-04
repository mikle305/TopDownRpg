public interface IModifiableStat: IStat
{
    public void AddModifier(StatModifier modifier);

    public bool RemoveModifier(StatModifier modifier);
}

