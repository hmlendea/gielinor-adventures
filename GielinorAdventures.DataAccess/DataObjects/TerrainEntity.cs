namespace GielinorAdventures.DataAccess.DataObjects
{
    /// <summary>
    /// Terrain entity.
    /// </summary>
    public class TerrainEntity
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
        /// Gets or sets the colour hexadecimal.
        /// </summary>
        /// <value>The colour hexadecimal.</value>
        public string ColourHexadecimal { get; set; }
    }
}
