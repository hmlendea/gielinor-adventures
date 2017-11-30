using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// NpcLocation repository implementation.
    /// </summary>
    public class NpcLocationRepository
    {
        readonly XmlDatabase<NpcLocationEntity> xmlDatabase;
        List<NpcLocationEntity> npcLocationEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpcLocationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public NpcLocationRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<NpcLocationEntity>(fileName);
            npcLocationEntities = new List<NpcLocationEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(npcLocationEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified npcLocation.
        /// </summary>
        /// <param name="npcLocationEntity">NpcLocation.</param>
        public void Add(NpcLocationEntity npcLocationEntity)
        {
            LoadEntitiesIfNeeded();

            npcLocationEntities.Add(npcLocationEntity);
        }

        /// <summary>
        /// Get the npcLocation with the specified identifier.
        /// </summary>
        /// <returns>The npcLocation.</returns>
        /// <param name="id">Identifier.</param>
        public NpcLocationEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            NpcLocationEntity npcLocationEntity = npcLocationEntities.FirstOrDefault(x => x.Id == id);

            if (npcLocationEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(NpcLocationEntity).Replace("Entity", ""));
            }

            return npcLocationEntity;
        }

        /// <summary>
        /// Gets all the npcLocations.
        /// </summary>
        /// <returns>The npcLocations</returns>
        public IEnumerable<NpcLocationEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return npcLocationEntities;
        }

        /// <summary>
        /// Updates the specified npcLocation.
        /// </summary>
        /// <param name="npcLocationEntity">NpcLocation.</param>
        public void Update(NpcLocationEntity npcLocationEntity)
        {
            LoadEntitiesIfNeeded();

            NpcLocationEntity npcLocationEntityToUpdate = npcLocationEntities.FirstOrDefault(x => x.Id == npcLocationEntity.Id);

            if (npcLocationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(npcLocationEntity.Id, nameof(NpcLocationEntity).Replace("Entity", ""));
            }

            npcLocationEntityToUpdate.InitialX = npcLocationEntity.InitialX;
            npcLocationEntityToUpdate.InitialY = npcLocationEntity.InitialY;
            npcLocationEntityToUpdate.MinX = npcLocationEntity.MinX;
            npcLocationEntityToUpdate.MinY = npcLocationEntity.MinY;
            npcLocationEntityToUpdate.MaxX = npcLocationEntity.MaxX;
            npcLocationEntityToUpdate.MaxY = npcLocationEntity.MaxY;

            xmlDatabase.SaveEntities(npcLocationEntities);
        }

        /// <summary>
        /// Removes the npcLocation with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            npcLocationEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(npcLocationEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(NpcLocationEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            npcLocationEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
