using System;
using UnityEngine;

namespace WeaponsSystem
{
    public class MeleeWeapon: MonoBehaviour, IWeapon
    {
        private WeaponAnimation _weaponAnimation;

        public Vector2 Direction { get; private set; }
        
        public bool IsReady { get; private set; }

        public event Action AttackInvoked;

        public void Attack()
        {
            AttackInvoked?.Invoke();
        }

        public void OnDirectionChanged(Vector2 direction)
        {
            Direction = direction;
        }

        private void Start()
        {
            _weaponAnimation = gameObject.GetComponent<WeaponAnimation>();
        }
    }
}