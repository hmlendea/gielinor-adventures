namespace GielinorAdventures.Models
{
    /// <summary>
    /// Inventory item.
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="InventoryItem"/> is equipped.
        /// </summary>
        /// <value><c>true</c> if is equipped; otherwise, <c>false</c>.</value>
        public bool IsEquipped { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItem"/> class.
        /// </summary>
        public InventoryItem()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItem"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public InventoryItem(string id)
        {
            Id = id;
            Quantity = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItem"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="quantity">Quantity.</param>
        public InventoryItem(string id, int quantity)
            : this(id)
        {
            Quantity = quantity;
        }
    }
}
