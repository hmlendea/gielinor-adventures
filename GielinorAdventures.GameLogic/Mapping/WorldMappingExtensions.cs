using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    // TODO: Remove the public modifier!!!
    /// <summary>
    /// World mapping extensions for converting between entities and domain models.
    /// </summary>
    public static class WorldMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="worldEntity">World entity.</param>
        internal static World ToDomainModel(this WorldEntity worldEntity)
        {
            World world = new World
            {
                Id = worldEntity.Id,
                Name = worldEntity.Name,
                Description = worldEntity.Description,
                Width = worldEntity.Width,
                Height = worldEntity.Height,
                //Tiles = worldEntity.Tiles.ToDomainModels(),
                Layers = worldEntity.Layers.ToDomainModels().ToList()
            };

            return world;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="world">World.</param>
        internal static WorldEntity ToEntity(this World world)
        {
            WorldEntity worldEntity = new WorldEntity
            {
                Id = world.Id,
                Name = world.Name,
                Description = world.Description,
                Width = world.Width,
                Height = world.Height,
                //Tiles = world.Tiles.ToEntities(),
                Layers = world.Layers.ToEntities().ToList()
            };

            return worldEntity;
        }

        // TODO: Turn this back to internal!!!
        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="worldEntities">World entities.</param>
        public static IEnumerable<World> ToDomainModels(this IEnumerable<WorldEntity> worldEntities)
        {
            IEnumerable<World> worlds = worldEntities.Select(worldEntity => worldEntity.ToDomainModel());

            return worlds;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="worlds">Worlds.</param>
        internal static IEnumerable<WorldEntity> ToEntities(this IEnumerable<World> worlds)
        {
            IEnumerable<WorldEntity> worldEntities = worlds.Select(world => world.ToEntity());

            return worldEntities;
        }
    }
}
