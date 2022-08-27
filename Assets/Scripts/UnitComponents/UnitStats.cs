using UnityEngine;

public abstract class UnitStats : MonoBehaviour, IHealth
{
    protected DefaultStat _health;
    protected ModifiableStat _maxHealth;


    public virtual void DecreaseHealth(float health)
    {
        if (_health.Value - health <= 0) 
        {
            _health.Value = 0;
            Die();
        }  
        else
            _health.Value -= health;
    }

    public virtual void IncreaseHealth(float health)
    {
        if (_health.Value + health >= _maxHealth.GetValue())
            _health.Value = _maxHealth.GetValue();
        else
            _health.Value += health;
    }

    public virtual void InitHealth(DefaultStat health, ModifiableStat maxHealth)
    {
        _health = health;
        _maxHealth = maxHealth;
        if (_health.Value > _maxHealth.GetValue())
            _health.Value = _maxHealth.GetValue();
    }


    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}