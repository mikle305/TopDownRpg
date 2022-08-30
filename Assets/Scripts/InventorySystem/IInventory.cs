using System.Collections.Generic;

namespace InventorySystem
{
    public interface IInventory
    {
        public List<Item> Items { get; }
        
        /// <summary>
        /// Add item to inventory.
        /// Returns false if inventory is full.
        /// </summary>
        public bool AddItem(Item item);

        /// <summary>
        /// Add item to inventory by id.
        /// Returns false if inventory is full.
        /// </summary>
        public bool AddItem(int itemId);

        /// <summary>
        /// Remove item from inventory by id.
        /// Returns false if item wasn't found.
        /// </summary>
        public bool RemoveItem(int itemId);
    }
}