using Microsoft.Xna.Framework;
using NuciXNA.Primitives;

using GielinorAdventures.GameLogic.GameManagers;
using GielinorAdventures.Models;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiInventoryPanel : GuiElement
    {
        IGameManager game;

        GuiItemCard[] itemCards;

        const int Rows = 8;
        const int Columns = 4;

        public override void LoadContent()
        {
            itemCards = new GuiItemCard[Rows * Columns];

            for (int i = 0; i < Rows * Columns; i++)
            {
                itemCards[i] = new GuiItemCard();

                Children.Add(itemCards[i]);
            }

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            SetItems();
        }

        public void AssociateGameManager(IGameManager game)
        {
            this.game = game;
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            int spacingX = (Size.Width - Columns * itemCards[0].Size.Width) / (Columns + 1);
            int spacingY = (Size.Height - Rows * itemCards[0].Size.Height) / (Rows + 1);

            for (int i = 0; i < Rows * Columns; i++)
            {
                int x = i % Columns;
                int y = i / Columns;

                itemCards[i].Location = new Point2D(
                    Location.X + spacingX * (x + 1) + itemCards[i].Size.Width * x,
                    Location.Y + spacingY * (y + 1) + itemCards[i].Size.Height * y);
            }
        }

        void SetItems()
        {
            for (int itemSlot = 0; itemSlot < game.InventorySize; itemSlot++)
            {
                InventoryItem inventoryItem = game.GetInventoryItem(itemSlot);

                if (string.IsNullOrWhiteSpace(inventoryItem?.Id))
                {
                    continue;
                }

                Item item = game.GetItem(inventoryItem.Id);

                itemCards[itemSlot].ItemPictureId = item.InventoryPicture;
                itemCards[itemSlot].Quantity = inventoryItem.Quantity;
            }
        }
    }
}
