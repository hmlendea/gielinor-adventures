using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Item repository implementation.
    /// </summary>
    public class ItemRepository : XmlRepository<ItemEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ItemRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="itemEntity">Item.</param>
        public override void Update(ItemEntity itemEntity)
        {
            LoadEntitiesIfNeeded();

            ItemEntity itemEntityToUpdate = Entities.FirstOrDefault(x => x.Id == itemEntity.Id);

            if (itemEntityToUpdate == null)
            {
                throw new EntityNotFoundException(itemEntity.Id, nameof(ItemEntity));
            }

            itemEntityToUpdate.Description = itemEntity.Description;
            itemEntityToUpdate.Command = itemEntity.Command;
            itemEntityToUpdate.BasePrice = itemEntity.BasePrice;
            itemEntityToUpdate.SpriteId = itemEntity.SpriteId;
            itemEntityToUpdate.InventoryPicture = itemEntity.InventoryPicture;
            itemEntityToUpdate.PictureMask = itemEntity.PictureMask;
            itemEntityToUpdate.IsEquipable = itemEntity.IsEquipable;
            itemEntityToUpdate.IsPremium = itemEntity.IsPremium;
            itemEntityToUpdate.IsSpecial = itemEntity.IsSpecial;
            itemEntityToUpdate.IsStackable = itemEntity.IsStackable;
            itemEntityToUpdate.IsUnused = itemEntity.IsUnused;

            XmlFile.SaveEntities(Entities);
        }
    }
}
