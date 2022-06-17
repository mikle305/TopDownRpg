using UnityEngine;

public class Character : Unit
{
    [SerializeField]
    private float _baseDamage;

    private ModifiableStat _damage;

    protected override void Start()
    {
        base.Start();
        _damage = new ModifiableStat(_baseDamage);
    }

    protected override void Die()
    {

    }
}
