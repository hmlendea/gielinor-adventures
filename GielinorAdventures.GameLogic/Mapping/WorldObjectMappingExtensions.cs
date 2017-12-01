using System;
using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;
using GielinorAdventures.Models.Enumerations;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Model mapping extensions for converting between entities and domain models.
    /// </summary>
    static class WorldObjectMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="worldObjectEntity">Model entity.</param>
        internal static WorldObject ToDomainModel(this WorldObjectEntity worldObjectEntity)
        {
            WorldObject worldObject = new WorldObject
            {
                Id = worldObjectEntity.Id,
                Name = worldObjectEntity.Name,
                Description = worldObjectEntity.Description,
                Command1 = worldObjectEntity.Command1,
                Command2 = worldObjectEntity.Command2,
                Type = (WorldObjectType)Enum.Parse(typeof(WorldObjectType), worldObjectEntity.Type)
            };

            return worldObject;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="worldObject">Model.</param>
        internal static WorldObjectEntity ToEntity(this WorldObject worldObject)
        {
            WorldObjectEntity worldObjectEntity = new WorldObjectEntity
            {
                Id = worldObject.Id,
                Name = worldObject.Name,
                Description = worldObject.Description,
                Command1 = worldObject.Command1,
                Command2 = worldObject.Command2,
                Type = worldObject.Type.ToString()
            };

            return worldObjectEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="worldObjectEntities">Model entities.</param>
        internal static IEnumerable<WorldObject> ToDomainModels(this IEnumerable<WorldObjectEntity> worldObjectEntities)
        {
            IEnumerable<WorldObject> worldObjects = worldObjectEntities.Select(modelEntity => modelEntity.ToDomainModel());

            return worldObjects;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="worldObjects">Models.</param>
        internal static IEnumerable<WorldObjectEntity> ToEntities(this IEnumerable<WorldObject> worldObjects)
        {
            IEnumerable<WorldObjectEntity> worldObjectEntities = worldObjects.Select(model => model.ToEntity());

            return worldObjectEntities;
        }
    }
}
