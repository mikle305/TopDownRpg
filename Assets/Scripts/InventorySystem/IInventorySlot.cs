namespace InventorySystem
{
    public interface IInventorySlot
    {
        public bool IsEmpty();

        public void SetItem(IInventoryItem inventoryItem);
        
        public void Clear();
    }
}