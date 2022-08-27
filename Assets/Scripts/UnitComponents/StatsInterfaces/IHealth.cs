public interface IHealth
{
    public void InitHealth(DefaultStat health, ModifiableStat maxHealth);

    public void IncreaseHealth(float value);

    public void DecreaseHealth(float health);

}