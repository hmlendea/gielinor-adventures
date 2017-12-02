using System.Collections.Generic;

using GielinorAdventures.Models;

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
        /// Gets the map markers.
        /// </summary>
        /// <returns>The map markers.</returns>
        IEnumerable<MapMarker> GetMapMarkers();

        /// <summary>
        /// Gets the terrain at the specified location.
        /// </summary>
        /// <returns>The terrain.</returns>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        Terrain GetTerrain(int x, int y);

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
        /// Gets the world object at the specified location.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        WorldObject GetWorldObject(int x, int y);
    }
}
