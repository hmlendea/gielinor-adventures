namespace GielinorAdventures.GameLogic.GameManagers
{
    public class CombatManager
    {
        readonly InventoryManager inventoryManager;

        public CombatManager(InventoryManager inventoryManager)
        {
            this.inventoryManager = inventoryManager;
        }

        public bool HasRequiredRunes(int itemId, int count)
        {
            /*
            if (itemId == 31 && (inventoryManager.IsItemEquipped(197) || inventoryManager.IsItemEquipped(615) || inventoryManager.IsItemEquipped(682)))
            {
                return true;
            }

            if (itemId == 32 && (inventoryManager.IsItemEquipped(102) || inventoryManager.IsItemEquipped(616) || inventoryManager.IsItemEquipped(683)))
            {
                return true;
            }

            if (itemId == 33 && (inventoryManager.IsItemEquipped(101) || inventoryManager.IsItemEquipped(617) || inventoryManager.IsItemEquipped(684)))
            {
                return true;
            }

            if (itemId == 34 && (inventoryManager.IsItemEquipped(103) || inventoryManager.IsItemEquipped(618) || inventoryManager.IsItemEquipped(685)))
            {
                return true;
            }

            return inventoryManager.GetItemTotalCount(itemId) >= count;
            */

            return false;
        }
    }
}
