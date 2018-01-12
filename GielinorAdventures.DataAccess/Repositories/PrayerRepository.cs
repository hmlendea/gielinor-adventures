using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Prayer repository implementation.
    /// </summary>
    public class PrayerRepository : XmlRepository<PrayerEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrayerRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public PrayerRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified prayer.
        /// </summary>
        /// <param name="prayerEntity">Prayer.</param>
        public override void Update(PrayerEntity prayerEntity)
        {
            LoadEntitiesIfNeeded();

            PrayerEntity prayerEntityToUpdate = Entities.FirstOrDefault(x => x.Id == prayerEntity.Id);

            if (prayerEntityToUpdate == null)
            {
                throw new EntityNotFoundException(prayerEntity.Id, nameof(PrayerEntity));
            }

            prayerEntityToUpdate.Name = prayerEntity.Name;
            prayerEntityToUpdate.Description = prayerEntity.Description;
            prayerEntityToUpdate.RequiredLevel = prayerEntity.RequiredLevel;
            prayerEntityToUpdate.DrainRate = prayerEntity.DrainRate;

            XmlFile.SaveEntities(Entities);
        }
    }
}
