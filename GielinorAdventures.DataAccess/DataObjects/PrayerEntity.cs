using NuciXNA.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.DataObjects
{
    /// <summary>
    /// Prayer entity.
    /// </summary>
    public class PrayerEntity : EntityBase
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
        /// Gets or sets the required level to use this <see cref="PrayerEntity"/>.
        /// </summary>
        /// <value>The required level.</value>
        public int RequiredLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how fast this <see cref="PrayerEntity"/> drains.
        /// </summary>
        /// <value>The drain rate.</value>
        public int DrainRate { get; set; }
    }
}
