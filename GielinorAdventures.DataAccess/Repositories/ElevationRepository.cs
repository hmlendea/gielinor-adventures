using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Elevation repository implementation.
    /// </summary>
    public class ElevationRepository
    {
        readonly XmlDatabase<ElevationEntity> xmlDatabase;
        List<ElevationEntity> elevationEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElevationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ElevationRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<ElevationEntity>(fileName);
            elevationEntities = new List<ElevationEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(elevationEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified elevation.
        /// </summary>
        /// <param name="elevationEntity">Elevation.</param>
        public void Add(ElevationEntity elevationEntity)
        {
            LoadEntitiesIfNeeded();

            elevationEntities.Add(elevationEntity);

            try
            {
                xmlDatabase.SaveEntities(elevationEntities);
            }
            catch
            {
                throw new DuplicateEntityException(elevationEntity.Id, nameof(ElevationEntity).Replace("Entity", ""));
            }
        }

        /// <summary>
        /// Get the elevation with the specified identifier.
        /// </summary>
        /// <returns>The elevation.</returns>
        /// <param name="id">Identifier.</param>
        public ElevationEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            ElevationEntity elevationEntity = elevationEntities.FirstOrDefault(x => x.Id == id);

            if (elevationEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(ElevationEntity).Replace("Entity", ""));
            }

            return elevationEntity;
        }

        /// <summary>
        /// Gets all the elevations.
        /// </summary>
        /// <returns>The elevations</returns>
        public IEnumerable<ElevationEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return elevationEntities;
        }

        /// <summary>
        /// Updates the specified elevation.
        /// </summary>
        /// <param name="elevationEntity">Elevation.</param>
        public void Update(ElevationEntity elevationEntity)
        {
            LoadEntitiesIfNeeded();

            ElevationEntity elevationEntityToUpdate = elevationEntities.FirstOrDefault(x => x.Id == elevationEntity.Id);

            if (elevationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(elevationEntity.Id, nameof(ElevationEntity).Replace("Entity", ""));
            }

            elevationEntityToUpdate.Roof = elevationEntity.Roof;
            elevationEntityToUpdate.Unknown = elevationEntity.Unknown;

            xmlDatabase.SaveEntities(elevationEntities);
        }

        /// <summary>
        /// Removes the elevation with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            elevationEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(elevationEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(ElevationEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            elevationEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
