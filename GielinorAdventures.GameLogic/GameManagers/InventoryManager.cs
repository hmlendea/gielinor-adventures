using System;

using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public class InventoryManager
    {
        public static int MaximumInventorySize = 30;
        public static int MaximumBankSize = 48;
        
        public int InventoryItemsCount { get; set; }
        public int BankItemsCount { get; set; }
        public int ServerBankItemsCount { get; set; }

        InventoryItem[] inventoryItems;
        InventoryItem[] bankItems;
        InventoryItem[] serverBankItems;

        readonly EntityManager entityManager;

        public InventoryManager(EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        public void LoadContent()
        {
            inventoryItems = new InventoryItem[35];
            bankItems = new InventoryItem[256];
            serverBankItems = new InventoryItem[256];

            for (int i = 0; i < inventoryItems.Length; i++)
            {
                inventoryItems[i] = new InventoryItem();
            }

            for (int i = 0; i < bankItems.Length; i++)
            {
                bankItems[i] = new InventoryItem();
                serverBankItems[i] = new InventoryItem();
            }
        }

        public bool IsItemEquipped(int itemIndex)
        {
            for (int i = 0; i < InventoryItemsCount; i++)
            {
                if (inventoryItems[i].Index == itemIndex &&
                    inventoryItems[i].IsEquipped)
                {
                    return true;
                }
            }

            return false;
        }

        public void BankItem(int itemId, int itemSlot, int quantity)
        {
            if (quantity == 0)
            {
                ServerBankItemsCount -= 1;

                for (int i = itemSlot; i < ServerBankItemsCount; i++)
                {
                    serverBankItems[i].Index = serverBankItems[i + 1].Index;
                    serverBankItems[i].Quantity = serverBankItems[i + 1].Quantity;
                }
            }
            else
            {
                serverBankItems[itemSlot].Index = itemId;
                serverBankItems[itemSlot].Quantity = quantity;

                if (itemSlot >= ServerBankItemsCount)
                {
                    ServerBankItemsCount = itemSlot + 1;
                }
            }

            UpdateBankItems();
        }

        public InventoryItem GetItem(int slot)
        {
            return inventoryItems[slot];
        }

        public InventoryItem GetBankItem(int slot)
        {
            return bankItems[slot];
        }

        public InventoryItem GetServerBankItem(int slot)
        {
            return serverBankItems[slot];
        }

        public void SetItem(int itemSlot, int numericalId)
        {
            inventoryItems[itemSlot].Index = numericalId;
        }

        public void SetItemCount(int itemSlot, int quantity)
        {
            inventoryItems[itemSlot].Quantity = quantity;
        }

        public void SetItemEquippedStatus(int itemSlot, bool isEquipped)
        {
            inventoryItems[itemSlot].IsEquipped = isEquipped;
        }

        public void RemoveItem(int itemSlot)
        {
            InventoryItemsCount--;

            for (int i = itemSlot; i < InventoryItemsCount; i++)
            {
                inventoryItems[i].Index = inventoryItems[i + 1].Index;
                inventoryItems[i].Quantity = inventoryItems[i + 1].Quantity;
                inventoryItems[i].IsEquipped = inventoryItems[i + 1].IsEquipped;
            }
        }

        public void UpdateBankItems()
        {
            BankItemsCount = ServerBankItemsCount;
            for (int l = 0; l < ServerBankItemsCount; l++)
            {
                bankItems[l].Index = serverBankItems[l].Index;
                bankItems[l].Quantity = serverBankItems[l].Quantity;
            }

            for (int itemSlot = 0; itemSlot < InventoryItemsCount; itemSlot++)
            {
                if (BankItemsCount >= MaximumBankSize)
                {
                    break;
                }

                int itemIndex = inventoryItems[itemSlot].Index;
                bool flag = false;

                for (int bankSlot = 0; bankSlot < BankItemsCount; bankSlot++)
                {
                    if (bankItems[bankSlot].Index != itemIndex)
                    {
                        continue;
                    }

                    flag = true;
                    break;
                }

                if (!flag)
                {
                    bankItems[BankItemsCount].Index = itemIndex;
                    bankItems[BankItemsCount].Quantity = 0;
                    bankItems[BankItemsCount].IsEquipped = false;

                    BankItemsCount++;
                }
            }

        }

        public int GetItemTotalCount(int itemIndex)
        {
            int quantity = 0;

            for (int i = 0; i < InventoryItemsCount; i++)
            {
                if (inventoryItems[i].Index != itemIndex)
                {
                    continue;
                }

                if (entityManager.GetItem(itemIndex).IsStackable == 1)
                {
                    quantity += 1;
                }
                else
                {
                    quantity += inventoryItems[i].Quantity;
                }
            }

            return quantity;
        }
    }
}
