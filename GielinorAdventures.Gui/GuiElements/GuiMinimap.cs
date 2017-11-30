using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GielinorAdventures.DataAccess.Resources;
using GielinorAdventures.Graphics;
using GielinorAdventures.Input.Events;
using GielinorAdventures.Primitives;
using GielinorAdventures.Primitives.Mapping;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiMinimap : GuiElement
    {
        GuiMinimapIndicator compassIndicator;
        GuiMinimapIndicator healthIndicator;
        GuiMinimapIndicator staminaIndicator;
        GuiMinimapIndicator prayerIndicator;

        byte[,] alphaMask;

        Sprite mobDot;
        Sprite pixel;
        Sprite frame;

        public bool IsClickable { get; set; }

        public GuiMinimap()
        {
            IsClickable = true;
        }

        public override void LoadContent()
        {
            mobDot = new Sprite { ContentFile = "Interface/Minimap/entity_dot" };
            pixel = new Sprite { ContentFile = "ScreenManager/FillImage" };
            frame = new Sprite { ContentFile = "Interface/Minimap/frame" };

            compassIndicator = new GuiMinimapIndicator
            {
                BackgroundColour = Colour.Bisque,
                Icon = "Interface/Minimap/icon_compass"
            };
            healthIndicator = new GuiMinimapIndicator
            {
                BackgroundColour = Colour.PersianRed,
                Icon = "Interface/Minimap/icon_health"
            };
            staminaIndicator = new GuiMinimapIndicator
            {
                BackgroundColour = Colour.OliveDrab,
                Icon = "Interface/Minimap/icon_stamina"
            };
            prayerIndicator = new GuiMinimapIndicator
            {
                BackgroundColour = Colour.CornflowerBlue,
                Icon = "Interface/Minimap/icon_prayer"
            };

            Texture2D maskTexture = ResourceManager.Instance.LoadTexture2D("Interface/Minimap/mask");
            Color[] maskBits = new Color[maskTexture.Width * maskTexture.Height];
            maskTexture.GetData(maskBits, 0, maskBits.Length);

            alphaMask = new byte[Size.Width, Size.Height];

            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                {
                    int i = x + y * Size.Width;

                    alphaMask[x, y] = maskBits[i].R;
                }
            }

            mobDot.LoadContent();
            pixel.LoadContent();
            frame.LoadContent();

            Children.Add(compassIndicator);
            Children.Add(healthIndicator);
            Children.Add(staminaIndicator);
            Children.Add(prayerIndicator);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            mobDot.Update(gameTime);
            pixel.Update(gameTime);
            frame.Update(gameTime);

            compassIndicator.IconRotation = 1;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawMinimapMenu(spriteBatch);
            frame.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            frame.Location = Location;

            compassIndicator.Location = new Point2D(Location.X + 40, Location.Y + 9);
            healthIndicator.Location = new Point2D(Location.X + 17, Location.Y + 36);
            staminaIndicator.Location = new Point2D(Location.X + 162, Location.Y + 146);
            prayerIndicator.Location = new Point2D(Location.X + 10, Location.Y + 72);
        }

        protected override void RegisterEvents()
        {
            compassIndicator.Clicked += CompassIndicator_Clicked;
        }

        protected override void UnregisterEvents()
        {
            compassIndicator.Clicked -= CompassIndicator_Clicked;
        }

        void DrawMinimapMenu(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        void DrawMinimapTiles(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                {
                    Colour tileColour = Colour.Black;
                    int alpha = tileColour.A - 255 + alphaMask[x, y];

                    pixel.Location = new Point2D(Location.X + x, Location.Y + y);
                    pixel.Tint = Color.FromNonPremultiplied(tileColour.R, tileColour.G, tileColour.B, alpha).ToColour();

                    pixel.Draw(spriteBatch);
                }
            }
        }

        void DrawMinimapObject(SpriteBatch spriteBatch, int x, int y, Colour colour)
        {
            if (x < ClientRectangle.Left || x >= ClientRectangle.Right ||
                y < ClientRectangle.Top || y >= ClientRectangle.Bottom)
            {
                return;
            }

            mobDot.Tint = colour;
            mobDot.Opacity = alphaMask[x - Location.X, y - Location.Y];
            mobDot.Location = new Point2D(
                x - mobDot.SpriteSize.Width / 2,
                y - mobDot.SpriteSize.Height / 2);

            mobDot.Draw(spriteBatch);
        }

        void CompassIndicator_Clicked(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
