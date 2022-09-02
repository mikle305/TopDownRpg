using UnityEngine;

namespace WeaponsSystem
{
    public interface IWeapon
    {
        public bool IsReady { get; }

        public void Attack(Vector2 direction);
    }
}