using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GielinorAdventures.GameLogic.GameManagers;
using GielinorAdventures.Gui.WorldMap;
using GielinorAdventures.Input.Events;
using GielinorAdventures.Primitives;
using GielinorAdventures.Primitives.Mapping;
using GielinorAdventures.Settings;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiWorldmap : GuiElement
    {
        IGameManager game;
        Camera camera;
        Map map;

        Point2D mouseCoords;

        GuiMob player;

        public override void LoadContent()
        {
            camera = new Camera { Size = Size };
            map = new Map();
            player = new GuiMob();

            camera.LoadContent();
            map.LoadContent(game.GetWorld());

            Children.Add(player);

            base.LoadContent();
        }

        public override void UnloadContent()
        {
            camera.UnloadContent();
            map.UnloadContent();

            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            camera.Size = Size;

            CentreCameraOnLocation(game.GetPlayer().Location);

            camera.Update(gameTime);
            map.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, camera);

            base.Draw(spriteBatch);
        }

        // TODO: Handle this better
        /// <summary>
        /// Associates the game manager.
        /// </summary>
        /// <param name="game">Game.</param>
        public void AssociateGameManager(IGameManager game)
        {
            this.game = game;
        }

        /// <summary>
        /// Centres the camera on the specified location.
        /// </summary>
        public void CentreCameraOnLocation(Point2D mapLocation)
        {
            camera.CentreOnLocation(new Point2D(
                mapLocation.X * GameDefines.MAP_TILE_SIZE,
                mapLocation.Y * GameDefines.MAP_TILE_SIZE));
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            player.Location = new Point2D(
                (Size.Width - player.Size.Width) / 2,
                (Size.Height - player.Size.Height) / 2);
        }

        /// <summary>
        /// Gets the map cpprdomates based on the specified screen coordinates.
        /// </summary>
        /// <returns>The map coordinates.</returns>
        /// <param name="screenCoords">Screen coordinates.</param>
        Point2D ScreenToMapCoordinates(Point2D screenCoords)
        {
            return new Point2D((camera.Location.X + screenCoords.X) / GameDefines.MAP_TILE_SIZE,
                               (camera.Location.Y + screenCoords.Y) / GameDefines.MAP_TILE_SIZE);
        }

        protected override void OnClicked(object sender, MouseButtonEventArgs e)
        {
            base.OnClicked(sender, e);

            Point2D mapLocation = ScreenToMapCoordinates(e.Location.ToPoint2D());

            game.MovePlayer(mapLocation);
        }

        protected override void OnMouseMoved(object sender, MouseEventArgs e)
        {
            base.OnMouseMoved(sender, e);

            mouseCoords = e.Location.ToPoint2D();
        }
    }
}
