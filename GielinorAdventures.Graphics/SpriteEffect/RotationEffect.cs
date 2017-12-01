using Microsoft.Xna.Framework;

namespace GielinorAdventures.Graphics.CustomSpriteEffects
{
    /// <summary>
    /// Rotation sprite effect.
    /// </summary>
    public class RotationEffect : CustomSpriteEffect
    {
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public float Speed { get; set; }

        /// <summary>
        /// Gets or sets the maximum rotation.
        /// </summary>
        /// <value>The maximum rotation.</value>
        public float MaximumRotation { get; set; }

        /// <summary>
        /// Gets or sets the current rotation.
        /// </summary>
        /// <value>The current rotation.</value>
        public float CurrentRotation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RotationEffect"/> is increasing.
        /// </summary>
        /// <value><c>true</c> if increasing; otherwise, <c>false</c>.</value>
        public bool Increasing { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RotationEffect"/> class.
        /// </summary>
        public RotationEffect()
        {
            Speed = 0.5f;
            MaximumRotation = 1.0f;
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
                    CurrentRotation -= Speed * ((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                else
                {
                    CurrentRotation += Speed * ((float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (CurrentRotation < -MaximumRotation)
                {
                    Increasing = true;
                    CurrentRotation = -MaximumRotation;
                }
                else if (Sprite.Rotation + CurrentRotation > MaximumRotation)
                {
                    Increasing = false;
                    CurrentRotation = MaximumRotation;
                }
            }
            else
            {
                CurrentRotation = MaximumRotation;
            }
        }
    }
}
