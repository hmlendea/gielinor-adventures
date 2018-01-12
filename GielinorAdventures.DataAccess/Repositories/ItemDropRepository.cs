using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// ItemDrop repository implementation.
    /// </summary>
    public class ItemDropRepository : XmlRepository<ItemDropEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDropRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ItemDropRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified itemDrop.
        /// </summary>
        /// <param name="itemDropEntity">ItemDrop.</param>
        public override void Update(ItemDropEntity itemDropEntity)
        {
            LoadEntitiesIfNeeded();

            ItemDropEntity itemDropEntityToUpdate = Entities.FirstOrDefault(x => x.Id == itemDropEntity.Id);

            if (itemDropEntityToUpdate == null)
            {
                throw new EntityNotFoundException(itemDropEntity.Id, nameof(ItemDropEntity));
            }

            itemDropEntityToUpdate.ItemId = itemDropEntity.ItemId;
            itemDropEntityToUpdate.Amount = itemDropEntity.Amount;
            itemDropEntityToUpdate.Weight = itemDropEntity.Weight;

            XmlFile.SaveEntities(Entities);
        }
    }
}
