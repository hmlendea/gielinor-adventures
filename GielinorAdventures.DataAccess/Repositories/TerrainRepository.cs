using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Texture repository implementation.
    /// </summary>
    public class TerrainRepository
    {
        readonly XmlDatabase<TerrainEntity> xmlDatabase;
        List<TerrainEntity> terrainEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="TerrainRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public TerrainRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<TerrainEntity>(fileName);
            terrainEntities = new List<TerrainEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(terrainEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified terrain.
        /// </summary>
        /// <param name="terrainEntity">Texture.</param>
        public void Add(TerrainEntity terrainEntity)
        {
            LoadEntitiesIfNeeded();

            terrainEntities.Add(terrainEntity);
        }

        /// <summary>
        /// Get the terrain with the specified identifier.
        /// </summary>
        /// <returns>The terrain.</returns>
        /// <param name="id">Identifier.</param>
        public TerrainEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            TerrainEntity terrainEntity = terrainEntities.FirstOrDefault(x => x.Id == id);

            if (terrainEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(TerrainEntity).Replace("Entity", ""));
            }

            return terrainEntity;
        }

        /// <summary>
        /// Gets all the terrains.
        /// </summary>
        /// <returns>The terrains</returns>
        public IEnumerable<TerrainEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return terrainEntities;
        }

        /// <summary>
        /// Updates the specified terrain.
        /// </summary>
        /// <param name="terrainEntity">Texture.</param>
        public void Update(TerrainEntity terrainEntity)
        {
            LoadEntitiesIfNeeded();

            TerrainEntity terrainEntityToUpdate = terrainEntities.FirstOrDefault(x => x.Id == terrainEntity.Id);

            if (terrainEntityToUpdate == null)
            {
                throw new EntityNotFoundException(terrainEntity.Id, nameof(TerrainEntity).Replace("Entity", ""));
            }

            terrainEntityToUpdate.Name = terrainEntity.Name;
            terrainEntityToUpdate.Description = terrainEntity.Description;
            terrainEntityToUpdate.ColourHexadecimal = terrainEntity.ColourHexadecimal;

            xmlDatabase.SaveEntities(terrainEntities);
        }

        /// <summary>
        /// Removes the terrain with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            terrainEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(terrainEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(TerrainEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            terrainEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
