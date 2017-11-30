using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// gameObjectLocation repository implementation.
    /// </summary>
    public class GameObjectLocationRepository
    {
        readonly XmlDatabase<GameObjectLocationEntity> xmlDatabase;
        List<GameObjectLocationEntity> gameObjectLocationEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectLocationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public GameObjectLocationRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<GameObjectLocationEntity>(fileName);
            gameObjectLocationEntities = new List<GameObjectLocationEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(gameObjectLocationEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified world object.
        /// </summary>
        /// <param name="gameObjectLocationEntity">World object.</param>
        public void Add(GameObjectLocationEntity gameObjectLocationEntity)
        {
            LoadEntitiesIfNeeded();

            gameObjectLocationEntities.Add(gameObjectLocationEntity);
        }

        /// <summary>
        /// Get the world object with the specified identifier.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="id">Identifier.</param>
        public GameObjectLocationEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            GameObjectLocationEntity gameObjectLocationEntity = gameObjectLocationEntities.FirstOrDefault(x => x.Id == id);

            if (gameObjectLocationEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(GameObjectLocationEntity).Replace("Entity", ""));
            }

            return gameObjectLocationEntity;
        }

        /// <summary>
        /// Gets all the world objects.
        /// </summary>
        /// <returns>The world objects</returns>
        public IEnumerable<GameObjectLocationEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return gameObjectLocationEntities;
        }

        /// <summary>
        /// Updates the specified world object.
        /// </summary>
        /// <param name="gameObjectLocationEntity">World object.</param>
        public void Update(GameObjectLocationEntity gameObjectLocationEntity)
        {
            LoadEntitiesIfNeeded();

            GameObjectLocationEntity gameObjectLocationEntityToUpdate = gameObjectLocationEntities.FirstOrDefault(x => x.Id == gameObjectLocationEntity.Id);

            if (gameObjectLocationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(gameObjectLocationEntity.Id, nameof(GameObjectLocationEntity).Replace("Entity", ""));
            }

            gameObjectLocationEntityToUpdate.X = gameObjectLocationEntity.X;
            gameObjectLocationEntityToUpdate.Y = gameObjectLocationEntity.Y;
            gameObjectLocationEntityToUpdate.Direction = gameObjectLocationEntity.Type;
            gameObjectLocationEntityToUpdate.Type = gameObjectLocationEntity.Type;

            xmlDatabase.SaveEntities(gameObjectLocationEntities);
        }

        /// <summary>
        /// Removes the world object with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            gameObjectLocationEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(gameObjectLocationEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(GameObjectLocationEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            gameObjectLocationEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
