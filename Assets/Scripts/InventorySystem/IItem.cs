namespace InventorySystem
{
    public interface IItem
    {
        public int Id { get; }
        
        public ItemUsageType UsageType { get; }

        public string Name { get; }

        public string Description { get; }
    }

    public enum ItemUsageType
    {
        Default,
        Consumable,
        Clothes,
        Tool,
        Weapon
    } 
}