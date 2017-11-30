using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// NpcLocation mapping extensions for converting between entities and domain models.
    /// </summary>
    static class NpcLocationMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="npcLocationEntity">NpcLocation entity.</param>
        internal static NpcLocation ToDomainModel(this NpcLocationEntity npcLocationEntity)
        {
            NpcLocation npcLocation = new NpcLocation
            {
                InitialCoordinates = new Point2D(npcLocationEntity.InitialX, npcLocationEntity.InitialY),
                MinimumCoordinates = new Point2D(npcLocationEntity.MinX, npcLocationEntity.MinY),
                MaximumCoordinates = new Point2D(npcLocationEntity.MaxX, npcLocationEntity.MaxY)
            };

            return npcLocation;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="npcLocation">NpcLocation.</param>
        internal static NpcLocationEntity ToEntity(this NpcLocation npcLocation)
        {
            NpcLocationEntity npcLocationEntity = new NpcLocationEntity
            {
                InitialX = npcLocation.InitialCoordinates.X,
                InitialY = npcLocation.InitialCoordinates.Y,
                MinX = npcLocation.MinimumCoordinates.X,
                MinY = npcLocation.MinimumCoordinates.Y,
                MaxX = npcLocation.MaximumCoordinates.X,
                MaxY = npcLocation.MaximumCoordinates.Y
            };

            return npcLocationEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="npcLocationEntities">NpcLocation entities.</param>
        internal static IEnumerable<NpcLocation> ToDomainModels(this IEnumerable<NpcLocationEntity> npcLocationEntities)
        {
            IEnumerable<NpcLocation> npcLocations = npcLocationEntities.Select(npcLocationEntity => npcLocationEntity.ToDomainModel());

            return npcLocations;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="npcLocations">NpcLocations.</param>
        internal static IEnumerable<NpcLocationEntity> ToEntities(this IEnumerable<NpcLocation> npcLocations)
        {
            IEnumerable<NpcLocationEntity> npcLocationEntities = npcLocations.Select(npcLocation => npcLocation.ToEntity());

            return npcLocationEntities;
        }
    }
}
