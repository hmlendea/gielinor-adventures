using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// worldObject repository implementation.
    /// </summary>
    public class WorldObjectRepository : XmlRepository<WorldObjectEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldObjectRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public WorldObjectRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified world object.
        /// </summary>
        /// <param name="worldObjectEntity">World object.</param>
        public override void Update(WorldObjectEntity worldObjectEntity)
        {
            LoadEntitiesIfNeeded();

            WorldObjectEntity worldObjectEntityToUpdate = Entities.FirstOrDefault(x => x.Id == worldObjectEntity.Id);

            if (worldObjectEntityToUpdate == null)
            {
                throw new EntityNotFoundException(worldObjectEntity.Id, nameof(WorldObjectEntity));
            }

            worldObjectEntityToUpdate.Name = worldObjectEntity.Name;
            worldObjectEntityToUpdate.Description = worldObjectEntity.Description;
            worldObjectEntityToUpdate.Command1 = worldObjectEntity.Command1;
            worldObjectEntityToUpdate.Command2 = worldObjectEntity.Command2;
            worldObjectEntityToUpdate.Type = worldObjectEntity.Type;

            XmlFile.SaveEntities(Entities);
        }
    }
}
