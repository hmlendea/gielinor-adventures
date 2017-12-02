using GielinorAdventures.Primitives;

namespace GielinorAdventures.GameLogic.GameManagers
{
    using GielinorAdventures.Models;

    public interface IGameManager
    {
        /// <summary>
        /// Gets the size of the inventory.
        /// </summary>
        /// <value>The size of the inventory.</value>
        int InventorySize { get; }

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <returns>The inventory item.</returns>
        /// <param name="slot">Slot.</param>
        InventoryItem GetInventoryItem(int slot);

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="id">Identifier.</param>
        Item GetItem(string id);

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns>The player.</returns>
        Player GetPlayer();

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
        /// <param name="location">Location.</param>
        WorldObject GetWorldObject(Point2D location);

        /// <summary>
        /// Moves the player to the specified location.
        /// </summary>
        /// <param name="location">Location.</param>
        void MovePlayer(Point2D location);
    }
}
