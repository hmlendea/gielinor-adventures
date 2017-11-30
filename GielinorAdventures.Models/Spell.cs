namespace GielinorAdventures.Models
{
    /// <summary>
    /// Spell.
    /// </summary>
    public class Spell
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
        /// Gets or sets the required level to use this <see cref="Spell"/>.
        /// </summary>
        /// <value>The required level.</value>
        public int RequiredLevel { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the number of different runes needed to cast this <see cref="Spell"/>.
        /// </summary>
        /// <value>The rune count.</value>
        public int RuneCount { get; set; }

        /// <summary>
        /// Gets or sets the required runes.
        /// Keys are rune identifiers, values are the amount.
        /// </summary>
        /// <value>The required runes.</value>
        //public IDictionary<int, int> RequiredRunes { get; set; }

        // TODO: Replace those with a dictionary
        public int[] RequiredRunesIds { get; set; }
        public int[] RequiredRunesCounts { get; set; }

        /// <summary>
        /// Gets or sets the amount of experience gained by using this <see cref="Spell"/>.
        /// </summary>
        /// <value>The experience gain.</value>
        public int ExperienceGain { get; set; }
    }
}
