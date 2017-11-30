using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Tile repository implementation.
    /// </summary>
    public class TileRepository
    {
        readonly XmlDatabase<TileEntity> xmlDatabase;
        List<TileEntity> tileEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="TileRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public TileRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<TileEntity>(fileName);
            tileEntities = new List<TileEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(tileEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified tile.
        /// </summary>
        /// <param name="tileEntity">Tile.</param>
        public void Add(TileEntity tileEntity)
        {
            LoadEntitiesIfNeeded();

            tileEntities.Add(tileEntity);
        }

        /// <summary>
        /// Get the tile with the specified identifier.
        /// </summary>
        /// <returns>The tile.</returns>
        /// <param name="id">Identifier.</param>
        public TileEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            TileEntity tileEntity = tileEntities.FirstOrDefault(x => x.Id == id);

            if (tileEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(TileEntity).Replace("Entity", ""));
            }

            return tileEntity;
        }

        /// <summary>
        /// Gets all the tiles.
        /// </summary>
        /// <returns>The tiles</returns>
        public IEnumerable<TileEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return tileEntities;
        }

        /// <summary>
        /// Updates the specified tile.
        /// </summary>
        /// <param name="tileEntity">Tile.</param>
        public void Update(TileEntity tileEntity)
        {
            LoadEntitiesIfNeeded();

            TileEntity tileEntityToUpdate = tileEntities.FirstOrDefault(x => x.Id == tileEntity.Id);

            if (tileEntityToUpdate == null)
            {
                throw new EntityNotFoundException(tileEntity.Id, nameof(TileEntity).Replace("Entity", ""));
            }

            tileEntityToUpdate.Colour = tileEntity.Colour;
            tileEntityToUpdate.Unknown = tileEntity.Unknown;
            tileEntityToUpdate.Type = tileEntity.Type;

            xmlDatabase.SaveEntities(tileEntities);
        }

        /// <summary>
        /// Removes the tile with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            tileEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(tileEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(TileEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            tileEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
