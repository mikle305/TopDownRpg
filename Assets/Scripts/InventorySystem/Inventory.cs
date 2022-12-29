using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem
{
    public class Inventory: IInventory
    {
        public List<IInventoryItem> Items { get; }

        public int Capacity { get; set; }
        
        public bool IsFull { get; private set; }

        public Inventory(int capacity)
        {
            Items = new List<IInventoryItem>();
            Capacity = capacity;
        }
        
        public bool TryAddItem(IInventoryItem item)
        {
            if (Items.Count >= Capacity)
                return false; 
            
            Items.Add(item);
            return true;
        }

        public bool TryAddItem(int itemId)
        {
            //return Item.GetAll().FirstOrDefault(i => i.id = itemId);
            //Item item = ScriptableObject.CreateInstance<>()
            throw new NotImplementedException();
        }

        public bool TryRemoveItem(int itemId)
        {
            IInventoryItem item = Items.FirstOrDefault((i) => i.Item.Id == itemId);
            if (item == null)
                return false;
            
            return Items.Remove(item);
        }
    }
}