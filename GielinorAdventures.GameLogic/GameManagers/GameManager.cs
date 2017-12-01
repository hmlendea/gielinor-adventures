using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public class GameManager : IGameManager
    {
        readonly CombatManager combatManager;
        readonly EntityManager entityManager;
        readonly InventoryManager inventoryManager;
        readonly QuestManager questManager;

        World currentWorld;
        Player currentPlayer;

        public GameManager()
        {
            entityManager = new EntityManager();
            inventoryManager = new InventoryManager(entityManager);
            combatManager = new CombatManager(inventoryManager);
            questManager = new QuestManager();
        }

        public void LoadContent()
        {
            entityManager.LoadContent();

            currentPlayer = entityManager.GetPlayer();
            currentWorld = entityManager.GetWorld(currentPlayer.World);
        }

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
