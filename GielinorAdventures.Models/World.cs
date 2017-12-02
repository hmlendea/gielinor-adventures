using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace GielinorAdventures.Models
{
    /// <summary>
    /// World domain model.
    /// </summary>
    public class World : IEquatable<World>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [StringLength(40, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 3)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(20, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [StringLength(300, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 3)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the tiles.
        /// </summary>
        /// <value>The tiles.</value>
        [XmlIgnore]
        public WorldTile[,] Tiles { get; set; }

        /// <summary>
        /// Gets or sets the geographic layers.
        /// </summary>
        /// <value>The grographic layers.</value>
        [XmlIgnore]
        public IList<WorldLayer> Layers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
        {
            Layers = new List<WorldLayer>();
        }

        /// <summary>
        /// Determines whether the specified <see cref="World"/> is equal to the current <see cref="World"/>.
        /// </summary>
        /// <param name="other">The <see cref="World"/> to compare with the current <see cref="World"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="World"/> is equal to the current
        /// <see cref="World"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(World other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Id, other.Id) &&
                   string.Equals(Name, other.Name) &&
                   string.Equals(Description, other.Description) &&
                   Equals(Width, other.Width) &&
                   Equals(Height, other.Height) &&
                   Equals(Tiles, other.Tiles) &&
                   Equals(Layers, other.Layers);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="World"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="World"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="World"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((World)obj);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="World"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^
                       (Name != null ? Name.GetHashCode() : 0) ^
                       (Description != null ? Description.GetHashCode() : 0) ^
                       Width.GetHashCode() ^
                       Height.GetHashCode() ^
                       (Tiles != null ? Tiles.GetHashCode() : 0) ^
                       (Layers != null ? Layers.GetHashCode() : 0);
            }
        }
    }
}
