using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NuciXNA.DataAccess.Resources;
using NuciXNA.Input.Events;
using NuciXNA.Primitives;
using NuciXNA.Primitives.Mapping;

using GielinorAdventures.GameLogic.GameManagers;
using GielinorAdventures.Graphics;
using GielinorAdventures.Models;
using GielinorAdventures.Models.Enumerations;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiMinimap : GuiElement
    {
        IGameManager game;

        GuiMinimapIndicator compassIndicator;
        GuiMinimapIndicator healthIndicator;
        GuiMinimapIndicator energyIndicator;
        GuiMinimapIndicator prayerIndicator;

        byte[,] alphaMask;

        Sprite mapMarkerSprite;
        Sprite mobDot;
        Sprite pixel;
        Sprite frame;

        public bool IsClickable { get; set; }

        public int ZoomLevel { get; set; }

        public GuiMinimap()
        {
            IsClickable = true;
            ZoomLevel = 2;
        }

        public override void LoadContent()
        {
            mapMarkerSprite = new Sprite { ContentFile = "Interface/Minimap/markers" };
            mobDot = new Sprite { ContentFile = "Interface/Minimap/entity_dot" };
            pixel = new Sprite
            {
                ContentFile = "ScreenManager/FillImage",
                Scale = new Scale2D(ZoomLevel, ZoomLevel)
            };
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
            energyIndicator = new GuiMinimapIndicator
            {
                BaseValue = 100,
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

            mapMarkerSprite.LoadContent();
            mobDot.LoadContent();
            pixel.LoadContent();
            frame.LoadContent();

            Children.Add(compassIndicator);
            Children.Add(healthIndicator);
            Children.Add(energyIndicator);
            Children.Add(prayerIndicator);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            mapMarkerSprite.Update(gameTime);
            mobDot.Update(gameTime);
            pixel.Update(gameTime);
            frame.Update(gameTime);

            compassIndicator.IconRotation = 1;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Player player = game.GetPlayer();

            Point2D startLocation = new Point2D(
                player.Location.X - Size.Width / (2 * ZoomLevel),
                player.Location.Y - Size.Height / (2 * ZoomLevel));

            DrawMinimapTerrain(spriteBatch, startLocation);
            DrawMinimapMarkers(spriteBatch, startLocation);
            DrawMinimapEntities(spriteBatch);
            frame.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }

        public void AssociateGameManager(IGameManager game)
        {
            this.game = game;
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            Player player = game.GetPlayer();

            frame.Location = Location;

            compassIndicator.Location = new Point2D(Location.X + 40, Location.Y + 9);

            healthIndicator.CurrentValue = player.HitpointsSkill.CurrentLevel;
            healthIndicator.BaseValue = player.HitpointsSkill.BaseLevel;
            healthIndicator.Location = new Point2D(Location.X + 17, Location.Y + 36);

            energyIndicator.CurrentValue = player.Energy;
            energyIndicator.Location = new Point2D(Location.X + 162, Location.Y + 146);

            prayerIndicator.CurrentValue = player.PrayerSkill.CurrentLevel;
            prayerIndicator.BaseValue = player.PrayerSkill.BaseLevel;
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

        void DrawMinimapTerrain(SpriteBatch spriteBatch, Point2D startLocation)
        {
            for (int y = 0; y < Size.Height / ZoomLevel; y++)
            {
                for (int x = 0; x < Size.Width / ZoomLevel; x++)
                {
                    Point2D screenLocation = new Point2D(
                        Location.X + x * ZoomLevel,
                        Location.Y + y * ZoomLevel);

                    Terrain terrain = game.GetTerrain(
                        startLocation.X + x,
                        startLocation.Y + y);
                    Colour terrainColour = terrain != null ? terrain.Colour : Colour.Black;

                    DrawMinimapPixel(spriteBatch, terrainColour, screenLocation);
                }
            }
        }

        void DrawMinimapMarkers(SpriteBatch spriteBatch, Point2D startLocation)
        {
            List<MapMarker> mapMarkers = game.GetMapMarkers(
                startLocation.X,
                startLocation.Y,
                startLocation.X + Size.Width,
                startLocation.Y + Size.Height).ToList();

            foreach (MapMarker mapMarker in mapMarkers)
            {
                int xOffset = mapMarker.Location.X - startLocation.X;
                int yOffset = mapMarker.Location.Y - startLocation.Y;

                mapMarkerSprite.SourceRectangle = CalculateIconSourceRectangle(mapMarker.Type);
                mapMarkerSprite.Location = new Point2D(
                    Location.X + xOffset * ZoomLevel - mapMarkerSprite.SourceRectangle.Width / 2,
                    Location.Y + yOffset * ZoomLevel - mapMarkerSprite.SourceRectangle.Height / 2);

                mapMarkerSprite.Draw(spriteBatch);
            }
        }

        void DrawMinimapEntities(SpriteBatch spriteBatch)
        {
            Point2D location = new Point2D(
                Location.X + Size.Width / 2,
                Location.Y + Size.Height / 2);

            DrawMinimapDot(spriteBatch, location, Colour.White);
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

        void DrawMinimapDot(SpriteBatch spriteBatch, Point2D dotLocation, Colour colour)
        {
            if (dotLocation.X < ClientRectangle.Left ||
                dotLocation.Y < ClientRectangle.Top ||
                dotLocation.X >= ClientRectangle.Right ||
                dotLocation.Y >= ClientRectangle.Bottom)
            {
                return;
            }

            mobDot.Tint = colour;
            mobDot.Location = new Point2D(
                dotLocation.X - mobDot.SpriteSize.Width / 2,
                dotLocation.Y - mobDot.SpriteSize.Height / 2);

            mobDot.Draw(spriteBatch);
        }

        void DrawMinimapPixel(SpriteBatch spriteBatch, Colour colour, Point2D screenLocation)
        {
            if (!ClientRectangle.Contains(screenLocation))
            {
                return;
            }

            int alpha = alphaMask[screenLocation.X - Location.X, screenLocation.Y - Location.Y];

            if (alpha == 0)
            {
                return;
            }

            pixel.Tint = colour;
            pixel.Location = screenLocation;

            // TODO: Opacity changing doesn't work properly
            //pixel.Opacity = alphaMask[screenLocation.X - Location.X, screenLocation.Y - Location.Y];

            pixel.Draw(spriteBatch);
        }

        void CompassIndicator_Clicked(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        Rectangle2D CalculateIconSourceRectangle(MapMarkerType mapMarkerType)
        {
            return new Rectangle2D(
                (int)mapMarkerType % 14 * 16,
                (int)mapMarkerType / 14 * 16,
                16,
                16);
        }
    }
}
