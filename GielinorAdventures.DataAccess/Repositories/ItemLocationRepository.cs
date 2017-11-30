using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// ItemLocation repository implementation.
    /// </summary>
    public class ItemLocationRepository
    {
        readonly XmlDatabase<ItemLocationEntity> xmlDatabase;
        List<ItemLocationEntity> itemLocationEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemLocationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ItemLocationRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<ItemLocationEntity>(fileName);
            itemLocationEntities = new List<ItemLocationEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(itemLocationEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified itemLocation.
        /// </summary>
        /// <param name="itemLocationEntity">ItemLocation.</param>
        public void Add(ItemLocationEntity itemLocationEntity)
        {
            LoadEntitiesIfNeeded();

            itemLocationEntities.Add(itemLocationEntity);
        }

        /// <summary>
        /// Get the itemLocation with the specified identifier.
        /// </summary>
        /// <returns>The itemLocation.</returns>
        /// <param name="id">Identifier.</param>
        public ItemLocationEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            ItemLocationEntity itemLocationEntity = itemLocationEntities.FirstOrDefault(x => x.Id == id);

            if (itemLocationEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(ItemLocationEntity).Replace("Entity", ""));
            }

            return itemLocationEntity;
        }

        /// <summary>
        /// Gets all the itemLocations.
        /// </summary>
        /// <returns>The itemLocations</returns>
        public IEnumerable<ItemLocationEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return itemLocationEntities;
        }

        /// <summary>
        /// Updates the specified itemLocation.
        /// </summary>
        /// <param name="itemLocationEntity">ItemLocation.</param>
        public void Update(ItemLocationEntity itemLocationEntity)
        {
            LoadEntitiesIfNeeded();

            ItemLocationEntity itemLocationEntityToUpdate = itemLocationEntities.FirstOrDefault(x => x.Id == itemLocationEntity.Id);

            if (itemLocationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(itemLocationEntity.Id, nameof(ItemLocationEntity).Replace("Entity", ""));
            }

            itemLocationEntityToUpdate.X = itemLocationEntity.X;
            itemLocationEntityToUpdate.Y = itemLocationEntity.Y;
            itemLocationEntityToUpdate.Amount = itemLocationEntity.Amount;
            itemLocationEntityToUpdate.RespawnTime = itemLocationEntity.RespawnTime;

            xmlDatabase.SaveEntities(itemLocationEntities);
        }

        /// <summary>
        /// Removes the itemLocation with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            itemLocationEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(itemLocationEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(ItemLocationEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            itemLocationEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
