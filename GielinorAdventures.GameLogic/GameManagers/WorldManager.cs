using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Repositories;
using GielinorAdventures.GameLogic.Mapping;
using GielinorAdventures.Models;
using GielinorAdventures.Primitives;
using GielinorAdventures.Settings;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public class WorldManager : IWorldManager
    {
        World currentWorld;
        List<WorldObject> worldObjects;

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            string worldObjectPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "world_objects.xml");

            WorldObjectRepository worldObjectRepository = new WorldObjectRepository(worldObjectPath);

            worldObjects = worldObjectRepository.GetAll().ToDomainModels().ToList();
        }

        /// <summary>
        /// Loads the specified world.
        /// </summary>
        /// <param name="id">World identifier.</param>
        public void LoadWorld(string id)
        {
            WorldRepository worldRepository = new WorldRepository(ApplicationPaths.WorldsDirectory);
            WorldEntity worldEntity = worldRepository.Get(id);

            currentWorld = worldEntity.ToDomainModel();
        }

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        public World GetWorld()
        => currentWorld;

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="id">Identifier.</param>
        public WorldObject GetWorldObject(string id)
        {
            return worldObjects.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="location">Location.</param>
        public WorldObject GetWorldObject(Point2D location)
        {
            string objectId = string.Empty;

            foreach (WorldLayer layer in currentWorld.Layers)
            {
                if (!string.IsNullOrWhiteSpace(layer.Tiles[location.X, location.Y].ObjectId))
                {
                    objectId = layer.Tiles[location.X, location.Y].ObjectId;
                }
            }

            return GetWorldObject(objectId);
        }
    }
}
