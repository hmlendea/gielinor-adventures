using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GielinorAdventures.GameLogic.GameManagers;
using GielinorAdventures.Gui.GuiElements;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.Gui.Screens
{
    /// <summary>
    /// Gameplay screen.
    /// </summary>
    public class GameplayScreen : Screen
    {
        IGameManager game;

        /// <summary>
        /// Gets or sets the minimap.
        /// </summary>
        /// <value>The minimap.</value>
        public GuiMinimap Minimap { get; set; }

        /// <summary>
        /// Gets or sets the minimap.
        /// </summary>
        /// <value>The minimap.</value>
        public GuiSideBar SideBar { get; set; }

        public GuiChatPanel ChatPanel { get; set; }

        /// <summary>
        /// Gets or sets the game client.
        /// </summary>
        /// <value>The game client.</value>
        public GuiWorldmap Worldmap { get; set; }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            Minimap = new GuiMinimap { Size = new Size2D(224, 176) };
            SideBar = new GuiSideBar { Size = new Size2D(240, 334) };
            ChatPanel = new GuiChatPanel();
            Worldmap = new GuiWorldmap();

            game = new GameManager();

            Worldmap.AssociateGameManager(game);
            Minimap.AssociateGameManager(game);

            GuiManager.Instance.GuiElements.Add(Worldmap);
            GuiManager.Instance.GuiElements.Add(Minimap);
            GuiManager.Instance.GuiElements.Add(SideBar);
            GuiManager.Instance.GuiElements.Add(ChatPanel);

            base.LoadContent();

            SideBar.AssociateGameManager(game);
        }

        protected override void SetChildrenProperties()
        {
            Worldmap.Size = ScreenManager.Instance.Size;

            SideBar.Location = new Point2D(
                ScreenManager.Instance.Size.Width - SideBar.Size.Width,
                ScreenManager.Instance.Size.Height - SideBar.Size.Height);

            Minimap.Location = new Point2D(ScreenManager.Instance.Size.Width - Minimap.Size.Width, 0);

            ChatPanel.Size = new Size2D(
                ScreenManager.Instance.Size.Width - SideBar.Size.Width,
                (int)(ScreenManager.Instance.Size.Height * 0.25));
            ChatPanel.Location = new Point2D(0, ScreenManager.Instance.Size.Height - ChatPanel.Size.Height);
        }
    }
}
