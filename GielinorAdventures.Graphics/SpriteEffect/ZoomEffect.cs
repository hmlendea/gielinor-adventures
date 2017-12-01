using Microsoft.Xna.Framework;

namespace GielinorAdventures.Graphics.CustomSpriteEffects
{
    /// <summary>
    /// Zoom sprite effect.
    /// </summary>
    public class ZoomEffect : CustomSpriteEffect
    {
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public float Speed { get; set; }

        /// <summary>
        /// Gets or sets the minimum zoom.
        /// </summary>
        /// <value>The minimum zoom.</value>
        public float MinimumZoom { get; set; }

        /// <summary>
        /// Gets or sets the maximum zoom.
        /// </summary>
        /// <value>The maximum zoom.</value>
        public float MaximumZoom { get; set; }

        /// <summary>
        /// Gets or sets the current zoom.
        /// </summary>
        /// <value>The current zoom.</value>
        public float CurrentZoom { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZoomEffect"/> is increasing.
        /// </summary>
        /// <value><c>true</c> if increasing; otherwise, <c>false</c>.</value>
        public bool Increasing { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomEffect"/> class.
        /// </summary>
        public ZoomEffect()
        {
            Speed = 0.5f;
            MinimumZoom = 0.75f;
            MaximumZoom = 1.25f;
            Increasing = false;
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Sprite.Active)
            {
                if (Increasing == false)
                {
                    CurrentZoom -= Speed * ((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                else
                {
                    CurrentZoom += Speed * ((float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (Sprite.Zoom + CurrentZoom < MinimumZoom)
                {
                    Increasing = true;
                    CurrentZoom = MinimumZoom;
                }
                else if (Sprite.Zoom + CurrentZoom > MaximumZoom)
                {
                    Increasing = false;
                    CurrentZoom = MaximumZoom;
                }
            }
            else
            {
                CurrentZoom = MaximumZoom;
            }
        }
    }
}
