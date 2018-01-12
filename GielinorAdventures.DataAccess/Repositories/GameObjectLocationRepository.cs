using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// gameObjectLocation repository implementation.
    /// </summary>
    public class GameObjectLocationRepository : XmlRepository<GameObjectLocationEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectLocationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public GameObjectLocationRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified world object.
        /// </summary>
        /// <param name="gameObjectLocationEntity">World object.</param>
        public override void Update(GameObjectLocationEntity gameObjectLocationEntity)
        {
            LoadEntitiesIfNeeded();

            GameObjectLocationEntity gameObjectLocationEntityToUpdate = Entities.FirstOrDefault(x => x.Id == gameObjectLocationEntity.Id);

            if (gameObjectLocationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(gameObjectLocationEntity.Id, nameof(GameObjectLocationEntity));
            }

            gameObjectLocationEntityToUpdate.X = gameObjectLocationEntity.X;
            gameObjectLocationEntityToUpdate.Y = gameObjectLocationEntity.Y;
            gameObjectLocationEntityToUpdate.Direction = gameObjectLocationEntity.Type;
            gameObjectLocationEntityToUpdate.Type = gameObjectLocationEntity.Type;

            XmlFile.SaveEntities(Entities);
        }
    }
}
