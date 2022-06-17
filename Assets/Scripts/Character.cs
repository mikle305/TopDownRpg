using UnityEngine;

public class Character : Unit
{
    private ModifiableStat _damage;
    private DefaultStat _stamina;
    private ModifiableStat _maxStamina;
    private DefaultStat _satiety;
    private ModifiableStat _maxSatiety;


    public ModifiableStat Damage { set => _damage = value; }

    public DefaultStat Stamina { set => _stamina = value; }

    public ModifiableStat MaxStamina { set => _maxStamina = value; }

    public DefaultStat Satiety { set => _satiety = value; }

    public ModifiableStat MaxSatiety { set => _maxSatiety = value; }


    protected override void Die()
    {

    }
}
