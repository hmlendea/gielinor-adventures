using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// InventoryItem mapping extensions for converting between entities and domain models.
    /// </summary>
    static class InventoryItemMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="inventoryItemEntity">InventoryItem entity.</param>
        internal static InventoryItem ToDomainModel(this InventoryItemEntity inventoryItemEntity)
        {
            InventoryItem inventoryItem = new InventoryItem
            {
                Id = inventoryItemEntity.Id,
                Quantity = inventoryItemEntity.Quantity
            };

            return inventoryItem;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="inventoryItem">InventoryItem.</param>
        internal static InventoryItemEntity ToEntity(this InventoryItem inventoryItem)
        {
            InventoryItemEntity inventoryItemEntity = new InventoryItemEntity
            {
                Id = inventoryItem.Id,
                Quantity = inventoryItem.Quantity
            };

            return inventoryItemEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="inventoryItemEntities">InventoryItem entities.</param>
        internal static IEnumerable<InventoryItem> ToDomainModels(this IEnumerable<InventoryItemEntity> inventoryItemEntities)
        {
            IEnumerable<InventoryItem> inventoryItems = inventoryItemEntities?.Select(inventoryItemEntity => inventoryItemEntity.ToDomainModel());

            return inventoryItems;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="inventoryItems">InventoryItems.</param>
        internal static IEnumerable<InventoryItemEntity> ToEntities(this IEnumerable<InventoryItem> inventoryItems)
        {
            IEnumerable<InventoryItemEntity> inventoryItemEntities = inventoryItems?.Select(inventoryItem => inventoryItem.ToEntity());

            return inventoryItemEntities;
        }
    }
}
