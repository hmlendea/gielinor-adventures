using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// ItemDrop mapping extensions for converting between entities and domain models.
    /// </summary>
    static class ItemDropMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="itemDropEntity">ItemDrop entity.</param>
        internal static ItemDrop ToDomainModel(this ItemDropEntity itemDropEntity)
        {
            ItemDrop itemDrop = new ItemDrop
            {
                ItemId = itemDropEntity.ItemId,
                Amount = itemDropEntity.Amount,
                Weight = itemDropEntity.Weight
            };

            return itemDrop;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="itemDrop">ItemDrop.</param>
        internal static ItemDropEntity ToEntity(this ItemDrop itemDrop)
        {
            ItemDropEntity itemDropEntity = new ItemDropEntity
            {
                ItemId = itemDrop.ItemId,
                Amount = itemDrop.Amount,
                Weight = itemDrop.Weight
            };

            return itemDropEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="itemDropEntities">ItemDrop entities.</param>
        internal static IEnumerable<ItemDrop> ToDomainModels(this IEnumerable<ItemDropEntity> itemDropEntities)
        {
            IEnumerable<ItemDrop> itemDrops = itemDropEntities?.Select(itemDropEntity => itemDropEntity.ToDomainModel());

            return itemDrops;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="itemDrops">ItemDrops.</param>
        internal static IEnumerable<ItemDropEntity> ToEntities(this IEnumerable<ItemDrop> itemDrops)
        {
            IEnumerable<ItemDropEntity> itemDropEntities = itemDrops?.Select(itemDrop => itemDrop.ToEntity());

            return itemDropEntities;
        }
    }
}
