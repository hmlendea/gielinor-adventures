using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NuciXNA.Primitives;

using GielinorAdventures.Graphics;
using GielinorAdventures.Gui.MobAnimationEffects;
using GielinorAdventures.Settings;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiMob : GuiElement
    {
        Sprite mob;

        public override void LoadContent()
        {
            mob = new Sprite
            {
                ContentFile = "SpriteSheets/Mobs/human_male_white",
                SpriteSheetEffect = new HumanSpriteSheetEffect(),
                Active = true
            };

            mob.SpriteSheetEffect.AssociateSprite(mob);
            mob.LoadContent();

            base.LoadContent();

            mob.SpriteSheetEffect.Activate();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            mob.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            mob.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            mob.Draw(spriteBatch);
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            if (mob.SourceRectangle.Width == GameDefines.MAP_TILE_SIZE &&
                mob.SourceRectangle.Height == GameDefines.MAP_TILE_SIZE)
            {
                mob.Location = Location;
            }
            else
            {
                mob.Location = new Point2D(
                    Location.X + (GameDefines.MAP_TILE_SIZE - mob.SourceRectangle.Width) / 2,
                    Location.Y + GameDefines.MAP_TILE_SIZE - mob.SourceRectangle.Height);
            }
        }
    }
}