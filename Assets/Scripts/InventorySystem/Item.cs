using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class Item: ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private GameObject _inWorldPrefab;
        [SerializeField] private SpriteRenderer _icon;

        public int Id => _id;
        public string Name => _name;
        public GameObject InWorldPrefab => _inWorldPrefab;
        public SpriteRenderer Icon => _icon;
    }
}