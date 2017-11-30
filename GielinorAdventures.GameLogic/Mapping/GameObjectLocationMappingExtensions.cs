using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;
using GielinorAdventures.Models.Enumerations;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Model mapping extensions for converting between entities and domain models.
    /// </summary>
    static class GameObjectLocationMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="gameObjectLocationEntity">Model entity.</param>
        internal static GameObjectLocation ToDomainModel(this GameObjectLocationEntity gameObjectLocationEntity)
        {
            GameObjectLocation gameObjectLocation = new GameObjectLocation
            {
                Location = new Point2D(gameObjectLocationEntity.X, gameObjectLocationEntity.Y),
                Direction = gameObjectLocationEntity.Direction,
                Type = (GameObjectType)gameObjectLocationEntity.Type
            };

            return gameObjectLocation;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="gameObjectLocation">Model.</param>
        internal static GameObjectLocationEntity ToEntity(this GameObjectLocation gameObjectLocation)
        {
            GameObjectLocationEntity gameObjectLocationEntity = new GameObjectLocationEntity
            {
                X = gameObjectLocation.Location.X,
                Y = gameObjectLocation.Location.Y,
                Direction = gameObjectLocation.Direction,
                Type = (int)gameObjectLocation.Type
            };

            return gameObjectLocationEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="gameObjectLocationEntities">Model entities.</param>
        internal static IEnumerable<GameObjectLocation> ToDomainModels(this IEnumerable<GameObjectLocationEntity> gameObjectLocationEntities)
        {
            IEnumerable<GameObjectLocation> gameObjectLocations = gameObjectLocationEntities.Select(modelEntity => modelEntity.ToDomainModel());

            return gameObjectLocations;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="gameObjectLocations">Models.</param>
        internal static IEnumerable<GameObjectLocationEntity> ToEntities(this IEnumerable<GameObjectLocation> gameObjectLocations)
        {
            IEnumerable<GameObjectLocationEntity> gameObjectLocationEntities = gameObjectLocations.Select(model => model.ToEntity());

            return gameObjectLocationEntities;
        }
    }
}
