namespace GielinorAdventures.DataAccess.DataObjects
{
    /// <summary>
    /// Elevation entity.
    /// </summary>
    public class ElevationEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        public int Roof { get; set; }

        public int Unknown { get; set; }
    }
}
