using UnityEngine;
using System;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected DefaultStat _health;

    [SerializeField]
    protected ModifiableStat _maxHealth;

    public DefaultStat Health { get => _health; }

    public ModifiableStat MaxHealth { get => _maxHealth; }


    private void Start()
    {
        _health = new DefaultStat(10.0f);
        _maxHealth = new ModifiableStat(15.0f);
    }

    public virtual void ApplyDamage(float damage)
    {
        if (_health.Value - damage <= 0) 
        {
            Health.Decrease(_health.Value);
            Die();
        }  
        else
            Health.Decrease(damage);
    }

    public virtual void ApplyHeal(float health)
    {
        if (_health.Value + health >= _maxHealth.Value)
            _health.Increase(_maxHealth.Value - _health.Value);
        else
            _health.Increase(health);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}