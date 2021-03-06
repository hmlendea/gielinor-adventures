﻿using System;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NuciXNA.Graphics;
using NuciXNA.Graphics.Enumerations;
using NuciXNA.Graphics.SpriteEffects;
using NuciXNA.Primitives;

using GielinorAdventures.Settings;

namespace GielinorAdventures.Gui.Screens
{
    /// <summary>
    /// Screen manager.
    /// </summary>
    public class ScreenManager
    {
        static volatile ScreenManager instance;
        static object syncRoot = new object();

        Screen currentScreen, newScreen;
        Sprite transitionSprite;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ScreenManager();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        [XmlIgnore]
        public Size2D Size { get; private set; }

        /// <summary>
        /// Gets or sets the sprite batch.
        /// </summary>
        /// <value>The sprite batch.</value>
        [XmlIgnore]
        public SpriteBatch SpriteBatch { get; set; }

        /// <summary>
        /// Gets a value indicating whether the current screen is transitioning.
        /// </summary>
        /// <value><c>true</c> if transitioning; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool Transitioning { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenManager"/> class.
        /// </summary>
        public ScreenManager()
        {
            Size = SettingsManager.Instance.GraphicsSettings.Resolution;
            currentScreen = new SplashScreen();
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            transitionSprite = new Sprite
            {
                ContentFile = "ScreenManager/FillImage",
                Tint = Colour.Black,
                FadeEffect = new FadeEffect { Speed = 3 },
                TextureLayout = TextureLayout.Tile
            };

            transitionSprite.FadeEffect.AssociateSprite(transitionSprite);

            currentScreen.LoadContent();
            transitionSprite.LoadContent();
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            transitionSprite.UnloadContent();
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);

            if (Transitioning)
            {
                Transition(gameTime);
                return;
            }

            Size = SettingsManager.Instance.GraphicsSettings.Resolution;
            transitionSprite.Scale = new Scale2D(Size);
        }

        /// <summary>
        /// Draw the content on the specified spriteBatch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);

            if (Transitioning)
            {
                transitionSprite.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Changes the screen.
        /// </summary>
        /// <param name="screenName">Screen name.</param>
        public void ChangeScreens(string screenName)
        {
            ChangeScreens(screenName, null);
        }

        /// <summary>
        /// Changes the screen.
        /// </summary>
        /// <param name="screenName">Screen name.</param>
        /// <param name="screenArgs">Screen arguments.</param>
        public void ChangeScreens(string screenName, string[] screenArgs)
        {
            newScreen = (Screen)Activator.CreateInstance(Type.GetType($"{typeof(Screen).Namespace}.{screenName}"));

            newScreen.ScreenArgs = screenArgs;

            transitionSprite.FadeEffect.Activate();

            transitionSprite.Active = true;
            transitionSprite.FadeEffect.Increasing = true;
            transitionSprite.Opacity = 0.0f;

            Transitioning = true;
        }

        /// <summary>
        /// Transitions to the new screen.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        void Transition(GameTime gameTime)
        {
            transitionSprite.Update(gameTime);

            if (transitionSprite.Opacity >= 1.0f)
            {
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent();
            }
            else if (transitionSprite.Opacity <= 0.0f)
            {
                transitionSprite.Active = false;
                Transitioning = false;
            }
        }
    }
}

