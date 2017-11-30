using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// WallObject repository implementation.
    /// </summary>
    public class WallObjectRepository
    {
        readonly XmlDatabase<WallObjectEntity> xmlDatabase;
        List<WallObjectEntity> wallObjectEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="WallObjectRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public WallObjectRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<WallObjectEntity>(fileName);
            wallObjectEntities = new List<WallObjectEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(wallObjectEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified wallObject.
        /// </summary>
        /// <param name="wallObjectEntity">WallObject.</param>
        public void Add(WallObjectEntity wallObjectEntity)
        {
            LoadEntitiesIfNeeded();

            wallObjectEntities.Add(wallObjectEntity);
        }

        /// <summary>
        /// Get the wallObject with the specified identifier.
        /// </summary>
        /// <returns>The wallObject.</returns>
        /// <param name="id">Identifier.</param>
        public WallObjectEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            WallObjectEntity wallObjectEntity = wallObjectEntities.FirstOrDefault(x => x.Id == id);

            if (wallObjectEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(WallObjectEntity).Replace("Entity", ""));
            }

            return wallObjectEntity;
        }

        /// <summary>
        /// Gets all the wallObjects.
        /// </summary>
        /// <returns>The wallObjects</returns>
        public IEnumerable<WallObjectEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return wallObjectEntities;
        }

        /// <summary>
        /// Updates the specified wallObject.
        /// </summary>
        /// <param name="wallObjectEntity">WallObject.</param>
        public void Update(WallObjectEntity wallObjectEntity)
        {
            LoadEntitiesIfNeeded();

            WallObjectEntity wallObjectEntityToUpdate = wallObjectEntities.FirstOrDefault(x => x.Id == wallObjectEntity.Id);

            if (wallObjectEntityToUpdate == null)
            {
                throw new EntityNotFoundException(wallObjectEntity.Id, nameof(WallObjectEntity).Replace("Entity", ""));
            }

            wallObjectEntityToUpdate.Name = wallObjectEntity.Name;
            wallObjectEntityToUpdate.Description = wallObjectEntity.Description;
            wallObjectEntityToUpdate.Command1 = wallObjectEntity.Command1;
            wallObjectEntityToUpdate.Command2 = wallObjectEntity.Command2;
            wallObjectEntityToUpdate.Type = wallObjectEntity.Type;
            wallObjectEntityToUpdate.Unknown = wallObjectEntity.Unknown;
            wallObjectEntityToUpdate.ModelHeight = wallObjectEntity.ModelHeight;
            wallObjectEntityToUpdate.ModelFaceBack = wallObjectEntity.ModelFaceBack;
            wallObjectEntityToUpdate.ModelFaceFront = wallObjectEntity.ModelFaceFront;

            xmlDatabase.SaveEntities(wallObjectEntities);
        }

        /// <summary>
        /// Removes the wallObject with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            wallObjectEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(wallObjectEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(WallObjectEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            wallObjectEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
