using UnityEngine;

public class Character : Unit
{
    private ModifiableStat _damage;
    private DefaultStat _stamina;
    private ModifiableStat _maxStamina;
    private DefaultStat _satiety;
    private ModifiableStat _maxSatiety;


    public virtual void InitSatiety(DefaultStat satiety, ModifiableStat maxSatiety)
    {
        _satiety = satiety;
        _maxSatiety = maxSatiety;
        if (_satiety.Value > _maxSatiety.Value)
            _satiety.SetValue(_maxSatiety.Value);
    }

    public virtual void InitStamina(DefaultStat stamina, ModifiableStat maxStamina)
    {
        _stamina = stamina;
        _maxStamina = maxStamina;
        if (_stamina.Value > _maxStamina.Value)
            _stamina.SetValue(_maxStamina.Value);
    }

    public virtual void InitDamage(ModifiableStat damage)
    {
        _damage = damage;
    }


    protected override void Die()
    {

    }
}
