﻿namespace GielinorAdventures.Models
{
    /// <summary>
    /// Game item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets the base price.
        /// </summary>
        /// <value>The base price.</value>
        public int BasePrice { get; set; }

        /// <summary>
        /// Gets or sets the sprite identifier.
        /// </summary>
        /// <value>The sprite identifier.</value>
        public int SpriteId { get; set; }

        /// <summary>
        /// Gets or sets the inventory picture.
        /// </summary>
        /// <value>The inventory picture.</value>
        public int InventoryPicture { get; set; }

        /// <summary>
        /// Gets or sets the picture mask.
        /// </summary>
        /// <value>The picture mask.</value>
        public int PictureMask { get; set; }

        // TODO: Convert to bool
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Item"/> is equipable.
        /// </summary>
        /// <value><c>true</c> if it is equipable; otherwise, <c>false</c>.</value>
        public int IsEquipable { get; set; }

        // TODO: Convert to bool
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Item"/> is premium.
        /// </summary>
        /// <value><c>true</c> if it is premium; otherwise, <c>false</c>.</value>
        public int IsPremium { get; set; }

        // TODO: Convert to bool
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Item"/> is special.
        /// </summary>
        /// <value><c>true</c> if it is special; otherwise, <c>false</c>.</value>
        public int IsSpecial { get; set; }

        // TODO: Convert to bool
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Item"/> is stackable.
        /// </summary>
        /// <value><c>true</c> if it is stackable; otherwise, <c>false</c>.</value>
        public int IsStackable { get; set; }

        // TODO: Convert to bool
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Item"/> is unused.
        /// </summary>
        /// <value><c>true</c> if is unused; otherwise, <c>false</c>.</value>
        public int IsUnused { get; set; }
    }
}
