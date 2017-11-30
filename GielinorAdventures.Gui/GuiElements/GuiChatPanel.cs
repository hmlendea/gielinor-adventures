using System.Collections.Generic;

using GielinorAdventures.Graphics.Enumerations;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.Gui.GuiElements
{
    public sealed class GuiChatPanel : GuiElement
    {
        const int MessageHeight = 24;

        GuiImage background;

        List<GuiText> messageRows;

        public GuiChatPanel()
        {
            BackgroundColour = Colour.Black;
            ForegroundColour = Colour.Yellow;
        }

        public override void LoadContent()
        {
            messageRows = new List<GuiText>();

            background = new GuiImage
            {
                ContentFile = "ScreenManager/FillImage",
                TextureLayout = TextureLayout.Tile
            };

            Children.Add(background);

            base.LoadContent();
        }

        public void AddMessage(string message)
        {
            for (int i = 0; i < messageRows.Count - 1; i++)
            {
                messageRows[i].Text = messageRows[i + 1].Text;
            }

            messageRows[messageRows.Count - 1].Text = message;
        }

        protected override void SetChildrenProperties()
        {
            background.Size = Size;
            background.Location = Location;
            background.TintColour = BackgroundColour;

            // Add additional rows if there is enough room (the chat panel was expanded)
            while (Size.Height - (messageRows.Count * MessageHeight) >= MessageHeight)
            {
                GuiText newRow = new GuiText
                {
                    FontName = "ChatFont",
                    VerticalAlignment = VerticalAlignment.Left
                };

                newRow.LoadContent();
                Children.Add(newRow);

                messageRows.Insert(0, newRow);
            }

            // Remove extra rows if there is not enough room (the chat panel was shrunk)
            while (Size.Height < MessageHeight * messageRows.Count)
            {
                messageRows.RemoveAt(0);
            }

            // Update the properties of 
            int y = ClientRectangle.Bottom - MessageHeight;
            for (int i = messageRows.Count - 1; i >= 0; i--)
            {
                GuiText message = messageRows[i];

                message.Size = new Size2D(Size.Width, MessageHeight);
                message.ForegroundColour = ForegroundColour;
                message.Location = new Point2D(Location.X, y);

                y -= message.Size.Height;
            }

            base.SetChildrenProperties();
        }
    }
}
