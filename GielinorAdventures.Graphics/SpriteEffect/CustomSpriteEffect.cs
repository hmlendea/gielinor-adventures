using System;
using System.Xml.Serialization;
using System.Linq;

using Microsoft.Xna.Framework;

namespace GielinorAdventures.Graphics.CustomSpriteEffects
{
    /// <summary>
    /// Effect.
    /// </summary>
    public class CustomSpriteEffect
    {
        bool isContentLoaded;
        protected Sprite Sprite;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomSpriteEffect"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [XmlIgnore]
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        [XmlIgnore]
        public string Key { get { return Type.ToString().Split('.').Last(); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSpriteEffect"/> class.
        /// </summary>
        public CustomSpriteEffect()
        {
            Active = false;
            Type = GetType();
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public virtual void LoadContent()
        {

        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public virtual void UnloadContent()
        {
            Active = false;
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        public void AssociateSprite(Sprite sprite)
        {
            Sprite = sprite;
        }

        public void Activate()
        {
            Active = true;

            if (!isContentLoaded)
            {
                LoadContent();
            }
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
