using System;

namespace InventorySystem
{
    public interface IInventoryItem
    {
        public IItem Item { get; }
        
        public int MaxCount { get; }
        
        public int Count { get; }
        
        public Type Type { get; }
    }
}