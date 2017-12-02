using GielinorAdventures.Models;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.GameLogic.GameManagers
{
    /// <summary>
    /// Game manager.
    /// </summary>
    public class GameManager : IGameManager
    {
        Player currentPlayer;

        readonly CombatManager combatManager;
        readonly EntityManager entityManager;
        readonly InventoryManager inventoryManager;
        readonly QuestManager questManager;
        readonly IWorldManager worldManager;

        /// <summary>
        /// Gets the size of the inventory.
        /// </summary>
        /// <value>The size of the inventory.</value>
        public int InventorySize => InventoryManager.MaximumInventorySize;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameManager"/> class.
        /// </summary>
        public GameManager()
        {
            entityManager = new EntityManager();
            entityManager.LoadContent();

            currentPlayer = entityManager.GetPlayer();

            inventoryManager = new InventoryManager(currentPlayer, entityManager);
            combatManager = new CombatManager(inventoryManager);
            questManager = new QuestManager();
            worldManager = new WorldManager();

            worldManager.LoadContent();
            worldManager.LoadWorld(currentPlayer.World);
        }

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <returns>The inventory item.</returns>
        /// <param name="slot">Slot.</param>
        public InventoryItem GetInventoryItem(int slot)
        => inventoryManager.GetInventoryItem(slot);

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="id">Identifier.</param>
        public Item GetItem(string id)
        => entityManager.GetItem(id);

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns>The player.</returns>
        public Player GetPlayer()
        => currentPlayer;

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        public World GetWorld()
        => worldManager.GetWorld();

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="location">Location.</param>
        public WorldObject GetWorldObject(Point2D location)
        => worldManager.GetWorldObject(location);

        /// <summary>
        /// Moves the player to the specified location.
        /// </summary>
        /// <param name="location">Location.</param>
        public void MovePlayer(Point2D location)
        {
            // TODO: Actual movement logic
            currentPlayer.Location = location;
        }
    }
}
