using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Elevation mapping extensions for converting between entities and domain models.
    /// </summary>
    static class ElevationMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="elevationEntity">Elevation entity.</param>
        internal static Elevation ToDomainModel(this ElevationEntity elevationEntity)
        {
            Elevation elevation = new Elevation
            {
                Roof = elevationEntity.Roof,
                Unknown = elevationEntity.Unknown
            };

            return elevation;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="elevation">Elevation.</param>
        internal static ElevationEntity ToEntity(this Elevation elevation)
        {
            ElevationEntity elevationEntity = new ElevationEntity
            {
                Roof = elevation.Roof,
                Unknown = elevation.Unknown
            };

            return elevationEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="elevationEntities">Elevation entities.</param>
        internal static IEnumerable<Elevation> ToDomainModels(this IEnumerable<ElevationEntity> elevationEntities)
        {
            IEnumerable<Elevation> elevations = elevationEntities.Select(elevationEntity => elevationEntity.ToDomainModel());

            return elevations;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="elevations">Elevations.</param>
        internal static IEnumerable<ElevationEntity> ToEntities(this IEnumerable<Elevation> elevations)
        {
            IEnumerable<ElevationEntity> elevationEntities = elevations.Select(elevation => elevation.ToEntity());

            return elevationEntities;
        }
    }
}
