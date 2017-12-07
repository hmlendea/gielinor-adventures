using System;
using System.Linq;

using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public class InventoryManager : IInventoryManager
    {
        public static int MaximumInventorySize = 28;

        readonly Player player;
        readonly IEntityManager entityManager;

        public InventoryManager(
            Player player,
            IEntityManager entityManager)
        {
            this.player = player;
            this.entityManager = entityManager;
        }

        public bool IsItemEquipped(string itemId)
        {
            InventoryItem inventoryItem = player.Inventory
                .Take(MaximumInventorySize)
                .FirstOrDefault(x => x.Id == itemId);

            if (inventoryItem == null)
            {
                return false;
            }

            return inventoryItem.IsEquipped;
        }

        public void BankItem(string itemId, int itemSlot, int quantity)
        {
            throw new NotImplementedException();
        }

        public InventoryItem GetBankItem(int slot)
        {
            if (player.Bank.Count() < slot)
            {
                return null;
            }

            return player.Bank.ToList()[slot];
        }

        public InventoryItem GetInventoryItem(int slot)
        {
            if (player.Inventory.Count() < slot)
            {
                return null;
            }

            return player.Inventory.ToList()[slot];
        }

        public void SetBankItemQuantity(int slot, int quantity)
        {
            player.Bank.ToList()[slot].Quantity = quantity;
        }

        public void SetInventoryItemQuantity(int slot, int quantity)
        {
            player.Inventory.ToList()[slot].Quantity = quantity;
        }

        public void SetItemEquippedStatus(int slot, bool isEquipped)
        {
            player.Inventory.ToList()[slot].IsEquipped = isEquipped;
        }

        public void RemoveItem(int slot)
        {
            InventoryItem inventoryItem = player.Inventory.ToList()[slot];

            inventoryItem.Id = null;
            inventoryItem.Quantity = 0;
            inventoryItem.IsEquipped = false;
        }

        public int GetItemTotalCount(string itemId)
        {
            return player.Inventory
                .Where(x => x.Id == itemId)
                .Sum(x => x.Quantity);
        }
    }
}
