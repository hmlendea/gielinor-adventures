using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// worldObject repository implementation.
    /// </summary>
    public class WorldObjectRepository
    {
        readonly XmlDatabase<WorldObjectEntity> xmlDatabase;
        List<WorldObjectEntity> worldObjectEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldObjectRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public WorldObjectRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<WorldObjectEntity>(fileName);
            worldObjectEntities = new List<WorldObjectEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(worldObjectEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified world object.
        /// </summary>
        /// <param name="worldObjectEntity">World object.</param>
        public void Add(WorldObjectEntity worldObjectEntity)
        {
            LoadEntitiesIfNeeded();

            worldObjectEntities.Add(worldObjectEntity);
        }

        /// <summary>
        /// Get the world object with the specified identifier.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="id">Identifier.</param>
        public WorldObjectEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            WorldObjectEntity worldObjectEntity = worldObjectEntities.FirstOrDefault(x => x.Id == id);

            if (worldObjectEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(WorldObjectEntity).Replace("Entity", ""));
            }

            return worldObjectEntity;
        }

        /// <summary>
        /// Gets all the world objects.
        /// </summary>
        /// <returns>The world objects</returns>
        public IEnumerable<WorldObjectEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return worldObjectEntities;
        }

        /// <summary>
        /// Updates the specified world object.
        /// </summary>
        /// <param name="worldObjectEntity">World object.</param>
        public void Update(WorldObjectEntity worldObjectEntity)
        {
            LoadEntitiesIfNeeded();

            WorldObjectEntity worldObjectEntityToUpdate = worldObjectEntities.FirstOrDefault(x => x.Id == worldObjectEntity.Id);

            if (worldObjectEntityToUpdate == null)
            {
                throw new EntityNotFoundException(worldObjectEntity.Id, nameof(WorldObjectEntity).Replace("Entity", ""));
            }

            worldObjectEntityToUpdate.Name = worldObjectEntity.Name;
            worldObjectEntityToUpdate.Description = worldObjectEntity.Description;
            worldObjectEntityToUpdate.Command1 = worldObjectEntity.Command1;
            worldObjectEntityToUpdate.Command2 = worldObjectEntity.Command2;
            worldObjectEntityToUpdate.Type = worldObjectEntity.Type;

            xmlDatabase.SaveEntities(worldObjectEntities);
        }

        /// <summary>
        /// Removes the world object with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            worldObjectEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(worldObjectEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(WorldObjectEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            worldObjectEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
