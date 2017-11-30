namespace GielinorAdventures.Models
{
    public class InventoryItem
    {
        public string Id { get; set; }

        public int Index { get; set; }

        public int Quantity { get; set; }

        public bool IsEquipped { get; set; }
    }
}
