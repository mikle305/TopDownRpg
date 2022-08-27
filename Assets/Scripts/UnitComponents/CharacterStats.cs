using UnityEngine;

public class CharacterStats : UnitStats
{
    private DefaultStat _stamina;
    private ModifiableStat _maxStamina;
    private DefaultStat _satiety;
    private ModifiableStat _maxSatiety;
    private ModifiableStat _speed;


    public void InitSatiety(DefaultStat satiety, ModifiableStat maxSatiety)
    {
        _satiety = satiety;
        _maxSatiety = maxSatiety;
        if (_satiety.Value > _maxSatiety.GetValue())
            _satiety.Value = _maxSatiety.GetValue();
    }

    public void InitStamina(DefaultStat stamina, ModifiableStat maxStamina)
    {
        _stamina = stamina;
        _maxStamina = maxStamina;
        if (_stamina.Value > _maxStamina.GetValue())
            _stamina.Value = _maxStamina.GetValue();
    }

    public void InitSpeed(ModifiableStat speed)
    {
        _speed = speed;
    }


    protected override void Die()
    {

    }
}
