namespace GielinorAdventures.Models
{
    /// <summary>
    /// World tile.
    /// </summary>
    public class WorldTile
    {
        /// <summary>
        /// Gets or sets the sprite sheet frame.
        /// </summary>
        /// <value>The sprite sheet frame.</value>
        public int SpriteSheetFrame { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        public string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the terrain identifier.
        /// </summary>
        /// <value>The terrain identifier.</value>
        public string TerrainId { get; set; }
    }
}
