using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem
{
    public class Inventory: IInventory
    {
        private List<Item> _items;

        private int _capacity;

        public List<Item> Items => _items;

        public int Capacity => _capacity;

        public Inventory(int capacity)
        {
            _items = new List<Item>();
            _capacity = capacity;
        }
        
        public bool AddItem(Item item)
        {
            if (_items.Count == _capacity)
                return false;
            _items.Add(item);
            return true;
        }

        public bool AddItem(int itemId)
        {
            //Item item = ScriptableObject.CreateInstance<>()
            throw new NotImplementedException();
        }

        public bool RemoveItem(int itemId)
        {
            var item = _items.FirstOrDefault((i) => i.Id == itemId);
            if (item == null)
                return false;
            return _items.Remove(item);
        }
    }
}