using System;
using UnityEngine;

namespace WeaponsSystem
{
    public class MeleeWeapon: IWeapon
    {
        public bool IsReady { get; private set; }
        
        public void Attack(Vector2 direction)
        {
            throw new NotImplementedException();
        }
    }
}