using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public interface IInventoryManager
    {
        bool IsItemEquipped(string itemId);

        void BankItem(string itemId, int itemSlot, int quantity);

        InventoryItem GetBankItem(int slot);

        InventoryItem GetInventoryItem(int slot);

        void SetBankItemQuantity(int slot, int quantity);

        void SetInventoryItemQuantity(int slot, int quantity);

        void SetItemEquippedStatus(int slot, bool isEquipped);

        void RemoveItem(int slot);

        int GetItemTotalCount(string itemId);
    }
}
