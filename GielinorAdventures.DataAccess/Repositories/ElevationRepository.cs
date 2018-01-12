using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Elevation repository implementation.
    /// </summary>
    public class ElevationRepository : XmlRepository<ElevationEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElevationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ElevationRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified elevation.
        /// </summary>
        /// <param name="elevationEntity">Elevation.</param>
        public override void Update(ElevationEntity elevationEntity)
        {
            LoadEntitiesIfNeeded();

            ElevationEntity elevationEntityToUpdate = Entities.FirstOrDefault(x => x.Id == elevationEntity.Id);

            if (elevationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(elevationEntity.Id, nameof(ElevationEntity));
            }

            elevationEntityToUpdate.Roof = elevationEntity.Roof;
            elevationEntityToUpdate.Unknown = elevationEntity.Unknown;

            XmlFile.SaveEntities(Entities);
        }
    }
}
