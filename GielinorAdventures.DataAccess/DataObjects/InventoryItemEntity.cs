using NuciXNA.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.DataObjects
{
    public class InventoryItemEntity : EntityBase
    {
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }
    }
}
