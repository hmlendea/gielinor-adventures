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

        public GameManager()
        {
            entityManager = new EntityManager();
            inventoryManager = new InventoryManager(entityManager);
            combatManager = new CombatManager(inventoryManager);
            questManager = new QuestManager();

            currentWorld = entityManager.GetWorld("gielinor");
        }

        public void LoadContent()
        {
            entityManager.LoadContent();
        }

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        public World GetWorld()
        => currentWorld;
    }
}
