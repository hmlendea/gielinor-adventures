using System.Collections.Generic;
using System.Linq;

using NuciXNA.Primitives;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// ItemLocation mapping extensions for converting between entities and domain models.
    /// </summary>
    static class ItemLocationMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="itemLocationEntity">ItemLocation entity.</param>
        internal static ItemLocation ToDomainModel(this ItemLocationEntity itemLocationEntity)
        {
            ItemLocation itemLocation = new ItemLocation
            {
                Coordinates = new Point2D(itemLocationEntity.X, itemLocationEntity.Y),
                Amount = itemLocationEntity.Amount,
                RespawnTime = itemLocationEntity.RespawnTime
            };

            return itemLocation;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="itemLocation">ItemLocation.</param>
        internal static ItemLocationEntity ToEntity(this ItemLocation itemLocation)
        {
            ItemLocationEntity itemLocationEntity = new ItemLocationEntity
            {
                X = itemLocation.Coordinates.X,
                Y = itemLocation.Coordinates.Y,
                Amount = itemLocation.Amount,
                RespawnTime = itemLocation.RespawnTime
            };

            return itemLocationEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="itemLocationEntities">ItemLocation entities.</param>
        internal static IEnumerable<ItemLocation> ToDomainModels(this IEnumerable<ItemLocationEntity> itemLocationEntities)
        {
            IEnumerable<ItemLocation> itemLocations = itemLocationEntities.Select(itemLocationEntity => itemLocationEntity.ToDomainModel());

            return itemLocations;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="itemLocations">ItemLocations.</param>
        internal static IEnumerable<ItemLocationEntity> ToEntities(this IEnumerable<ItemLocation> itemLocations)
        {
            IEnumerable<ItemLocationEntity> itemLocationEntities = itemLocations.Select(itemLocation => itemLocation.ToEntity());

            return itemLocationEntities;
        }
    }
}
