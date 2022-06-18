using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected DefaultStat _health;
    protected ModifiableStat _maxHealth;


    public virtual void DecreaseHealth(float damage)
    {
        if (_health.Value - damage <= 0) 
        {
            _health.SetValue(0);
            Die();
        }  
        else
            _health.SetValue(_health.Value - damage);
    }

    public virtual void IncreaseHealth(float health)
    {
        if (_health.Value + health >= _maxHealth.Value)
            _health.SetValue(_maxHealth.Value);
        else
            _health.SetValue(_health.Value + health);
    }

    public virtual void InitHealth(DefaultStat health, ModifiableStat maxHealth)
    {
        _health = health;
        _maxHealth = maxHealth;
        if (_health.Value > _maxHealth.Value)
            _health.SetValue(_maxHealth.Value);
    }


    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}