namespace GielinorAdventures.DataAccess.DataObjects
{
    /// <summary>
    /// Tile entity.
    /// </summary>
    public class TileEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the colour.
        /// </summary>
        /// <value>The colour.</value>
        public int Colour { get; set; }

        public int Unknown { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public int Type { get; set; }
    }
}
