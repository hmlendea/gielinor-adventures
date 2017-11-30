using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Item repository implementation.
    /// </summary>
    public class ItemRepository
    {
        readonly XmlDatabase<ItemEntity> xmlDatabase;
        List<ItemEntity> itemEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ItemRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<ItemEntity>(fileName);
            itemEntities = new List<ItemEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(itemEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="itemEntity">Item.</param>
        public void Add(ItemEntity itemEntity)
        {
            LoadEntitiesIfNeeded();

            itemEntities.Add(itemEntity);
        }

        /// <summary>
        /// Get the item with the specified identifier.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="id">Identifier.</param>
        public ItemEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            ItemEntity itemEntity = itemEntities.FirstOrDefault(x => x.Id == id);

            if (itemEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(ItemEntity).Replace("Entity", ""));
            }

            return itemEntity;
        }

        /// <summary>
        /// Gets all the items.
        /// </summary>
        /// <returns>The items</returns>
        public IEnumerable<ItemEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return itemEntities;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="itemEntity">Item.</param>
        public void Update(ItemEntity itemEntity)
        {
            LoadEntitiesIfNeeded();

            ItemEntity itemEntityToUpdate = itemEntities.FirstOrDefault(x => x.Id == itemEntity.Id);

            if (itemEntityToUpdate == null)
            {
                throw new EntityNotFoundException(itemEntity.Id, nameof(ItemEntity).Replace("Entity", ""));
            }

            itemEntityToUpdate.Description = itemEntity.Description;
            itemEntityToUpdate.Command = itemEntity.Command;
            itemEntityToUpdate.BasePrice = itemEntity.BasePrice;
            itemEntityToUpdate.SpriteId = itemEntity.SpriteId;
            itemEntityToUpdate.InventoryPicture = itemEntity.InventoryPicture;
            itemEntityToUpdate.PictureMask = itemEntity.PictureMask;
            itemEntityToUpdate.IsEquipable = itemEntity.IsEquipable;
            itemEntityToUpdate.IsPremium = itemEntity.IsPremium;
            itemEntityToUpdate.IsSpecial = itemEntity.IsSpecial;
            itemEntityToUpdate.IsStackable = itemEntity.IsStackable;
            itemEntityToUpdate.IsUnused = itemEntity.IsUnused;

            xmlDatabase.SaveEntities(itemEntities);
        }

        /// <summary>
        /// Removes the item with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            itemEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(itemEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(ItemEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            itemEntities = xmlDatabase.LoadEntities()?.ToList();
            loadedEntities = true;
        }
    }
}
