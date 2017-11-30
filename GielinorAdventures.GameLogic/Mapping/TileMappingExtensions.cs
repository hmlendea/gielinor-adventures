using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Tile mapping extensions for converting between entities and domain models.
    /// </summary>
    static class TileMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="tileEntity">Tile entity.</param>
        internal static Tile ToDomainModel(this TileEntity tileEntity)
        {
            Tile tile = new Tile
            {
                Colour = tileEntity.Colour,
                Unknown = tileEntity.Unknown,
                Type = tileEntity.Type
            };

            return tile;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="tile">Tile.</param>
        internal static TileEntity ToEntity(this Tile tile)
        {
            TileEntity tileEntity = new TileEntity
            {
                Colour = tile.Colour,
                Unknown = tile.Unknown,
                Type = tile.Type
            };

            return tileEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="tileEntities">Tile entities.</param>
        internal static IEnumerable<Tile> ToDomainModels(this IEnumerable<TileEntity> tileEntities)
        {
            IEnumerable<Tile> tiles = tileEntities.Select(tileEntity => tileEntity.ToDomainModel());

            return tiles;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="tiles">Tiles.</param>
        internal static IEnumerable<TileEntity> ToEntities(this IEnumerable<Tile> tiles)
        {
            IEnumerable<TileEntity> tileEntities = tiles.Select(tile => tile.ToEntity());

            return tileEntities;
        }
    }
}
