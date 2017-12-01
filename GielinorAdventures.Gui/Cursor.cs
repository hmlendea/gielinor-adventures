﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GielinorAdventures.Graphics;
using GielinorAdventures.Graphics.CustomSpriteEffects;
using GielinorAdventures.Input;
using GielinorAdventures.Input.Enumerations;
using GielinorAdventures.Input.Events;
using GielinorAdventures.Primitives;
using GielinorAdventures.Primitives.Mapping;

namespace GielinorAdventures.Gui
{
    public class Cursor
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public Point2D Location { get; set; }

        public MouseButtonState State { get; private set; }

        public int Frames { get; set; }

        Sprite idleSprite;
        Sprite clickSprite;

        public Cursor()
        {
            Frames = 1;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            idleSprite = new Sprite { ContentFile = "Cursors/idle" };
            clickSprite = new Sprite { ContentFile = "Cursors/click" };

            SetChildrenProperites();

            idleSprite.LoadContent();
            clickSprite.LoadContent();

            InputManager.Instance.MouseButtonPressed += InputManager_OnMouseButtonPressed;
            InputManager.Instance.MouseButtonReleased += InputManager_OnMouseButtonReleased;
            InputManager.Instance.MouseMoved += InputManager_OnMouseMoved;
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            idleSprite.UnloadContent();
            clickSprite.UnloadContent();

            InputManager.Instance.MouseButtonPressed -= InputManager_OnMouseButtonPressed;
            InputManager.Instance.MouseButtonReleased -= InputManager_OnMouseButtonReleased;
            InputManager.Instance.MouseMoved -= InputManager_OnMouseMoved;
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {
            SetChildrenProperites();

            idleSprite.Update(gameTime);
            clickSprite.Update(gameTime);
        }

        /// <summary>
        /// Draws the content on the specified spriteBatch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (State == MouseButtonState.Pressed)
            {
                clickSprite.Draw(spriteBatch);
            }
            else
            {
                idleSprite.Draw(spriteBatch);
            }
        }

        void SetChildrenProperites()
        {
            idleSprite.Location = Location;
            clickSprite.Location = Location;
        }

        void InputManager_OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == MouseButton.LeftButton)
            {
                State = MouseButtonState.Pressed;
            }
        }

        void InputManager_OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == MouseButton.LeftButton)
            {
                State = MouseButtonState.Released;
            }
        }

        void InputManager_OnMouseMoved(object sender, MouseEventArgs e)
        {
            Location = e.Location.ToPoint2D();
        }
    }
}
