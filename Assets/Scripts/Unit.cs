using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected DefaultStat _health;

    protected ModifiableStat _maxHealth;

    public DefaultStat Health { get => _health; }

    public ModifiableStat MaxHealth { get => _maxHealth; }

    private void Start()
    {
        if (_health.Value > _maxHealth.Value)
            _health.SetValue(_maxHealth.Value);
    }

    public virtual void ApplyDamage(float damage)
    {
        if (_health.Value - damage <= 0) 
        {
            _health.SetValue(0);
            Die();
        }  
        else
            _health.SetValue(_health.Value - damage);
    }

    public virtual void ApplyHeal(float health)
    {
        if (_health.Value + health >= _maxHealth.Value)
            _health.SetValue(_maxHealth.Value);
        else
            _health.SetValue(_health.Value + health);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}