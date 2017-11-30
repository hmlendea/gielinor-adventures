using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Texture repository implementation.
    /// </summary>
    public class GameTextureRepository
    {
        readonly XmlDatabase<GameTextureEntity> xmlDatabase;
        List<GameTextureEntity> textureEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameTextureRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public GameTextureRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<GameTextureEntity>(fileName);
            textureEntities = new List<GameTextureEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(textureEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified texture.
        /// </summary>
        /// <param name="textureEntity">Texture.</param>
        public void Add(GameTextureEntity textureEntity)
        {
            LoadEntitiesIfNeeded();

            textureEntities.Add(textureEntity);
        }

        /// <summary>
        /// Get the texture with the specified identifier.
        /// </summary>
        /// <returns>The texture.</returns>
        /// <param name="id">Identifier.</param>
        public GameTextureEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            GameTextureEntity textureEntity = textureEntities.FirstOrDefault(x => x.Id == id);

            if (textureEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(GameTextureEntity).Replace("Entity", ""));
            }

            return textureEntity;
        }

        /// <summary>
        /// Gets all the textures.
        /// </summary>
        /// <returns>The textures</returns>
        public IEnumerable<GameTextureEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return textureEntities;
        }

        /// <summary>
        /// Updates the specified texture.
        /// </summary>
        /// <param name="textureEntity">Texture.</param>
        public void Update(GameTextureEntity textureEntity)
        {
            LoadEntitiesIfNeeded();

            GameTextureEntity textureEntityToUpdate = textureEntities.FirstOrDefault(x => x.Id == textureEntity.Id);

            if (textureEntityToUpdate == null)
            {
                throw new EntityNotFoundException(textureEntity.Id, nameof(GameTextureEntity).Replace("Entity", ""));
            }

            textureEntityToUpdate.Name = textureEntity.Name;
            textureEntityToUpdate.SubName = textureEntity.SubName;

            xmlDatabase.SaveEntities(textureEntities);
        }

        /// <summary>
        /// Removes the texture with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            textureEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(textureEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(GameTextureEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            textureEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
