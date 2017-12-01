namespace GielinorAdventures.DataAccess.DataObjects
{
    /// <summary>
    /// Model entity.
    /// </summary>
    public class WorldObjectEntity
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
        /// Gets or sets the first command.
        /// </summary>
        /// <value>The first command.</value>
        public string Command1 { get; set; }

        /// <summary>
        /// Gets or sets the second command.
        /// </summary>
        /// <value>The second command.</value>
        public string Command2 { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }
    }
}
