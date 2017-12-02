using GielinorAdventures.Models;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public interface IWorldManager
    {
        /// <summary>
        /// Loads the content.
        /// </summary>
        void LoadContent();

        /// <summary>
        /// Loads the specified world.
        /// </summary>
        /// <param name="id">World identifier.</param>
        void LoadWorld(string id);

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        World GetWorld();

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        WorldObject GetWorldObject(string id);

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="location">Location.</param>
        WorldObject GetWorldObject(Point2D location);
    }
}
