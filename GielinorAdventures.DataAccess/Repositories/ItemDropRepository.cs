using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// ItemDrop repository implementation.
    /// </summary>
    public class ItemDropRepository
    {
        readonly XmlDatabase<ItemDropEntity> xmlDatabase;
        List<ItemDropEntity> itemDropEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDropRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ItemDropRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<ItemDropEntity>(fileName);
            itemDropEntities = new List<ItemDropEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(itemDropEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified itemDrop.
        /// </summary>
        /// <param name="itemDropEntity">ItemDrop.</param>
        public void Add(ItemDropEntity itemDropEntity)
        {
            LoadEntitiesIfNeeded();

            itemDropEntities.Add(itemDropEntity);
        }

        /// <summary>
        /// Get the itemDrop with the specified identifier.
        /// </summary>
        /// <returns>The itemDrop.</returns>
        /// <param name="id">Identifier.</param>
        public ItemDropEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            ItemDropEntity itemDropEntity = itemDropEntities.FirstOrDefault(x => x.Id == id);

            if (itemDropEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(ItemDropEntity).Replace("Entity", ""));
            }

            return itemDropEntity;
        }

        /// <summary>
        /// Gets all the itemDrops.
        /// </summary>
        /// <returns>The itemDrops</returns>
        public IEnumerable<ItemDropEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return itemDropEntities;
        }

        /// <summary>
        /// Updates the specified itemDrop.
        /// </summary>
        /// <param name="itemDropEntity">ItemDrop.</param>
        public void Update(ItemDropEntity itemDropEntity)
        {
            LoadEntitiesIfNeeded();

            ItemDropEntity itemDropEntityToUpdate = itemDropEntities.FirstOrDefault(x => x.Id == itemDropEntity.Id);

            if (itemDropEntityToUpdate == null)
            {
                throw new EntityNotFoundException(itemDropEntity.Id, nameof(ItemDropEntity).Replace("Entity", ""));
            }

            itemDropEntityToUpdate.ItemId = itemDropEntity.ItemId;
            itemDropEntityToUpdate.Amount = itemDropEntity.Amount;
            itemDropEntityToUpdate.Weight = itemDropEntity.Weight;

            xmlDatabase.SaveEntities(itemDropEntities);
        }

        /// <summary>
        /// Removes the itemDrop with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            itemDropEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(itemDropEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(ItemDropEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            itemDropEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
