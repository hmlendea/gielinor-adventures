﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GielinorAdventures.Graphics;
using GielinorAdventures.Graphics.CustomSpriteEffects;
using GielinorAdventures.Gui.GuiElements;
using GielinorAdventures.Input.Events;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.Gui.Screens
{
    /// <summary>
    /// Splash screen.
    /// </summary>
    public class SplashScreen : Screen
    {
        /// <summary>
        /// Gets or sets the delay.
        /// </summary>
        /// <value>The delay.</value>
        public float Delay { get; set; }

        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        /// <value>The background.</value>
        public Sprite BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the overlay.
        /// </summary>
        /// <value>The overlay.</value>
        public GuiImage OverlayImage { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        public GuiImage LogoImage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
        {
            Delay = 3;
            BackgroundColour = Colour.FromArgb(88, 109, 157);
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            BackgroundImage = new Sprite
            {
                ContentFile = "SplashScreen/Background",
                RotationEffect = new RotationEffect
                {
                    Speed = 0.1f,
                    MaximumRotation = 0.2f
                },
                ZoomEffect = new ZoomEffect
                {
                    Speed = 0.1f,
                    MinimumZoom = 1.25f,
                    MaximumZoom = 2.00f
                }
            };
            OverlayImage = new GuiImage { ContentFile = "SplashScreen/Overlay" };
            LogoImage = new GuiImage { ContentFile = "SplashScreen/Logo" };

            base.LoadContent();

            BackgroundImage.LoadContent();
            OverlayImage.LoadContent();
            LogoImage.LoadContent();

            BackgroundImage.ActivateEffect("RotationEffect");
            BackgroundImage.ActivateEffect("ZoomEffect");
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();

            BackgroundImage.UnloadContent();
            OverlayImage.UnloadContent();
            LogoImage.UnloadContent();
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            BackgroundImage.Update(gameTime);
            OverlayImage.Update(gameTime);
            LogoImage.Update(gameTime);

            Delay -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Draws the content on the specified spriteBatch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            BackgroundImage.Draw(spriteBatch);
            OverlayImage.Draw(spriteBatch);
            LogoImage.Draw(spriteBatch);
        }

        protected override void SetChildrenProperties()
        {
            float bgScale = (float)Math.Max(ScreenManager.Instance.Size.Width, ScreenManager.Instance.Size.Height) /
                            Math.Max(BackgroundImage.SpriteSize.Width, BackgroundImage.SpriteSize.Height);


            BackgroundImage.Scale = new Scale2D(bgScale, bgScale);
            OverlayImage.Size = ScreenManager.Instance.Size;

            BackgroundImage.Location = new Point2D((ScreenManager.Instance.Size.Width - BackgroundImage.ClientRectangle.Width) / 2,
                                                   (ScreenManager.Instance.Size.Height - BackgroundImage.ClientRectangle.Height) / 2);
            LogoImage.Location = new Point2D((ScreenManager.Instance.Size.Width - LogoImage.Size.Width) / 2,
                                             (ScreenManager.Instance.Size.Height - LogoImage.Size.Height) / 2);
        }

        protected override void OnKeyPressed(object sender, KeyboardKeyEventArgs e)
        {
            base.OnKeyPressed(sender, e);

            ScreenManager.Instance.ChangeScreens("GameplayScreen");
        }

        protected override void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseButtonPressed(sender, e);

            ScreenManager.Instance.ChangeScreens("GameplayScreen");
        }
    }
}
