using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.GameManagers
{
    /// <summary>
    /// Game manager.
    /// </summary>
    public class GameManager : IGameManager
    {
        World currentWorld;
        Player currentPlayer;

        readonly CombatManager combatManager;
        readonly EntityManager entityManager;
        readonly InventoryManager inventoryManager;
        readonly QuestManager questManager;

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
            currentWorld = entityManager.GetWorld(currentPlayer.World);

            inventoryManager = new InventoryManager(currentPlayer, entityManager);
            combatManager = new CombatManager(inventoryManager);
            questManager = new QuestManager();
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
        => currentWorld;
    }
}
