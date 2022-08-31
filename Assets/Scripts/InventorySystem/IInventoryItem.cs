namespace InventorySystem
{
    public interface IInventoryItem
    {
        public IItem Item { get; }
        
        public int MaxCountInInventorySlot { get; }
        
        public int CurrentCountInInventorySlot { get; }
    }
}