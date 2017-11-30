using System.Collections.Generic;
using System.Xml.Serialization;

namespace GielinorAdventures.DataAccess.DataObjects
{
    /// <summary>
    /// World data entity.
    /// </summary>
    public class WorldEntity
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
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }

        /*
        /// <summary>
        /// Gets or sets the tiles.
        /// </summary>
        /// <value>The tiles.</value>
        [XmlIgnore]
        public WorldTileEntity[,] Tiles { get; set; }
        */

        /// <summary>
        /// Gets or sets the geographic layers.
        /// </summary>
        /// <value>The grographic layers.</value>
        [XmlIgnore]
        public IList<WorldLayerEntity> Layers { get; set; }
    }
}
