using System.Collections.Generic;

namespace InventorySystem
{
    public interface IInventory
    {
        public List<IInventoryItem> Items { get; }
        
        public int Capacity { get; }
        
        public bool IsFull { get; }
        
        /// <summary>
        /// Add item to inventory.
        /// Returns false if inventory is full.
        /// </summary>
        public bool TryAddItem(IInventoryItem item);

        /// <summary>
        /// Add item to inventory by id.
        /// Returns false if inventory is full.
        /// </summary>
        public bool TryAddItem(int itemId);

        /// <summary>
        /// Remove item from inventory by id.
        /// Returns false if item wasn't found.
        /// </summary>
        public bool TryRemoveItem(int itemId);
    }
}