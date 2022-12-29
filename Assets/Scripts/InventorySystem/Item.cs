using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class Item: ScriptableObject, IItem
    {
        [SerializeField] private ItemUsageType _usageType;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        private static int _count;

        public int Id { get; private set; }
        
        public ItemUsageType UsageType => _usageType;

        public string Name => _name;

        public string Description => _description;


        private void OnEnable()
        {
            if (Id > 0) return;
            _count++;
            Id = _count;
            
        }
    }
}