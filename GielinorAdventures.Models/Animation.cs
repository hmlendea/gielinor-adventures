namespace GielinorAdventures.Models
{
    /// <summary>
    /// Animation.
    /// </summary>
    public class Animation
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the character colour.
        /// </summary>
        /// <value>The character colour.</value>
        public int CharacterColour { get; set; }

        /// <summary>
        /// Gets or sets the gender model.
        /// </summary>
        /// <value>The gender model.</value>
        public int GenderModel { get; set; }

        // TODO: Convert to bool
        public int HasA { get; set; }

        // TODO: Convert to bool
        public int HasF { get; set; }

        public int Number { get; set; }
    }
}
