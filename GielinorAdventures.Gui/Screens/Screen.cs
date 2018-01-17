using System;
using System.IO;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NuciXNA.Graphics;
using NuciXNA.Input;
using NuciXNA.Input.Events;
using NuciXNA.Primitives;
using NuciXNA.Primitives.Mapping;

namespace GielinorAdventures.Gui.Screens
{
    /// <summary>
    /// Screen.
    /// </summary>
    public class Screen
    {
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the xml path.
        /// </summary>
        /// <value>The xml path.</value>
        public string XmlPath { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [XmlIgnore]
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the background colour.
        /// </summary>
        /// <value>The background colour.</value>
        public Colour BackgroundColour { get; set; }

        /// <summary>
        /// Gets or sets the background colour.
        /// </summary>
        /// <value>The background colour.</value>
        public Colour ForegroundColour { get; set; }

        /// <summary>
        /// Gets or sets the screen arguments.
        /// </summary>
        /// <value>The screen arguments.</value>
        public string[] ScreenArgs { get; set; }

        /// <summary>
        /// Occurs when a key is pressed while this <see cref="Screen"/> has input focus.
        /// </summary>
        public event KeyboardKeyEventHandler KeyPressed;

        /// <summary>
        /// Occurs when a mouse button is pressed.
        /// </summary>
        public event MouseButtonEventHandler MouseButtonPressed;

        /// <summary>
        /// Occurs when the mouse moved.
        /// </summary>
        public event MouseEventHandler MouseMoved;

        /// <summary>
        /// Initializes a new instance of the <see cref="Screen"/> class.
        /// </summary>
        public Screen()
        {
            Type = GetType();
            Id = Guid.NewGuid().ToString();

            XmlPath = Path.Combine("Screens", $"{Type.Name}.xml");

            BackgroundColour = Colour.Black;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public virtual void LoadContent()
        {
            SetChildrenProperties();

            GraphicsManager.Instance.Graphics.GraphicsDevice.Clear(BackgroundColour.ToXnaColor());

            GuiManager.Instance.LoadContent();

            RegisterEvents();
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public virtual void UnloadContent()
        {
            GuiManager.Instance.UnloadContent();

            UnregisterEvents();
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public virtual void Update(GameTime gameTime)
        {
            SetChildrenProperties();

            GuiManager.Instance.Update(gameTime);
        }

        /// <summary>
        /// Draws the content on the specified spriteBatch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            GraphicsManager.Instance.Graphics.GraphicsDevice.Clear(BackgroundColour.ToXnaColor());
            GuiManager.Instance.Draw(spriteBatch);
        }

        protected virtual void SetChildrenProperties()
        {

        }

        protected virtual void RegisterEvents()
        {
            InputManager.Instance.KeyboardKeyPressed += OnKeyPressed;

            InputManager.Instance.MouseButtonPressed += OnMouseButtonPressed;
            InputManager.Instance.MouseMoved += OnMouseMoved;
        }

        protected virtual void UnregisterEvents()
        {
            InputManager.Instance.KeyboardKeyPressed -= OnKeyPressed;

            InputManager.Instance.MouseButtonPressed -= OnMouseButtonPressed;
            InputManager.Instance.MouseMoved -= OnMouseMoved;
        }

        protected virtual void OnKeyPressed(object sender, KeyboardKeyEventArgs e)
        {
            KeyPressed?.Invoke(sender, e);
        }

        protected virtual void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            MouseButtonPressed?.Invoke(sender, e);
        }

        protected virtual void OnMouseMoved(object sender, MouseEventArgs e)
        {
            MouseMoved?.Invoke(sender, e);
        }
    }
}

