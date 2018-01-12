using NuciXNA.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.DataObjects
{
    /// <summary>
    /// Spell entity.
    /// </summary>
    public class SpellEntity : EntityBase
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
        /// Gets or sets the required level to use this <see cref="SpellEntity"/>.
        /// </summary>
        /// <value>The required level.</value>
        public int RequiredLevel { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the number of different runes needed to cast this <see cref="SpellEntity"/>.
        /// </summary>
        /// <value>The rune count.</value>
        public int RuneCount { get; set; }

        /// <summary>
        /// Gets or sets the required runes identifiers.
        /// </summary>
        /// <value>The required runes identifiers.</value>
        public int[] RequiredRunesIds { get; set; }

        /// <summary>
        /// Gets or sets the required runes counts.
        /// </summary>
        /// <value>The required runes counts.</value>
        public int[] RequiredRunesCounts { get; set; }

        /// <summary>
        /// Gets or sets the amount of experience gained by using this <see cref="SpellEntity"/>.
        /// </summary>
        /// <value>The experience gain.</value>
        public int ExperienceGain { get; set; }
    }
}
