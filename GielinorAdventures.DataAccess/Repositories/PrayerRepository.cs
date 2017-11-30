using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Prayer repository implementation.
    /// </summary>
    public class PrayerRepository
    {
        readonly XmlDatabase<PrayerEntity> xmlDatabase;
        List<PrayerEntity> prayerEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrayerRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public PrayerRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<PrayerEntity>(fileName);
            prayerEntities = new List<PrayerEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(prayerEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified prayer.
        /// </summary>
        /// <param name="prayerEntity">Prayer.</param>
        public void Add(PrayerEntity prayerEntity)
        {
            LoadEntitiesIfNeeded();

            prayerEntities.Add(prayerEntity);
        }

        /// <summary>
        /// Get the prayer with the specified identifier.
        /// </summary>
        /// <returns>The prayer.</returns>
        /// <param name="id">Identifier.</param>
        public PrayerEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            PrayerEntity prayerEntity = prayerEntities.FirstOrDefault(x => x.Id == id);

            if (prayerEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(PrayerEntity).Replace("Entity", ""));
            }

            return prayerEntity;
        }

        /// <summary>
        /// Gets all the prayers.
        /// </summary>
        /// <returns>The prayers</returns>
        public IEnumerable<PrayerEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return prayerEntities;
        }

        /// <summary>
        /// Updates the specified prayer.
        /// </summary>
        /// <param name="prayerEntity">Prayer.</param>
        public void Update(PrayerEntity prayerEntity)
        {
            LoadEntitiesIfNeeded();

            PrayerEntity prayerEntityToUpdate = prayerEntities.FirstOrDefault(x => x.Id == prayerEntity.Id);

            if (prayerEntityToUpdate == null)
            {
                throw new EntityNotFoundException(prayerEntity.Id, nameof(PrayerEntity).Replace("Entity", ""));
            }

            prayerEntityToUpdate.Name = prayerEntity.Name;
            prayerEntityToUpdate.Description = prayerEntity.Description;
            prayerEntityToUpdate.RequiredLevel = prayerEntity.RequiredLevel;
            prayerEntityToUpdate.DrainRate = prayerEntity.DrainRate;

            xmlDatabase.SaveEntities(prayerEntities);
        }

        /// <summary>
        /// Removes the prayer with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            prayerEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(prayerEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(PrayerEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            prayerEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
