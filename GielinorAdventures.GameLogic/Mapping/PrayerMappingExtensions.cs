using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Prayer mapping extensions for converting between entities and domain models.
    /// </summary>
    static class PrayerMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="prayerEntity">Prayer entity.</param>
        internal static Prayer ToDomainModel(this PrayerEntity prayerEntity)
        {
            Prayer prayer = new Prayer
            {
                Id = prayerEntity.Id,
                Name = prayerEntity.Name,
                Description = prayerEntity.Description,
                RequiredLevel = prayerEntity.RequiredLevel,
                DrainRate = prayerEntity.DrainRate
            };

            return prayer;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="prayer">Prayer.</param>
        internal static PrayerEntity ToEntity(this Prayer prayer)
        {
            PrayerEntity prayerEntity = new PrayerEntity
            {
                Id = prayer.Id,
                Name = prayer.Name,
                Description = prayer.Description,
                RequiredLevel = prayer.RequiredLevel,
                DrainRate = prayer.DrainRate
            };

            return prayerEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="prayerEntities">Prayer entities.</param>
        internal static IEnumerable<Prayer> ToDomainModels(this IEnumerable<PrayerEntity> prayerEntities)
        {
            IEnumerable<Prayer> prayers = prayerEntities.Select(prayerEntity => prayerEntity.ToDomainModel());

            return prayers;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="prayers">Prayers.</param>
        internal static IEnumerable<PrayerEntity> ToEntities(this IEnumerable<Prayer> prayers)
        {
            IEnumerable<PrayerEntity> prayerEntities = prayers.Select(prayer => prayer.ToEntity());

            return prayerEntities;
        }
    }
}
