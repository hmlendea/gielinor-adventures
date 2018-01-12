using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// NpcLocation repository implementation.
    /// </summary>
    public class NpcLocationRepository : XmlRepository<NpcLocationEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpcLocationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public NpcLocationRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified npcLocation.
        /// </summary>
        /// <param name="npcLocationEntity">NpcLocation.</param>
        public override void Update(NpcLocationEntity npcLocationEntity)
        {
            LoadEntitiesIfNeeded();

            NpcLocationEntity npcLocationEntityToUpdate = Entities.FirstOrDefault(x => x.Id == npcLocationEntity.Id);

            if (npcLocationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(npcLocationEntity.Id, nameof(NpcLocationEntity));
            }

            npcLocationEntityToUpdate.InitialX = npcLocationEntity.InitialX;
            npcLocationEntityToUpdate.InitialY = npcLocationEntity.InitialY;
            npcLocationEntityToUpdate.MinX = npcLocationEntity.MinX;
            npcLocationEntityToUpdate.MinY = npcLocationEntity.MinY;
            npcLocationEntityToUpdate.MaxX = npcLocationEntity.MaxX;
            npcLocationEntityToUpdate.MaxY = npcLocationEntity.MaxY;

            XmlFile.SaveEntities(Entities);
        }
    }
}
