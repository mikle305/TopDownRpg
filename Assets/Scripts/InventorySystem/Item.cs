using System;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class Item: ScriptableObject, IItem
    {
        [SerializeField] private ItemUsageType _usageType;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private GameObject _inWorldPrefab;
        [SerializeField] private SpriteRenderer _icon;
        private static int _count;

        public int Id { get; private set; } = 0;
        
        public ItemUsageType UsageType => _usageType;

        public string Name => _name;

        public string Description => _description;

        public GameObject InWorldPrefab => _inWorldPrefab;
        
        public SpriteRenderer Icon => _icon;
        

        private void OnValidate()
        {
            if (Id > 0) return;
            _count++;
            Id = _count;
        }
    }
}