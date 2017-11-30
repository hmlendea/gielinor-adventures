namespace GielinorAdventures.Models
{
    /// <summary>
    /// Wall object.
    /// </summary>
    public class WallObject
    {
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
        /// The type.
        /// </summary>
        public int Type { get; set; }

        public int Unknown { get; set; }

        /// <summary>
        /// Gets or sets the height of the model.
        /// </summary>
        /// <value>The height of the model.</value>
        public int ModelHeight { get; set; }

        public int ModelFaceBack { get; set; }

        public int ModelFaceFront { get; set; }
    }
}
