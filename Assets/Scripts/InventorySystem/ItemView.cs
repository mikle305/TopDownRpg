using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/ItemView")]
    public class ItemView: ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private SpriteRenderer _icon;
        
        public GameObject Prefab => _prefab;
        
        public SpriteRenderer Icon => _icon;
    }
}