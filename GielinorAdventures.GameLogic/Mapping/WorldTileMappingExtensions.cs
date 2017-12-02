using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// World geographic layer mapping extensions for converting between entities and domain models.
    /// </summary>
    static class WorldTileMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="worldTileEntity">World geographic layer entity.</param>
        internal static WorldTile ToDomainModel(this WorldTileEntity worldTileEntity)
        {
            WorldTile worldTile = new WorldTile
            {
                SpriteSheetFrame = worldTileEntity.SpriteSheetFrame,
                ObjectId = worldTileEntity.ObjectId
            };

            return worldTile;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="worldTile">World geographic layer.</param>
        internal static WorldTileEntity ToEntity(this WorldTile worldTile)
        {
            WorldTileEntity worldTileEntity = new WorldTileEntity
            {
                SpriteSheetFrame = worldTile.SpriteSheetFrame,
                ObjectId = worldTile.ObjectId
            };

            return worldTileEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="worldTileEntities">World geographic layer entities.</param>
        internal static IEnumerable<WorldTile> ToDomainModels(this IEnumerable<WorldTileEntity> worldTileEntities)
        {
            IEnumerable<WorldTile> worldTiles = worldTileEntities.Select(worldTileEntity => worldTileEntity.ToDomainModel());

            return worldTiles;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="worldTiles">World geographic layer.</param>
        internal static IEnumerable<WorldTileEntity> ToEntities(this IEnumerable<WorldTile> worldTiles)
        {
            IEnumerable<WorldTileEntity> worldTileEntities = worldTiles.Select(worldTile => worldTile.ToEntity());

            return worldTileEntities;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="worldTileEntities">World geographic layer entities.</param>
        internal static WorldTile[,] ToDomainModels(this WorldTileEntity[,] worldTileEntities)
        {
            int cols = worldTileEntities.GetLength(0);
            int rows = worldTileEntities.GetLength(1);

            WorldTile[,] worldTiles = new WorldTile[cols, rows];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    worldTiles[x, y] = worldTileEntities[x, y].ToDomainModel();
                }
            }

            return worldTiles;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="worldTiles">World geographic layer.</param>
        internal static WorldTileEntity[,] ToEntities(this WorldTile[,] worldTiles)
        {
            int cols = worldTiles.GetLength(0);
            int rows = worldTiles.GetLength(1);

            WorldTileEntity[,] worldTileEntities = new WorldTileEntity[cols, rows];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    worldTileEntities[x, y] = worldTiles[x, y].ToEntity();
                }
            }

            return worldTileEntities;
        }
    }
}
