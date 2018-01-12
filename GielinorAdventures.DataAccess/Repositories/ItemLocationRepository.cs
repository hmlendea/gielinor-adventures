using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// ItemLocation repository implementation.
    /// </summary>
    public class ItemLocationRepository : XmlRepository<ItemLocationEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemLocationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ItemLocationRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified itemLocation.
        /// </summary>
        /// <param name="itemLocationEntity">ItemLocation.</param>
        public override void Update(ItemLocationEntity itemLocationEntity)
        {
            LoadEntitiesIfNeeded();

            ItemLocationEntity itemLocationEntityToUpdate = Entities.FirstOrDefault(x => x.Id == itemLocationEntity.Id);

            if (itemLocationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(itemLocationEntity.Id, nameof(ItemLocationEntity));
            }

            itemLocationEntityToUpdate.X = itemLocationEntity.X;
            itemLocationEntityToUpdate.Y = itemLocationEntity.Y;
            itemLocationEntityToUpdate.Amount = itemLocationEntity.Amount;
            itemLocationEntityToUpdate.RespawnTime = itemLocationEntity.RespawnTime;

            XmlFile.SaveEntities(Entities);
        }
    }
}
