using System;
using UnityEngine;

namespace WeaponsSystem
{
    public interface IWeapon
    {
        public Vector2 Direction { get; }
        
        public bool IsReady { get; }
        
        public event Action AttackInvoked;

        public void Attack();

        public void OnDirectionChanged(Vector2 direction);
    }
}