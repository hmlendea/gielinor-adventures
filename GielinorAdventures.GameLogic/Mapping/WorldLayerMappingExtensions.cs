using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// World geographic layer mapping extensions for converting between entities and domain models.
    /// </summary>
    static class WorldLayerMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="worldLayerEntity">World geographic layer entity.</param>
        internal static WorldLayer ToDomainModel(this WorldLayerEntity worldLayerEntity)
        {
            WorldLayer worldLayer = new WorldLayer
            {
                Name = worldLayerEntity.Name,
                Tileset = worldLayerEntity.Tileset,
                Tiles = worldLayerEntity.Tiles.ToDomainModels(),
                Opacity = worldLayerEntity.Opacity,
                Visible = worldLayerEntity.Visible
            };

            return worldLayer;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="worldLayer">World geographic layer.</param>
        internal static WorldLayerEntity ToEntity(this WorldLayer worldLayer)
        {
            WorldLayerEntity worldLayerEntity = new WorldLayerEntity
            {
                Name = worldLayer.Name,
                Tileset = worldLayer.Tileset,
                Tiles = worldLayer.Tiles.ToEntities(),
                Opacity = worldLayer.Opacity,
                Visible = worldLayer.Visible
            };

            return worldLayerEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="worldLayerEntities">World geographic layer entities.</param>
        internal static IEnumerable<WorldLayer> ToDomainModels(this IEnumerable<WorldLayerEntity> worldLayerEntities)
        {
            IEnumerable<WorldLayer> worldLayers = worldLayerEntities.Select(worldTileEntity => worldTileEntity.ToDomainModel());

            return worldLayers;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="worldLayers">World geographic layer.</param>
        internal static IEnumerable<WorldLayerEntity> ToEntities(this IEnumerable<WorldLayer> worldLayers)
        {
            IEnumerable<WorldLayerEntity> worldLayerEntities = worldLayers.Select(worldTile => worldTile.ToEntity());

            return worldLayerEntities;
        }
    }
}
